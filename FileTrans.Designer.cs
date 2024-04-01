namespace CHTools
{
    partial class FileTrans
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
            this.ToDocx = new System.Windows.Forms.RadioButton();
            this.ToXls = new System.Windows.Forms.RadioButton();
            this.ToXlsx = new System.Windows.Forms.RadioButton();
            this.ToDoc = new System.Windows.Forms.RadioButton();
            this.InputPathBox = new System.Windows.Forms.RichTextBox();
            this.ChooseBtn = new System.Windows.Forms.Button();
            this.TransBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ToDocx
            // 
            this.ToDocx.AutoSize = true;
            this.ToDocx.Location = new System.Drawing.Point(30, 23);
            this.ToDocx.Name = "ToDocx";
            this.ToDocx.Size = new System.Drawing.Size(115, 19);
            this.ToDocx.TabIndex = 0;
            this.ToDocx.TabStop = true;
            this.ToDocx.Text = "doc → docx";
            this.ToDocx.UseVisualStyleBackColor = true;
            // 
            // ToXls
            // 
            this.ToXls.AutoSize = true;
            this.ToXls.Location = new System.Drawing.Point(194, 46);
            this.ToXls.Name = "ToXls";
            this.ToXls.Size = new System.Drawing.Size(115, 19);
            this.ToXls.TabIndex = 1;
            this.ToXls.TabStop = true;
            this.ToXls.Text = "xlsx → xls";
            this.ToXls.UseVisualStyleBackColor = true;
            // 
            // ToXlsx
            // 
            this.ToXlsx.AutoSize = true;
            this.ToXlsx.Location = new System.Drawing.Point(30, 48);
            this.ToXlsx.Name = "ToXlsx";
            this.ToXlsx.Size = new System.Drawing.Size(115, 19);
            this.ToXlsx.TabIndex = 2;
            this.ToXlsx.TabStop = true;
            this.ToXlsx.Text = "xls → xlsx";
            this.ToXlsx.UseVisualStyleBackColor = true;
            // 
            // ToDoc
            // 
            this.ToDoc.AutoSize = true;
            this.ToDoc.Location = new System.Drawing.Point(194, 21);
            this.ToDoc.Name = "ToDoc";
            this.ToDoc.Size = new System.Drawing.Size(115, 19);
            this.ToDoc.TabIndex = 3;
            this.ToDoc.TabStop = true;
            this.ToDoc.Text = "docx → doc";
            this.ToDoc.UseVisualStyleBackColor = true;
            // 
            // InputPathBox
            // 
            this.InputPathBox.Location = new System.Drawing.Point(30, 82);
            this.InputPathBox.Name = "InputPathBox";
            this.InputPathBox.Size = new System.Drawing.Size(279, 114);
            this.InputPathBox.TabIndex = 4;
            this.InputPathBox.Text = "";
            // 
            // ChooseBtn
            // 
            this.ChooseBtn.Location = new System.Drawing.Point(43, 211);
            this.ChooseBtn.Name = "ChooseBtn";
            this.ChooseBtn.Size = new System.Drawing.Size(89, 28);
            this.ChooseBtn.TabIndex = 5;
            this.ChooseBtn.Text = "选择文件";
            this.ChooseBtn.UseVisualStyleBackColor = true;
            this.ChooseBtn.Click += new System.EventHandler(this.ChooseBtn_Click);
            // 
            // TransBtn
            // 
            this.TransBtn.Location = new System.Drawing.Point(205, 211);
            this.TransBtn.Name = "TransBtn";
            this.TransBtn.Size = new System.Drawing.Size(89, 28);
            this.TransBtn.TabIndex = 6;
            this.TransBtn.Text = "转换文件";
            this.TransBtn.UseVisualStyleBackColor = true;
            this.TransBtn.Click += new System.EventHandler(this.TransBtn_Click);
            // 
            // FileTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 253);
            this.Controls.Add(this.TransBtn);
            this.Controls.Add(this.ChooseBtn);
            this.Controls.Add(this.InputPathBox);
            this.Controls.Add(this.ToDoc);
            this.Controls.Add(this.ToXlsx);
            this.Controls.Add(this.ToXls);
            this.Controls.Add(this.ToDocx);
            this.Name = "FileTrans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件格式批量转换";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton ToDocx;
        private System.Windows.Forms.RadioButton ToXls;
        private System.Windows.Forms.RadioButton ToXlsx;
        private System.Windows.Forms.RadioButton ToDoc;
        private System.Windows.Forms.RichTextBox InputPathBox;
        private System.Windows.Forms.Button ChooseBtn;
        private System.Windows.Forms.Button TransBtn;
    }
}