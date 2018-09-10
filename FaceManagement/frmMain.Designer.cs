namespace FaceManagement
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.BtnCaptureFace = new System.Windows.Forms.Button();
            this.ImgCamUser = new Emgu.CV.UI.ImageBox();
            this.BtnDeletePerson = new System.Windows.Forms.Button();
            this.txtUsrename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.BtnStartPreview = new System.Windows.Forms.Button();
            this.ImageBoxCapturedImage = new Emgu.CV.UI.ImageBox();
            this.BtnCheckFace = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.BtnSaveFace = new System.Windows.Forms.Button();
            this.TxtErrorMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnListPeople = new System.Windows.Forms.Button();
            this.LvFaceList = new System.Windows.Forms.ListView();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnImportImage = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServerURL = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCamUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxCapturedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCaptureFace
            // 
            this.BtnCaptureFace.Location = new System.Drawing.Point(1951, 574);
            this.BtnCaptureFace.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCaptureFace.Name = "BtnCaptureFace";
            this.BtnCaptureFace.Size = new System.Drawing.Size(163, 59);
            this.BtnCaptureFace.TabIndex = 0;
            this.BtnCaptureFace.Text = "Capture Face";
            this.BtnCaptureFace.UseVisualStyleBackColor = true;
            this.BtnCaptureFace.Click += new System.EventHandler(this.BtnCaptureFace_Click);
            // 
            // ImgCamUser
            // 
            this.ImgCamUser.Location = new System.Drawing.Point(20, 20);
            this.ImgCamUser.Margin = new System.Windows.Forms.Padding(4);
            this.ImgCamUser.Name = "ImgCamUser";
            this.ImgCamUser.Size = new System.Drawing.Size(1247, 886);
            this.ImgCamUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ImgCamUser.TabIndex = 2;
            this.ImgCamUser.TabStop = false;
            // 
            // BtnDeletePerson
            // 
            this.BtnDeletePerson.Location = new System.Drawing.Point(1951, 642);
            this.BtnDeletePerson.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDeletePerson.Name = "BtnDeletePerson";
            this.BtnDeletePerson.Size = new System.Drawing.Size(163, 55);
            this.BtnDeletePerson.TabIndex = 3;
            this.BtnDeletePerson.Text = "Remove";
            this.BtnDeletePerson.UseVisualStyleBackColor = true;
            this.BtnDeletePerson.Click += new System.EventHandler(this.BtnDeletePerson_Click);
            // 
            // txtUsrename
            // 
            this.txtUsrename.Location = new System.Drawing.Point(1753, 414);
            this.txtUsrename.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsrename.Name = "txtUsrename";
            this.txtUsrename.Size = new System.Drawing.Size(167, 29);
            this.txtUsrename.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1764, 386);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1951, 707);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 55);
            this.button3.TabIndex = 6;
            this.button3.Text = "Recognize";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1951, 833);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(163, 55);
            this.button4.TabIndex = 7;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1951, 770);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(163, 54);
            this.button5.TabIndex = 8;
            this.button5.Text = "Overlap Test";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // BtnStartPreview
            // 
            this.BtnStartPreview.Location = new System.Drawing.Point(1753, 574);
            this.BtnStartPreview.Margin = new System.Windows.Forms.Padding(4);
            this.BtnStartPreview.Name = "BtnStartPreview";
            this.BtnStartPreview.Size = new System.Drawing.Size(171, 59);
            this.BtnStartPreview.TabIndex = 10;
            this.BtnStartPreview.Text = "Preview";
            this.BtnStartPreview.UseVisualStyleBackColor = true;
            this.BtnStartPreview.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // ImageBoxCapturedImage
            // 
            this.ImageBoxCapturedImage.Location = new System.Drawing.Point(1780, 20);
            this.ImageBoxCapturedImage.Margin = new System.Windows.Forms.Padding(4);
            this.ImageBoxCapturedImage.Name = "ImageBoxCapturedImage";
            this.ImageBoxCapturedImage.Size = new System.Drawing.Size(308, 329);
            this.ImageBoxCapturedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ImageBoxCapturedImage.TabIndex = 11;
            this.ImageBoxCapturedImage.TabStop = false;
            // 
            // BtnCheckFace
            // 
            this.BtnCheckFace.Location = new System.Drawing.Point(1753, 642);
            this.BtnCheckFace.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCheckFace.Name = "BtnCheckFace";
            this.BtnCheckFace.Size = new System.Drawing.Size(169, 55);
            this.BtnCheckFace.TabIndex = 12;
            this.BtnCheckFace.Text = "Check Face";
            this.BtnCheckFace.UseVisualStyleBackColor = true;
            this.BtnCheckFace.Click += new System.EventHandler(this.BtnCheckFace_ClickAsync);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1956, 386);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Score";
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(1951, 414);
            this.txtScore.Margin = new System.Windows.Forms.Padding(4);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(162, 29);
            this.txtScore.TabIndex = 13;
            // 
            // BtnSaveFace
            // 
            this.BtnSaveFace.Location = new System.Drawing.Point(1753, 707);
            this.BtnSaveFace.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSaveFace.Name = "BtnSaveFace";
            this.BtnSaveFace.Size = new System.Drawing.Size(171, 55);
            this.BtnSaveFace.TabIndex = 15;
            this.BtnSaveFace.Text = "Save Person";
            this.BtnSaveFace.UseVisualStyleBackColor = true;
            this.BtnSaveFace.Click += new System.EventHandler(this.BtnAddFace_ClickAsync);
            // 
            // TxtErrorMessage
            // 
            this.TxtErrorMessage.Location = new System.Drawing.Point(20, 938);
            this.TxtErrorMessage.Margin = new System.Windows.Forms.Padding(4);
            this.TxtErrorMessage.Name = "TxtErrorMessage";
            this.TxtErrorMessage.Size = new System.Drawing.Size(1247, 29);
            this.TxtErrorMessage.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 908);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "System Message";
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(1753, 484);
            this.txtDetail.Margin = new System.Windows.Forms.Padding(4);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(360, 82);
            this.txtDetail.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1764, 454);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Detail";
            // 
            // BtnListPeople
            // 
            this.BtnListPeople.Location = new System.Drawing.Point(1753, 833);
            this.BtnListPeople.Margin = new System.Windows.Forms.Padding(4);
            this.BtnListPeople.Name = "BtnListPeople";
            this.BtnListPeople.Size = new System.Drawing.Size(171, 55);
            this.BtnListPeople.TabIndex = 21;
            this.BtnListPeople.Text = "List People";
            this.BtnListPeople.UseVisualStyleBackColor = true;
            this.BtnListPeople.Click += new System.EventHandler(this.BtnListPeople_Click);
            // 
            // LvFaceList
            // 
            this.LvFaceList.Location = new System.Drawing.Point(1276, 20);
            this.LvFaceList.Margin = new System.Windows.Forms.Padding(6);
            this.LvFaceList.MultiSelect = false;
            this.LvFaceList.Name = "LvFaceList";
            this.LvFaceList.Size = new System.Drawing.Size(464, 883);
            this.LvFaceList.TabIndex = 20;
            this.LvFaceList.UseCompatibleStateImageBehavior = false;
            this.LvFaceList.SelectedIndexChanged += new System.EventHandler(this.LvFaceList_SelectedIndexChanged);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(1753, 770);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(171, 55);
            this.BtnCancel.TabIndex = 22;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnImportImage
            // 
            this.BtnImportImage.Location = new System.Drawing.Point(1951, 707);
            this.BtnImportImage.Margin = new System.Windows.Forms.Padding(4);
            this.BtnImportImage.Name = "BtnImportImage";
            this.BtnImportImage.Size = new System.Drawing.Size(163, 55);
            this.BtnImportImage.TabIndex = 23;
            this.BtnImportImage.Text = "Import image";
            this.BtnImportImage.UseVisualStyleBackColor = true;
            this.BtnImportImage.Click += new System.EventHandler(this.BtnImportImage_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1274, 908);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(263, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "Face Information Server URL";
            // 
            // txtServerURL
            // 
            this.txtServerURL.Location = new System.Drawing.Point(1280, 938);
            this.txtServerURL.Margin = new System.Windows.Forms.Padding(4);
            this.txtServerURL.Name = "txtServerURL";
            this.txtServerURL.Size = new System.Drawing.Size(835, 29);
            this.txtServerURL.TabIndex = 25;
            this.txtServerURL.Leave += new System.EventHandler(this.txtServerURL_Leave);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1923, 999);
            this.Controls.Add(this.txtServerURL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnImportImage);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnListPeople);
            this.Controls.Add(this.LvFaceList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtErrorMessage);
            this.Controls.Add(this.BtnSaveFace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.BtnCheckFace);
            this.Controls.Add(this.ImageBoxCapturedImage);
            this.Controls.Add(this.BtnStartPreview);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsrename);
            this.Controls.Add(this.BtnDeletePerson);
            this.Controls.Add(this.ImgCamUser);
            this.Controls.Add(this.BtnCaptureFace);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.Text = "Client for Face Management";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImgCamUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxCapturedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCaptureFace;
        private Emgu.CV.UI.ImageBox ImgCamUser;
        private System.Windows.Forms.Button BtnDeletePerson;
        private System.Windows.Forms.TextBox txtUsrename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button BtnStartPreview;
        private Emgu.CV.UI.ImageBox ImageBoxCapturedImage;
        private System.Windows.Forms.Button BtnCheckFace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Button BtnSaveFace;
        private System.Windows.Forms.TextBox TxtErrorMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnListPeople;
        private System.Windows.Forms.ListView LvFaceList;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnImportImage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtServerURL;
    }
}

