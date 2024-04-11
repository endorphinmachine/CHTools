namespace CHTools
{
    partial class Photo
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
            this.NorthPicture = new System.Windows.Forms.PictureBox();
            this.SouthPicture = new System.Windows.Forms.PictureBox();
            this.EastPicture = new System.Windows.Forms.PictureBox();
            this.WestPicture = new System.Windows.Forms.PictureBox();
            this.NumberBox = new System.Windows.Forms.TextBox();
            this.PhotographerBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ImportBtn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.SaveBox = new System.Windows.Forms.TextBox();
            this.FindBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NorthPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SouthPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EastPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WestPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // NorthPicture
            // 
            this.NorthPicture.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.NorthPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.NorthPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NorthPicture.Location = new System.Drawing.Point(147, 12);
            this.NorthPicture.Name = "NorthPicture";
            this.NorthPicture.Size = new System.Drawing.Size(120, 160);
            this.NorthPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NorthPicture.TabIndex = 0;
            this.NorthPicture.TabStop = false;
            this.NorthPicture.DragDrop += new System.Windows.Forms.DragEventHandler(this.NorthPicture_DragDrop);
            this.NorthPicture.DragEnter += new System.Windows.Forms.DragEventHandler(this.NorthPicture_DragEnter);
            // 
            // SouthPicture
            // 
            this.SouthPicture.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SouthPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SouthPicture.Location = new System.Drawing.Point(146, 348);
            this.SouthPicture.Name = "SouthPicture";
            this.SouthPicture.Size = new System.Drawing.Size(120, 160);
            this.SouthPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SouthPicture.TabIndex = 1;
            this.SouthPicture.TabStop = false;
            this.SouthPicture.DragDrop += new System.Windows.Forms.DragEventHandler(this.SouthPicture_DragDrop);
            this.SouthPicture.DragEnter += new System.Windows.Forms.DragEventHandler(this.SouthPicture_DragEnter);
            // 
            // EastPicture
            // 
            this.EastPicture.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.EastPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EastPicture.Location = new System.Drawing.Point(271, 179);
            this.EastPicture.Name = "EastPicture";
            this.EastPicture.Size = new System.Drawing.Size(120, 160);
            this.EastPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EastPicture.TabIndex = 2;
            this.EastPicture.TabStop = false;
            this.EastPicture.DragDrop += new System.Windows.Forms.DragEventHandler(this.EastPicture_DragDrop);
            this.EastPicture.DragEnter += new System.Windows.Forms.DragEventHandler(this.EastPicture_DragEnter);
            // 
            // WestPicture
            // 
            this.WestPicture.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.WestPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WestPicture.Location = new System.Drawing.Point(21, 179);
            this.WestPicture.Name = "WestPicture";
            this.WestPicture.Size = new System.Drawing.Size(120, 160);
            this.WestPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WestPicture.TabIndex = 3;
            this.WestPicture.TabStop = false;
            this.WestPicture.DragDrop += new System.Windows.Forms.DragEventHandler(this.WestPicture_DragDrop);
            this.WestPicture.DragEnter += new System.Windows.Forms.DragEventHandler(this.WestPicture_DragEnter);
            // 
            // NumberBox
            // 
            this.NumberBox.Location = new System.Drawing.Point(484, 18);
            this.NumberBox.Name = "NumberBox";
            this.NumberBox.Size = new System.Drawing.Size(170, 25);
            this.NumberBox.TabIndex = 4;
            // 
            // PhotographerBox
            // 
            this.PhotographerBox.Location = new System.Drawing.Point(484, 95);
            this.PhotographerBox.Name = "PhotographerBox";
            this.PhotographerBox.Size = new System.Drawing.Size(170, 25);
            this.PhotographerBox.TabIndex = 5;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(484, 135);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(170, 25);
            this.dateTimePicker.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(398, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "工程编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "拍摄者：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "拍摄时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "北";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(195, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "南";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(144, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "西";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(244, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "东";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 7F);
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label8.Location = new System.Drawing.Point(149, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "将照片拖拽至此处";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 7F);
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label9.Location = new System.Drawing.Point(274, 317);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "将照片拖拽至此处";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 7F);
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label10.Location = new System.Drawing.Point(24, 317);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "将照片拖拽至此处";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 7F);
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label11.Location = new System.Drawing.Point(149, 484);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "将照片拖拽至此处";
            // 
            // ImportBtn
            // 
            this.ImportBtn.Location = new System.Drawing.Point(559, 221);
            this.ImportBtn.Name = "ImportBtn";
            this.ImportBtn.Size = new System.Drawing.Size(95, 44);
            this.ImportBtn.TabIndex = 19;
            this.ImportBtn.Text = "导入";
            this.ImportBtn.UseVisualStyleBackColor = true;
            this.ImportBtn.Click += new System.EventHandler(this.ImportBtn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(367, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 15);
            this.label12.TabIndex = 20;
            this.label12.Text = "建设项目名称：";
            // 
            // NameBox
            // 
            this.NameBox.FormattingEnabled = true;
            this.NameBox.Location = new System.Drawing.Point(484, 57);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(170, 23);
            this.NameBox.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(397, 179);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 15);
            this.label13.TabIndex = 22;
            this.label13.Text = "保存路径：";
            // 
            // SaveBox
            // 
            this.SaveBox.Location = new System.Drawing.Point(484, 175);
            this.SaveBox.Name = "SaveBox";
            this.SaveBox.Size = new System.Drawing.Size(170, 25);
            this.SaveBox.TabIndex = 23;
            // 
            // FindBtn
            // 
            this.FindBtn.Location = new System.Drawing.Point(433, 221);
            this.FindBtn.Name = "FindBtn";
            this.FindBtn.Size = new System.Drawing.Size(95, 44);
            this.FindBtn.TabIndex = 24;
            this.FindBtn.Text = "浏览";
            this.FindBtn.UseVisualStyleBackColor = true;
            this.FindBtn.Click += new System.EventHandler(this.FindBtn_Click);
            // 
            // Photo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 525);
            this.Controls.Add(this.FindBtn);
            this.Controls.Add(this.SaveBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ImportBtn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.PhotographerBox);
            this.Controls.Add(this.NumberBox);
            this.Controls.Add(this.WestPicture);
            this.Controls.Add(this.EastPicture);
            this.Controls.Add(this.SouthPicture);
            this.Controls.Add(this.NorthPicture);
            this.Name = "Photo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入现场照片";
            ((System.ComponentModel.ISupportInitialize)(this.NorthPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SouthPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EastPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WestPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox NorthPicture;
        private System.Windows.Forms.PictureBox SouthPicture;
        private System.Windows.Forms.PictureBox EastPicture;
        private System.Windows.Forms.PictureBox WestPicture;
        private System.Windows.Forms.TextBox NumberBox;
        private System.Windows.Forms.TextBox PhotographerBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button ImportBtn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox NameBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox SaveBox;
        private System.Windows.Forms.Button FindBtn;
    }
}