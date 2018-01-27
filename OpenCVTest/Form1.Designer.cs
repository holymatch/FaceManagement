namespace OpenCVTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.imgCamUser = new Emgu.CV.UI.ImageBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtUsrename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.imageBoxCapturedImage = new Emgu.CV.UI.ImageBox();
            this.btnCheckFace = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.btnAddFace = new System.Windows.Forms.Button();
            this.txtErrorMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxCapturedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1413, 507);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "Capture Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imgCamUser
            // 
            this.imgCamUser.Location = new System.Drawing.Point(95, 92);
            this.imgCamUser.Name = "imgCamUser";
            this.imgCamUser.Size = new System.Drawing.Size(1114, 588);
            this.imgCamUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgCamUser.TabIndex = 2;
            this.imgCamUser.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1413, 558);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 42);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save Face";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtUsrename
            // 
            this.txtUsrename.Location = new System.Drawing.Point(1251, 386);
            this.txtUsrename.Name = "txtUsrename";
            this.txtUsrename.Size = new System.Drawing.Size(138, 29);
            this.txtUsrename.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1251, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1413, 606);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 42);
            this.button3.TabIndex = 6;
            this.button3.Text = "Recognize";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1413, 700);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 51);
            this.button4.TabIndex = 7;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1413, 654);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(133, 40);
            this.button5.TabIndex = 8;
            this.button5.Text = "Overlap Test";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1251, 507);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(139, 45);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start Preview";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // imageBoxCapturedImage
            // 
            this.imageBoxCapturedImage.Location = new System.Drawing.Point(1273, 92);
            this.imageBoxCapturedImage.Name = "imageBoxCapturedImage";
            this.imageBoxCapturedImage.Size = new System.Drawing.Size(252, 246);
            this.imageBoxCapturedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageBoxCapturedImage.TabIndex = 11;
            this.imageBoxCapturedImage.TabStop = false;
            // 
            // btnCheckFace
            // 
            this.btnCheckFace.Location = new System.Drawing.Point(1251, 558);
            this.btnCheckFace.Name = "btnCheckFace";
            this.btnCheckFace.Size = new System.Drawing.Size(138, 41);
            this.btnCheckFace.TabIndex = 12;
            this.btnCheckFace.Text = "Check Face";
            this.btnCheckFace.UseVisualStyleBackColor = true;
            this.btnCheckFace.Click += new System.EventHandler(this.btnCheckFace_ClickAsync);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1413, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Score";
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(1413, 386);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(133, 29);
            this.txtScore.TabIndex = 13;
            // 
            // btnAddFace
            // 
            this.btnAddFace.Location = new System.Drawing.Point(1251, 606);
            this.btnAddFace.Name = "btnAddFace";
            this.btnAddFace.Size = new System.Drawing.Size(139, 42);
            this.btnAddFace.TabIndex = 15;
            this.btnAddFace.Text = "Add Face";
            this.btnAddFace.UseVisualStyleBackColor = true;
            this.btnAddFace.Click += new System.EventHandler(this.btnAddFace_ClickAsync);
            // 
            // txtErrorMessage
            // 
            this.txtErrorMessage.Location = new System.Drawing.Point(95, 736);
            this.txtErrorMessage.Name = "txtErrorMessage";
            this.txtErrorMessage.Size = new System.Drawing.Size(1114, 29);
            this.txtErrorMessage.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 715);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "Error Message";
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(1251, 439);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(295, 62);
            this.txtDetail.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1251, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "Detail";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1571, 959);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtErrorMessage);
            this.Controls.Add(this.btnAddFace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.btnCheckFace);
            this.Controls.Add(this.imageBoxCapturedImage);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsrename);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.imgCamUser);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxCapturedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Emgu.CV.UI.ImageBox imgCamUser;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtUsrename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnStart;
        private Emgu.CV.UI.ImageBox imageBoxCapturedImage;
        private System.Windows.Forms.Button btnCheckFace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Button btnAddFace;
        private System.Windows.Forms.TextBox txtErrorMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Label label4;
    }
}

