namespace OpenCVTest
{
    partial class ImportFace
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
            this.BtnOpenFolder = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.LstImage = new System.Windows.Forms.ListBox();
            this.BtnImport = new System.Windows.Forms.Button();
            this.LstFailBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // BtnOpenFolder
            // 
            this.BtnOpenFolder.Location = new System.Drawing.Point(598, 322);
            this.BtnOpenFolder.Name = "BtnOpenFolder";
            this.BtnOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.BtnOpenFolder.TabIndex = 0;
            this.BtnOpenFolder.Text = "Open Folder";
            this.BtnOpenFolder.UseVisualStyleBackColor = true;
            this.BtnOpenFolder.Click += new System.EventHandler(this.BtnOpenFolder_Click);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(12, 325);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(580, 20);
            this.txtFolderPath.TabIndex = 1;
            // 
            // LstImage
            // 
            this.LstImage.FormattingEnabled = true;
            this.LstImage.Location = new System.Drawing.Point(12, 14);
            this.LstImage.Name = "LstImage";
            this.LstImage.Size = new System.Drawing.Size(289, 303);
            this.LstImage.TabIndex = 2;
            // 
            // BtnImport
            // 
            this.BtnImport.Location = new System.Drawing.Point(598, 293);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(75, 23);
            this.BtnImport.TabIndex = 3;
            this.BtnImport.Text = "Import";
            this.BtnImport.UseVisualStyleBackColor = true;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // LstFailBox
            // 
            this.LstFailBox.FormattingEnabled = true;
            this.LstFailBox.Location = new System.Drawing.Point(307, 14);
            this.LstFailBox.Name = "LstFailBox";
            this.LstFailBox.Size = new System.Drawing.Size(285, 303);
            this.LstFailBox.TabIndex = 4;
            // 
            // ImportFace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 357);
            this.Controls.Add(this.LstFailBox);
            this.Controls.Add(this.BtnImport);
            this.Controls.Add(this.LstImage);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.BtnOpenFolder);
            this.Name = "ImportFace";
            this.Text = "ImportFace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnOpenFolder;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.ListBox LstImage;
        private System.Windows.Forms.Button BtnImport;
        private System.Windows.Forms.ListBox LstFailBox;
    }
}