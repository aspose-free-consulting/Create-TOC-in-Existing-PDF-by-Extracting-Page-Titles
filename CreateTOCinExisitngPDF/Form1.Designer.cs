namespace CreateTOCinExisitngPDF
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
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPDF = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnExtractTitles = new System.Windows.Forms.Button();
            this.btnCreateTOC = new System.Windows.Forms.Button();
            this.btnCreatePDF = new System.Windows.Forms.Button();
            this.lstTitles = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLicense
            // 
            this.txtLicense.Location = new System.Drawing.Point(32, 36);
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.ReadOnly = true;
            this.txtLicense.Size = new System.Drawing.Size(269, 20);
            this.txtLicense.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLicense);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 87);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select License File";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPDF);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(12, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 87);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select PDF File";
            // 
            // txtPDF
            // 
            this.txtPDF.Location = new System.Drawing.Point(32, 36);
            this.txtPDF.Name = "txtPDF";
            this.txtPDF.ReadOnly = true;
            this.txtPDF.Size = new System.Drawing.Size(269, 20);
            this.txtPDF.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(307, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExtractTitles
            // 
            this.btnExtractTitles.Location = new System.Drawing.Point(12, 198);
            this.btnExtractTitles.Name = "btnExtractTitles";
            this.btnExtractTitles.Size = new System.Drawing.Size(414, 23);
            this.btnExtractTitles.TabIndex = 5;
            this.btnExtractTitles.Text = "Extract First Phrase/Word from Each Page";
            this.btnExtractTitles.UseVisualStyleBackColor = true;
            this.btnExtractTitles.Click += new System.EventHandler(this.btnExtractTitles_Click);
            // 
            // btnCreateTOC
            // 
            this.btnCreateTOC.Location = new System.Drawing.Point(12, 390);
            this.btnCreateTOC.Name = "btnCreateTOC";
            this.btnCreateTOC.Size = new System.Drawing.Size(414, 23);
            this.btnCreateTOC.TabIndex = 7;
            this.btnCreateTOC.Text = "Create TOC in Selected PDF with Unique Titles";
            this.btnCreateTOC.UseVisualStyleBackColor = true;
            this.btnCreateTOC.Click += new System.EventHandler(this.btnCreateTOC_Click);
            // 
            // btnCreatePDF
            // 
            this.btnCreatePDF.Location = new System.Drawing.Point(12, 419);
            this.btnCreatePDF.Name = "btnCreatePDF";
            this.btnCreatePDF.Size = new System.Drawing.Size(414, 23);
            this.btnCreatePDF.TabIndex = 8;
            this.btnCreatePDF.Text = "Create Separate PDF file for lenghty Chapters and Create TOC for rest";
            this.btnCreatePDF.UseVisualStyleBackColor = true;
            this.btnCreatePDF.Click += new System.EventHandler(this.btnCreatePDF_Click);
            // 
            // lstTitles
            // 
            this.lstTitles.FormattingEnabled = true;
            this.lstTitles.Location = new System.Drawing.Point(12, 227);
            this.lstTitles.Name = "lstTitles";
            this.lstTitles.Size = new System.Drawing.Size(414, 160);
            this.lstTitles.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 454);
            this.Controls.Add(this.lstTitles);
            this.Controls.Add(this.btnCreatePDF);
            this.Controls.Add(this.btnCreateTOC);
            this.Controls.Add(this.btnExtractTitles);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create TOC in Existing PDF using Aspose.PDF for .NET";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPDF;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnExtractTitles;
        private System.Windows.Forms.Button btnCreateTOC;
        private System.Windows.Forms.Button btnCreatePDF;
        private System.Windows.Forms.ListBox lstTitles;
    }
}

