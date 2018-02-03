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
            this.btnCaptureFace = new System.Windows.Forms.Button();
            this.imgCamUser = new Emgu.CV.UI.ImageBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtUsrename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnStartPreview = new System.Windows.Forms.Button();
            this.imageBoxCapturedImage = new Emgu.CV.UI.ImageBox();
            this.btnCheckFace = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.btnSaveFace = new System.Windows.Forms.Button();
            this.txtErrorMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnListPeople = new System.Windows.Forms.Button();
            this.lvFaceList = new System.Windows.Forms.ListView();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxCapturedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCaptureFace
            // 
            this.btnCaptureFace.Location = new System.Drawing.Point(1064, 311);
            this.btnCaptureFace.Margin = new System.Windows.Forms.Padding(2);
            this.btnCaptureFace.Name = "btnCaptureFace";
            this.btnCaptureFace.Size = new System.Drawing.Size(89, 32);
            this.btnCaptureFace.TabIndex = 0;
            this.btnCaptureFace.Text = "Capture Face";
            this.btnCaptureFace.UseVisualStyleBackColor = true;
            this.btnCaptureFace.Click += new System.EventHandler(this.button1_Click);
            // 
            // imgCamUser
            // 
            this.imgCamUser.Location = new System.Drawing.Point(11, 11);
            this.imgCamUser.Margin = new System.Windows.Forms.Padding(2);
            this.imgCamUser.Name = "imgCamUser";
            this.imgCamUser.Size = new System.Drawing.Size(680, 480);
            this.imgCamUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgCamUser.TabIndex = 2;
            this.imgCamUser.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1064, 348);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 30);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save Face";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtUsrename
            // 
            this.txtUsrename.Location = new System.Drawing.Point(956, 224);
            this.txtUsrename.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsrename.Name = "txtUsrename";
            this.txtUsrename.Size = new System.Drawing.Size(93, 20);
            this.txtUsrename.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(956, 206);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1064, 383);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 30);
            this.button3.TabIndex = 6;
            this.button3.Text = "Recognize";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1064, 451);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 37);
            this.button4.TabIndex = 7;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1064, 417);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 29);
            this.button5.TabIndex = 8;
            this.button5.Text = "Overlap Test";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnStartPreview
            // 
            this.btnStartPreview.Location = new System.Drawing.Point(956, 311);
            this.btnStartPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartPreview.Name = "btnStartPreview";
            this.btnStartPreview.Size = new System.Drawing.Size(93, 32);
            this.btnStartPreview.TabIndex = 10;
            this.btnStartPreview.Text = "New Person";
            this.btnStartPreview.UseVisualStyleBackColor = true;
            this.btnStartPreview.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // imageBoxCapturedImage
            // 
            this.imageBoxCapturedImage.Location = new System.Drawing.Point(971, 11);
            this.imageBoxCapturedImage.Margin = new System.Windows.Forms.Padding(2);
            this.imageBoxCapturedImage.Name = "imageBoxCapturedImage";
            this.imageBoxCapturedImage.Size = new System.Drawing.Size(168, 178);
            this.imageBoxCapturedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageBoxCapturedImage.TabIndex = 11;
            this.imageBoxCapturedImage.TabStop = false;
            // 
            // btnCheckFace
            // 
            this.btnCheckFace.Location = new System.Drawing.Point(956, 348);
            this.btnCheckFace.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckFace.Name = "btnCheckFace";
            this.btnCheckFace.Size = new System.Drawing.Size(92, 30);
            this.btnCheckFace.TabIndex = 12;
            this.btnCheckFace.Text = "Check Face";
            this.btnCheckFace.UseVisualStyleBackColor = true;
            this.btnCheckFace.Click += new System.EventHandler(this.btnCheckFace_ClickAsync);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1064, 206);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Score";
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(1064, 224);
            this.txtScore.Margin = new System.Windows.Forms.Padding(2);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(90, 20);
            this.txtScore.TabIndex = 13;
            // 
            // btnSaveFace
            // 
            this.btnSaveFace.Location = new System.Drawing.Point(956, 383);
            this.btnSaveFace.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveFace.Name = "btnSaveFace";
            this.btnSaveFace.Size = new System.Drawing.Size(93, 30);
            this.btnSaveFace.TabIndex = 15;
            this.btnSaveFace.Text = "Save Person";
            this.btnSaveFace.UseVisualStyleBackColor = true;
            this.btnSaveFace.Click += new System.EventHandler(this.btnAddFace_ClickAsync);
            // 
            // txtErrorMessage
            // 
            this.txtErrorMessage.Location = new System.Drawing.Point(11, 508);
            this.txtErrorMessage.Margin = new System.Windows.Forms.Padding(2);
            this.txtErrorMessage.Name = "txtErrorMessage";
            this.txtErrorMessage.Size = new System.Drawing.Size(1143, 20);
            this.txtErrorMessage.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 493);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "System Message";
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(956, 262);
            this.txtDetail.Margin = new System.Windows.Forms.Padding(2);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(198, 46);
            this.txtDetail.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(956, 247);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Detail";
            // 
            // btnListPeople
            // 
            this.btnListPeople.Location = new System.Drawing.Point(956, 451);
            this.btnListPeople.Margin = new System.Windows.Forms.Padding(2);
            this.btnListPeople.Name = "btnListPeople";
            this.btnListPeople.Size = new System.Drawing.Size(93, 30);
            this.btnListPeople.TabIndex = 21;
            this.btnListPeople.Text = "List People";
            this.btnListPeople.UseVisualStyleBackColor = true;
            this.btnListPeople.Click += new System.EventHandler(this.btnListPeople_Click);
            // 
            // lvFaceList
            // 
            this.lvFaceList.Location = new System.Drawing.Point(696, 11);
            this.lvFaceList.MultiSelect = false;
            this.lvFaceList.Name = "lvFaceList";
            this.lvFaceList.Size = new System.Drawing.Size(255, 480);
            this.lvFaceList.TabIndex = 20;
            this.lvFaceList.UseCompatibleStateImageBehavior = false;
            this.lvFaceList.SelectedIndexChanged += new System.EventHandler(this.lvFaceList_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(956, 417);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 30);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 538);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnListPeople);
            this.Controls.Add(this.lvFaceList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtErrorMessage);
            this.Controls.Add(this.btnSaveFace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.btnCheckFace);
            this.Controls.Add(this.imageBoxCapturedImage);
            this.Controls.Add(this.btnStartPreview);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsrename);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.imgCamUser);
            this.Controls.Add(this.btnCaptureFace);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "OpenCV Test";
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxCapturedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCaptureFace;
        private Emgu.CV.UI.ImageBox imgCamUser;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtUsrename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnStartPreview;
        private Emgu.CV.UI.ImageBox imageBoxCapturedImage;
        private System.Windows.Forms.Button btnCheckFace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Button btnSaveFace;
        private System.Windows.Forms.TextBox txtErrorMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnListPeople;
        private System.Windows.Forms.ListView lvFaceList;
        private System.Windows.Forms.Button btnCancel;
    }
}

