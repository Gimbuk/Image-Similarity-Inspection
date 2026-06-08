using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = System.Drawing.Point;

namespace Han
{
    public partial class Form1 : Form
    {
        // ROI저장,이미지 경로
        private string currentImagePath = "";
        private string templateImagePath = "";
        private bool isDragging = false;
        private Point startPoint;
        private Rectangle roiRect;
        private readonly string csvPath =
           Path.Combine(Application.StartupPath, "inspection_log.csv");
        private readonly string roiPath =
           Path.Combine(Application.StartupPath, "roi.txt");
        public Form1()
        {
            InitializeComponent();
            // 검사 결과 로그
            dgvLog.Columns.Add("Time", "시간");
            dgvLog.Columns.Add("FileName", "파일명");
            dgvLog.Columns.Add("Similarity", "유사도");
            dgvLog.Columns.Add("Result", "결과");
            // CSV파일 없으면 헤더 생성
            if (!File.Exists(csvPath))
            {
                File.WriteAllText(
                    csvPath,
                    "시간,파일명,유사도,결과" + Environment.NewLine,
                    Encoding.UTF8
                );
            }

        }
        private void btnimgLoad_Click(object sender, EventArgs e)   // 이미지 로드
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "이미지 파일|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentImagePath = ofd.FileName;
                ImgBox.Image = Image.FromFile(currentImagePath);
            }
        }
        private void btninspect_Click(object sender, EventArgs e)  // 유사도 검사
        {
            if (string.IsNullOrEmpty(templateImagePath))
            {
                MessageBox.Show("템플릿 이미지를 먼저 불러오세요.");
                return;
            }
            if (ImgBox.Image == null)
            {
                MessageBox.Show("이미지를 먼저 불러오세요.");
                return;
            }

            if (roiRect.Width <= 0 || roiRect.Height <= 0)
            {
                MessageBox.Show("ROI를 먼저 선택하세요.");
                return;
            }

            Mat img = Cv2.ImRead(currentImagePath);

            // PictureBox -> 이미지 좌표 변환
            double scaleX = (double)img.Width / ImgBox.Width;
            double scaleY = (double)img.Height / ImgBox.Height;

            Rect roi = new Rect(
                (int)(roiRect.X * scaleX),
                (int)(roiRect.Y * scaleY),
                (int)(roiRect.Width * scaleX),
                (int)(roiRect.Height * scaleY)
            );
            // ROI 좌표 음수방지
            roi.X = Math.Max(0, roi.X);
            roi.Y = Math.Max(0, roi.Y);

            roi.Width = Math.Min(roi.Width, img.Width - roi.X);
            roi.Height = Math.Min(roi.Height, img.Height - roi.Y);

            Mat roiImage = new Mat(img, roi);
            Mat gray = new Mat();                                                         // 흑백 변환
            Cv2.CvtColor(roiImage, gray, ColorConversionCodes.BGR2GRAY);
            Mat template = Cv2.ImRead(templateImagePath);
            Mat templateGray = new Mat();
            Cv2.CvtColor(template, templateGray, ColorConversionCodes.BGR2GRAY);
            // ROI 크기에 맞게 템플릿 리사이즈
            Cv2.Resize(
                templateGray,
                templateGray,
                new OpenCvSharp.Size(gray.Width, gray.Height)
                      );
            Mat resultMat = new Mat();
            // 유사도 계산
            Cv2.MatchTemplate(
                gray,
                templateGray,
                resultMat,
                TemplateMatchModes.CCoeffNormed
            );

            Cv2.MinMaxLoc(
                resultMat,
                out double minVal,
                out double maxVal,
                out _,
                out _
            );
            double similarity = maxVal;
            double threshold;

            if (!double.TryParse(txtThreshold.Text, out threshold))
            {
                MessageBox.Show("유사도 기준값을 숫자로 입력하세요.");
                return;
            }
            string result;
            // 유사도 판정
            if (similarity >= threshold)
            {
                result = "PASS";
            }
            else
            {
                result = "FAIL";
            }
            if (result == "PASS")
            {
                lblResult.ForeColor = Color.Green;
                lblResult.Text = "● Pass";
            }
            else
            {
                lblResult.ForeColor = Color.Red;
                lblResult.Text = "● Fail";
                string failFolder = Path.Combine(Application.StartupPath, "FailImages");
                Directory.CreateDirectory(failFolder);
                string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string saveFolder = Path.Combine(failFolder, timeStamp);
                Directory.CreateDirectory(saveFolder);

                Mat failImg = img.Clone();
                // ROI 영역 표시
                Cv2.Rectangle(
                    failImg,
                    roi,
                    new Scalar(0, 0, 255),
                    3
                );

                string failImagePath = Path.Combine(saveFolder, "fail.png");
                Cv2.ImWrite(failImagePath, failImg);
                string templateSavePath = Path.Combine(saveFolder, "template.png");
                Cv2.ImWrite(templateSavePath, template);
                MessageBox.Show($"FAIL 이미지 저장됨\n{saveFolder}");
            }

            lblSimilarity.Text = $"유사도 : {similarity:F3}\r\n기준 : {threshold:F2}";

            string logFileName = Path.GetFileName(currentImagePath);
            // 화면 로그
            dgvLog.Rows.Add(
                DateTime.Now.ToString("HH:mm:ss"),
                logFileName,
                similarity.ToString("F2"),
                result
            );
            // CSV 검사 이력 저장
            File.AppendAllText(
            csvPath,
            $"{DateTime.Now:HH:mm:ss},{logFileName},{similarity:F3},{result}{Environment.NewLine}",
            Encoding.UTF8
            );
        }
        private void ImgBox_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            startPoint = e.Location;
        }
        private void ImgBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging)
                return;
            roiRect = new Rectangle(
                Math.Min(startPoint.X, e.X),
                Math.Min(startPoint.Y, e.Y),
                Math.Abs(e.X - startPoint.X),
                Math.Abs(e.Y - startPoint.Y)
            );
            ImgBox.Invalidate();
        }
        private void ImgBox_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
        private void ImgBox_Paint(object sender, PaintEventArgs e)
        {
            if (roiRect.Width > 0 && roiRect.Height > 0)
            {
                e.Graphics.DrawRectangle(Pens.Red, roiRect);
            }
        }
        private void btnTemplateLoad_Click(object sender, EventArgs e) // 템플릿 로드
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "이미지 파일|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                templateImagePath = ofd.FileName;
                TemplateBox.Image =
                   Image.FromFile(templateImagePath);

                MessageBox.Show("템플릿 이미지 로드 완료");
            }
        }
        private void btnSaveROI_Click(object sender, EventArgs e) // ROI 좌표 저장
        {
            File.WriteAllText(
                           roiPath,
                            $"{roiRect.X},{roiRect.Y},{roiRect.Width},{roiRect.Height}"
              );
            MessageBox.Show("ROI 저장 완료");
        }
        private void btnLoadROI_Click(object sender, EventArgs e) // ROI 좌표 불러오기
        {
            if (!File.Exists(roiPath))
            {
                MessageBox.Show("저장된 ROI가 없습니다.");
                return;
            }

            string[] data = File.ReadAllText(roiPath).Split(',');

            roiRect = new Rectangle(
                int.Parse(data[0]),
                int.Parse(data[1]),
                int.Parse(data[2]),
                int.Parse(data[3])
            );
            ImgBox.Invalidate();
            MessageBox.Show("ROI 불러오기 완료");
        }
    }
}
