namespace Han
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.ImgBox = new System.Windows.Forms.PictureBox();
            this.btnimgLoad = new System.Windows.Forms.Button();
            this.btninspect = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.lblSimilarity = new System.Windows.Forms.Label();
            this.btnTemplateLoad = new System.Windows.Forms.Button();
            this.btnSaveROI = new System.Windows.Forms.Button();
            this.btnLoadROI = new System.Windows.Forms.Button();
            this.txtThreshold = new System.Windows.Forms.TextBox();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.TemplateBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ImgBox
            // 
            this.ImgBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImgBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImgBox.Location = new System.Drawing.Point(1, 0);
            this.ImgBox.Name = "ImgBox";
            this.ImgBox.Size = new System.Drawing.Size(770, 420);
            this.ImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgBox.TabIndex = 0;
            this.ImgBox.TabStop = false;
            this.ImgBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ImgBox_Paint);
            this.ImgBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBox_MouseDown);
            this.ImgBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImgBox_MouseMove);
            this.ImgBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBox_MouseUp);
            // 
            // btnimgLoad
            // 
            this.btnimgLoad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnimgLoad.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.btnimgLoad.Location = new System.Drawing.Point(649, 514);
            this.btnimgLoad.Name = "btnimgLoad";
            this.btnimgLoad.Size = new System.Drawing.Size(200, 75);
            this.btnimgLoad.TabIndex = 1;
            this.btnimgLoad.Text = "이미지 불러오기";
            this.btnimgLoad.UseVisualStyleBackColor = false;
            this.btnimgLoad.Click += new System.EventHandler(this.btnimgLoad_Click);
            // 
            // btninspect
            // 
            this.btninspect.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btninspect.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btninspect.Location = new System.Drawing.Point(788, 435);
            this.btninspect.Name = "btninspect";
            this.btninspect.Size = new System.Drawing.Size(200, 50);
            this.btninspect.TabIndex = 2;
            this.btninspect.Text = "검사";
            this.btninspect.UseVisualStyleBackColor = false;
            this.btninspect.Click += new System.EventHandler(this.btninspect_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblResult.ForeColor = System.Drawing.Color.Blue;
            this.lblResult.Location = new System.Drawing.Point(508, 423);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(182, 67);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "READY";
            // 
            // dgvLog
            // 
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Location = new System.Drawing.Point(50, 514);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.RowHeadersWidth = 51;
            this.dgvLog.Size = new System.Drawing.Size(500, 200);
            this.dgvLog.TabIndex = 4;
            // 
            // lblSimilarity
            // 
            this.lblSimilarity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSimilarity.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSimilarity.Location = new System.Drawing.Point(273, 439);
            this.lblSimilarity.Name = "lblSimilarity";
            this.lblSimilarity.Size = new System.Drawing.Size(202, 50);
            this.lblSimilarity.TabIndex = 5;
            this.lblSimilarity.Text = "유사도/기존유사도";
            this.lblSimilarity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTemplateLoad
            // 
            this.btnTemplateLoad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTemplateLoad.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.btnTemplateLoad.Location = new System.Drawing.Point(923, 514);
            this.btnTemplateLoad.Name = "btnTemplateLoad";
            this.btnTemplateLoad.Size = new System.Drawing.Size(200, 75);
            this.btnTemplateLoad.TabIndex = 6;
            this.btnTemplateLoad.Text = "템플릿 불러오기";
            this.btnTemplateLoad.UseVisualStyleBackColor = false;
            this.btnTemplateLoad.Click += new System.EventHandler(this.btnTemplateLoad_Click);
            // 
            // btnSaveROI
            // 
            this.btnSaveROI.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSaveROI.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.btnSaveROI.Location = new System.Drawing.Point(649, 636);
            this.btnSaveROI.Name = "btnSaveROI";
            this.btnSaveROI.Size = new System.Drawing.Size(200, 75);
            this.btnSaveROI.TabIndex = 7;
            this.btnSaveROI.Text = "ROI저장";
            this.btnSaveROI.UseVisualStyleBackColor = false;
            this.btnSaveROI.Click += new System.EventHandler(this.btnSaveROI_Click);
            // 
            // btnLoadROI
            // 
            this.btnLoadROI.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLoadROI.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.btnLoadROI.Location = new System.Drawing.Point(923, 636);
            this.btnLoadROI.Name = "btnLoadROI";
            this.btnLoadROI.Size = new System.Drawing.Size(200, 75);
            this.btnLoadROI.TabIndex = 8;
            this.btnLoadROI.Text = "ROI불러오기";
            this.btnLoadROI.UseVisualStyleBackColor = false;
            this.btnLoadROI.Click += new System.EventHandler(this.btnLoadROI_Click);
            // 
            // txtThreshold
            // 
            this.txtThreshold.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtThreshold.Location = new System.Drawing.Point(137, 453);
            this.txtThreshold.Name = "txtThreshold";
            this.txtThreshold.Size = new System.Drawing.Size(100, 27);
            this.txtThreshold.TabIndex = 9;
            this.txtThreshold.Text = "0.80";
            this.txtThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblThreshold.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblThreshold.Location = new System.Drawing.Point(27, 456);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(104, 20);
            this.lblThreshold.TabIndex = 10;
            this.lblThreshold.Text = "유사도 기준값";
            // 
            // TemplateBox
            // 
            this.TemplateBox.BackColor = System.Drawing.Color.Transparent;
            this.TemplateBox.Location = new System.Drawing.Point(777, 12);
            this.TemplateBox.Name = "TemplateBox";
            this.TemplateBox.Size = new System.Drawing.Size(400, 400);
            this.TemplateBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TemplateBox.TabIndex = 11;
            this.TemplateBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.TemplateBox);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.txtThreshold);
            this.Controls.Add(this.btnLoadROI);
            this.Controls.Add(this.btnSaveROI);
            this.Controls.Add(this.btnTemplateLoad);
            this.Controls.Add(this.lblSimilarity);
            this.Controls.Add(this.dgvLog);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btninspect);
            this.Controls.Add(this.btnimgLoad);
            this.Controls.Add(this.ImgBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImgBox;
        private System.Windows.Forms.Button btnimgLoad;
        private System.Windows.Forms.Button btninspect;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.Label lblSimilarity;
        private System.Windows.Forms.Button btnTemplateLoad;
        private System.Windows.Forms.Button btnSaveROI;
        private System.Windows.Forms.Button btnLoadROI;
        private System.Windows.Forms.TextBox txtThreshold;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.PictureBox TemplateBox;
    }
}

