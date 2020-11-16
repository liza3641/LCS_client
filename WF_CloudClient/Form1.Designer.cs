namespace WF_CloudClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.File = new System.Windows.Forms.Button();
            this.File_Address = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.File_Upload = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_download = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "\"\"";
            this.openFileDialog1.InitialDirectory = "\"\"";
            // 
            // File
            // 
            this.File.Location = new System.Drawing.Point(260, 362);
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(100, 26);
            this.File.TabIndex = 1;
            this.File.Text = "파일 선택";
            this.File.UseVisualStyleBackColor = true;
            this.File.Click += new System.EventHandler(this.File_Select);
            // 
            // File_Address
            // 
            this.File_Address.Location = new System.Drawing.Point(22, 365);
            this.File_Address.Multiline = true;
            this.File_Address.Name = "File_Address";
            this.File_Address.ReadOnly = true;
            this.File_Address.Size = new System.Drawing.Size(200, 24);
            this.File_Address.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(22, 49);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(197, 259);
            this.listBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "파일 목록";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(260, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 26);
            this.button2.TabIndex = 7;
            this.button2.Text = "삭제";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.File_delete);
            // 
            // File_Upload
            // 
            this.File_Upload.Location = new System.Drawing.Point(260, 412);
            this.File_Upload.Name = "File_Upload";
            this.File_Upload.Size = new System.Drawing.Size(100, 26);
            this.File_Upload.TabIndex = 8;
            this.File_Upload.Text = "파일 업로드";
            this.File_Upload.UseVisualStyleBackColor = true;
            this.File_Upload.Click += new System.EventHandler(this.File_Upload_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 26);
            this.button1.TabIndex = 9;
            this.button1.Text = "새로고침";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.File_load_Click);
            // 
            // btn_download
            // 
            this.btn_download.Location = new System.Drawing.Point(260, 104);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(100, 26);
            this.btn_download.TabIndex = 10;
            this.btn_download.Text = "다운로드";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "파일 경로";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.File_Upload);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.File_Address);
            this.Controls.Add(this.File);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "클라우드";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button File;
        private System.Windows.Forms.TextBox File_Address;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button File_Upload;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Label label1;
    }
}

