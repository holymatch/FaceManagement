namespace OpenCVTest
{
    partial class frmOverlapTest
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
            this.imgBG = new Emgu.CV.UI.ImageBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtX1 = new System.Windows.Forms.TextBox();
            this.txtHeight1 = new System.Windows.Forms.TextBox();
            this.txtY1 = new System.Windows.Forms.TextBox();
            this.txtWidth1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWidth2 = new System.Windows.Forms.TextBox();
            this.txtY2 = new System.Windows.Forms.TextBox();
            this.txtHeight2 = new System.Windows.Forms.TextBox();
            this.txtX2 = new System.Windows.Forms.TextBox();
            this.lblOverlap = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgBG)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBG
            // 
            this.imgBG.Location = new System.Drawing.Point(38, 37);
            this.imgBG.Name = "imgBG";
            this.imgBG.Size = new System.Drawing.Size(1282, 736);
            this.imgBG.TabIndex = 3;
            this.imgBG.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1381, 503);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 46);
            this.button1.TabIndex = 8;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtX1
            // 
            this.txtX1.Location = new System.Drawing.Point(1352, 129);
            this.txtX1.Name = "txtX1";
            this.txtX1.Size = new System.Drawing.Size(100, 29);
            this.txtX1.TabIndex = 0;
            this.txtX1.Text = "10";
            // 
            // txtHeight1
            // 
            this.txtHeight1.Location = new System.Drawing.Point(1352, 186);
            this.txtHeight1.Name = "txtHeight1";
            this.txtHeight1.Size = new System.Drawing.Size(100, 29);
            this.txtHeight1.TabIndex = 2;
            this.txtHeight1.Text = "20";
            // 
            // txtY1
            // 
            this.txtY1.Location = new System.Drawing.Point(1458, 129);
            this.txtY1.Name = "txtY1";
            this.txtY1.Size = new System.Drawing.Size(100, 29);
            this.txtY1.TabIndex = 1;
            this.txtY1.Text = "10";
            // 
            // txtWidth1
            // 
            this.txtWidth1.Location = new System.Drawing.Point(1458, 186);
            this.txtWidth1.Name = "txtWidth1";
            this.txtWidth1.Size = new System.Drawing.Size(100, 29);
            this.txtWidth1.TabIndex = 3;
            this.txtWidth1.Text = "20";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1349, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "X1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1458, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Y1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1352, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Height1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1458, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Width1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1458, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "Width2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1352, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "Height2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1458, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "Y2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1349, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 18);
            this.label8.TabIndex = 17;
            this.label8.Text = "X2";
            // 
            // txtWidth2
            // 
            this.txtWidth2.Location = new System.Drawing.Point(1458, 315);
            this.txtWidth2.Name = "txtWidth2";
            this.txtWidth2.Size = new System.Drawing.Size(100, 29);
            this.txtWidth2.TabIndex = 7;
            this.txtWidth2.Text = "20";
            // 
            // txtY2
            // 
            this.txtY2.Location = new System.Drawing.Point(1458, 258);
            this.txtY2.Name = "txtY2";
            this.txtY2.Size = new System.Drawing.Size(100, 29);
            this.txtY2.TabIndex = 5;
            this.txtY2.Text = "50";
            // 
            // txtHeight2
            // 
            this.txtHeight2.Location = new System.Drawing.Point(1352, 315);
            this.txtHeight2.Name = "txtHeight2";
            this.txtHeight2.Size = new System.Drawing.Size(100, 29);
            this.txtHeight2.TabIndex = 6;
            this.txtHeight2.Text = "20";
            // 
            // txtX2
            // 
            this.txtX2.Location = new System.Drawing.Point(1352, 258);
            this.txtX2.Name = "txtX2";
            this.txtX2.Size = new System.Drawing.Size(100, 29);
            this.txtX2.TabIndex = 4;
            this.txtX2.Text = "50";
            // 
            // lblOverlap
            // 
            this.lblOverlap.AutoSize = true;
            this.lblOverlap.Location = new System.Drawing.Point(1471, 408);
            this.lblOverlap.Name = "lblOverlap";
            this.lblOverlap.Size = new System.Drawing.Size(46, 18);
            this.lblOverlap.TabIndex = 21;
            this.lblOverlap.Text = "100%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1352, 408);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 18);
            this.label9.TabIndex = 22;
            this.label9.Text = "Overlap Size : ";
            // 
            // frmOverlapTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1593, 898);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblOverlap);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtWidth2);
            this.Controls.Add(this.txtY2);
            this.Controls.Add(this.txtHeight2);
            this.Controls.Add(this.txtX2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWidth1);
            this.Controls.Add(this.txtY1);
            this.Controls.Add(this.txtHeight1);
            this.Controls.Add(this.txtX1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imgBG);
            this.Name = "frmOverlapTest";
            this.Text = "frmOverlapTest";
            ((System.ComponentModel.ISupportInitialize)(this.imgBG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgBG;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtX1;
        private System.Windows.Forms.TextBox txtHeight1;
        private System.Windows.Forms.TextBox txtY1;
        private System.Windows.Forms.TextBox txtWidth1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtWidth2;
        private System.Windows.Forms.TextBox txtY2;
        private System.Windows.Forms.TextBox txtHeight2;
        private System.Windows.Forms.TextBox txtX2;
        private System.Windows.Forms.Label lblOverlap;
        private System.Windows.Forms.Label label9;
    }
}