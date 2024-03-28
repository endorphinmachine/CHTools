namespace CHTools
{
    partial class Tools
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button GenerateBtn;
            this.GenVecBtn = new System.Windows.Forms.Button();
            this.WordPathBox = new System.Windows.Forms.ComboBox();
            this.WordInputBtn = new System.Windows.Forms.Button();
            this.ExcelInputBtn = new System.Windows.Forms.Button();
            this.ExcelPathBox = new System.Windows.Forms.TextBox();
            this.LocationBox = new System.Windows.Forms.TextBox();
            this.NumberBox = new System.Windows.Forms.TextBox();
            this.ApprovmentBox = new System.Windows.Forms.TextBox();
            this.DesignerBox = new System.Windows.Forms.TextBox();
            this.JSGCGHXK = new System.Windows.Forms.TextBox();
            this.ContractorBox = new System.Windows.Forms.TextBox();
            this.BuilderBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.WeiZhang = new System.Windows.Forms.RadioButton();
            this.YanShou = new System.Windows.Forms.RadioButton();
            this.CheckBtn = new System.Windows.Forms.Button();
            this.buildNameLabel = new System.Windows.Forms.Label();
            this.BuildNameBox = new System.Windows.Forms.ComboBox();
            this.ProjNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EPSInputButton = new System.Windows.Forms.Button();
            this.EPSPathBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.FileBtn = new System.Windows.Forms.Button();
            GenerateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GenerateBtn
            // 
            GenerateBtn.Font = new System.Drawing.Font("微软雅黑", 9F);
            GenerateBtn.Location = new System.Drawing.Point(27, 324);
            GenerateBtn.Margin = new System.Windows.Forms.Padding(4);
            GenerateBtn.Name = "GenerateBtn";
            GenerateBtn.Size = new System.Drawing.Size(120, 30);
            GenerateBtn.TabIndex = 68;
            GenerateBtn.Text = "生成概况表格";
            GenerateBtn.UseVisualStyleBackColor = true;
            GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // GenVecBtn
            // 
            this.GenVecBtn.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.GenVecBtn.Location = new System.Drawing.Point(321, 324);
            this.GenVecBtn.Name = "GenVecBtn";
            this.GenVecBtn.Size = new System.Drawing.Size(120, 30);
            this.GenVecBtn.TabIndex = 95;
            this.GenVecBtn.Text = "生成矢量数据";
            this.GenVecBtn.UseVisualStyleBackColor = true;
            this.GenVecBtn.Click += new System.EventHandler(this.GenVecBtn_Click);
            // 
            // WordPathBox
            // 
            this.WordPathBox.FormattingEnabled = true;
            this.WordPathBox.Location = new System.Drawing.Point(120, 284);
            this.WordPathBox.Margin = new System.Windows.Forms.Padding(4);
            this.WordPathBox.Name = "WordPathBox";
            this.WordPathBox.Size = new System.Drawing.Size(394, 23);
            this.WordPathBox.TabIndex = 94;
            // 
            // WordInputBtn
            // 
            this.WordInputBtn.Location = new System.Drawing.Point(521, 279);
            this.WordInputBtn.Name = "WordInputBtn";
            this.WordInputBtn.Size = new System.Drawing.Size(60, 30);
            this.WordInputBtn.TabIndex = 93;
            this.WordInputBtn.Text = "浏览";
            this.WordInputBtn.UseVisualStyleBackColor = true;
            this.WordInputBtn.Click += new System.EventHandler(this.WordInputBtn_Click);
            // 
            // ExcelInputBtn
            // 
            this.ExcelInputBtn.Location = new System.Drawing.Point(521, 242);
            this.ExcelInputBtn.Name = "ExcelInputBtn";
            this.ExcelInputBtn.Size = new System.Drawing.Size(60, 30);
            this.ExcelInputBtn.TabIndex = 92;
            this.ExcelInputBtn.Text = "浏览";
            this.ExcelInputBtn.UseVisualStyleBackColor = true;
            this.ExcelInputBtn.Click += new System.EventHandler(this.ExcelInputBtn_Click);
            // 
            // ExcelPathBox
            // 
            this.ExcelPathBox.Location = new System.Drawing.Point(120, 243);
            this.ExcelPathBox.Name = "ExcelPathBox";
            this.ExcelPathBox.Size = new System.Drawing.Size(393, 25);
            this.ExcelPathBox.TabIndex = 91;
            this.ExcelPathBox.TextChanged += new System.EventHandler(this.ExcelPathBox_TextChanged);
            // 
            // LocationBox
            // 
            this.LocationBox.Location = new System.Drawing.Point(352, 92);
            this.LocationBox.Name = "LocationBox";
            this.LocationBox.Size = new System.Drawing.Size(233, 25);
            this.LocationBox.TabIndex = 83;
            this.LocationBox.TextChanged += new System.EventHandler(this.LocationBox_TextChanged);
            // 
            // NumberBox
            // 
            this.NumberBox.Location = new System.Drawing.Point(390, 12);
            this.NumberBox.Name = "NumberBox";
            this.NumberBox.Size = new System.Drawing.Size(195, 25);
            this.NumberBox.TabIndex = 81;
            this.NumberBox.TextChanged += new System.EventHandler(this.NumberBox_TextChanged);
            // 
            // ApprovmentBox
            // 
            this.ApprovmentBox.Location = new System.Drawing.Point(435, 131);
            this.ApprovmentBox.Name = "ApprovmentBox";
            this.ApprovmentBox.Size = new System.Drawing.Size(150, 25);
            this.ApprovmentBox.TabIndex = 80;
            this.ApprovmentBox.TextChanged += new System.EventHandler(this.ApprovmentBox_TextChanged);
            // 
            // DesignerBox
            // 
            this.DesignerBox.Location = new System.Drawing.Point(106, 51);
            this.DesignerBox.Name = "DesignerBox";
            this.DesignerBox.Size = new System.Drawing.Size(150, 25);
            this.DesignerBox.TabIndex = 74;
            this.DesignerBox.TextChanged += new System.EventHandler(this.DesignerBox_TextChanged);
            // 
            // JSGCGHXK
            // 
            this.JSGCGHXK.Location = new System.Drawing.Point(196, 131);
            this.JSGCGHXK.Name = "JSGCGHXK";
            this.JSGCGHXK.Size = new System.Drawing.Size(134, 25);
            this.JSGCGHXK.TabIndex = 78;
            this.JSGCGHXK.TextChanged += new System.EventHandler(this.LicenseBox_TextChanged);
            // 
            // ContractorBox
            // 
            this.ContractorBox.Location = new System.Drawing.Point(106, 92);
            this.ContractorBox.Name = "ContractorBox";
            this.ContractorBox.Size = new System.Drawing.Size(150, 25);
            this.ContractorBox.TabIndex = 76;
            this.ContractorBox.TextChanged += new System.EventHandler(this.ContractorBox_TextChanged);
            // 
            // BuilderBox
            // 
            this.BuilderBox.Location = new System.Drawing.Point(106, 12);
            this.BuilderBox.Name = "BuilderBox";
            this.BuilderBox.Size = new System.Drawing.Size(150, 25);
            this.BuilderBox.TabIndex = 70;
            this.BuilderBox.TextChanged += new System.EventHandler(this.BuilderBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 90;
            this.label7.Text = "成果槪况表:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 89;
            this.label5.Text = "面积汇总表:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 88;
            this.label4.Text = "业务类型:";
            // 
            // WeiZhang
            // 
            this.WeiZhang.AutoSize = true;
            this.WeiZhang.Location = new System.Drawing.Point(257, 175);
            this.WeiZhang.Name = "WeiZhang";
            this.WeiZhang.Size = new System.Drawing.Size(118, 19);
            this.WeiZhang.TabIndex = 87;
            this.WeiZhang.Text = "违法建设测量";
            this.WeiZhang.UseVisualStyleBackColor = true;
            // 
            // YanShou
            // 
            this.YanShou.AutoSize = true;
            this.YanShou.Checked = true;
            this.YanShou.Location = new System.Drawing.Point(120, 175);
            this.YanShou.Name = "YanShou";
            this.YanShou.Size = new System.Drawing.Size(118, 19);
            this.YanShou.TabIndex = 86;
            this.YanShou.TabStop = true;
            this.YanShou.Text = "规划条件核实";
            this.YanShou.UseVisualStyleBackColor = true;
            // 
            // CheckBtn
            // 
            this.CheckBtn.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.CheckBtn.Location = new System.Drawing.Point(176, 324);
            this.CheckBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(120, 30);
            this.CheckBtn.TabIndex = 85;
            this.CheckBtn.Text = "检核概况数据";
            this.CheckBtn.UseVisualStyleBackColor = true;
            this.CheckBtn.Click += new System.EventHandler(this.CheckBtn_Click);
            // 
            // buildNameLabel
            // 
            this.buildNameLabel.AutoSize = true;
            this.buildNameLabel.Location = new System.Drawing.Point(263, 58);
            this.buildNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buildNameLabel.Name = "buildNameLabel";
            this.buildNameLabel.Size = new System.Drawing.Size(112, 15);
            this.buildNameLabel.TabIndex = 84;
            this.buildNameLabel.Text = "建设项目名称：";
            // 
            // BuildNameBox
            // 
            this.BuildNameBox.FormattingEnabled = true;
            this.BuildNameBox.Location = new System.Drawing.Point(383, 55);
            this.BuildNameBox.Margin = new System.Windows.Forms.Padding(4);
            this.BuildNameBox.Name = "BuildNameBox";
            this.BuildNameBox.Size = new System.Drawing.Size(202, 23);
            this.BuildNameBox.TabIndex = 72;
            // 
            // ProjNumber
            // 
            this.ProjNumber.AutoSize = true;
            this.ProjNumber.Location = new System.Drawing.Point(263, 17);
            this.ProjNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProjNumber.Name = "ProjNumber";
            this.ProjNumber.Size = new System.Drawing.Size(120, 15);
            this.ProjNumber.TabIndex = 71;
            this.ProjNumber.Text = "放线/验收案号：";
            this.ProjNumber.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 82;
            this.label3.Text = "建设位置：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 73;
            this.label2.Text = "设计单位:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 75;
            this.label6.Text = "施工单位:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 15);
            this.label8.TabIndex = 77;
            this.label8.Text = "建设工程规划许可证号:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 69;
            this.label1.Text = "建设单位:";
            // 
            // EPSInputButton
            // 
            this.EPSInputButton.Location = new System.Drawing.Point(521, 202);
            this.EPSInputButton.Name = "EPSInputButton";
            this.EPSInputButton.Size = new System.Drawing.Size(60, 30);
            this.EPSInputButton.TabIndex = 98;
            this.EPSInputButton.Text = "浏览";
            this.EPSInputButton.UseVisualStyleBackColor = true;
            this.EPSInputButton.Click += new System.EventHandler(this.EPSInputButton_Click);
            // 
            // EPSPathBox
            // 
            this.EPSPathBox.Location = new System.Drawing.Point(120, 205);
            this.EPSPathBox.Name = "EPSPathBox";
            this.EPSPathBox.Size = new System.Drawing.Size(393, 25);
            this.EPSPathBox.TabIndex = 97;
            this.EPSPathBox.TextChanged += new System.EventHandler(this.EPSPathBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 15);
            this.label9.TabIndex = 96;
            this.label9.Text = "EPS平面图:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(339, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 15);
            this.label11.TabIndex = 79;
            this.label11.Text = "相关批文号:";
            // 
            // FileBtn
            // 
            this.FileBtn.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FileBtn.Location = new System.Drawing.Point(465, 324);
            this.FileBtn.Name = "FileBtn";
            this.FileBtn.Size = new System.Drawing.Size(120, 30);
            this.FileBtn.TabIndex = 99;
            this.FileBtn.Text = "文件格式转换";
            this.FileBtn.UseVisualStyleBackColor = true;
            this.FileBtn.Click += new System.EventHandler(this.FileBtn_Click);
            // 
            // Tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(614, 375);
            this.Controls.Add(this.FileBtn);
            this.Controls.Add(this.EPSInputButton);
            this.Controls.Add(this.EPSPathBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.GenVecBtn);
            this.Controls.Add(this.WordPathBox);
            this.Controls.Add(this.WordInputBtn);
            this.Controls.Add(this.ExcelInputBtn);
            this.Controls.Add(this.ExcelPathBox);
            this.Controls.Add(this.LocationBox);
            this.Controls.Add(this.NumberBox);
            this.Controls.Add(this.ApprovmentBox);
            this.Controls.Add(this.DesignerBox);
            this.Controls.Add(this.JSGCGHXK);
            this.Controls.Add(this.ContractorBox);
            this.Controls.Add(this.BuilderBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.WeiZhang);
            this.Controls.Add(this.YanShou);
            this.Controls.Add(this.CheckBtn);
            this.Controls.Add(this.buildNameLabel);
            this.Controls.Add(this.BuildNameBox);
            this.Controls.Add(this.ProjNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(GenerateBtn);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Tools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "规划测绘业务工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GenVecBtn;
        private System.Windows.Forms.ComboBox WordPathBox;
        private System.Windows.Forms.Button WordInputBtn;
        private System.Windows.Forms.Button ExcelInputBtn;
        private System.Windows.Forms.TextBox ExcelPathBox;
        private System.Windows.Forms.TextBox LocationBox;
        private System.Windows.Forms.TextBox NumberBox;
        private System.Windows.Forms.TextBox ApprovmentBox;
        private System.Windows.Forms.TextBox DesignerBox;
        private System.Windows.Forms.TextBox JSGCGHXK;
        private System.Windows.Forms.TextBox ContractorBox;
        private System.Windows.Forms.TextBox BuilderBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton WeiZhang;
        private System.Windows.Forms.RadioButton YanShou;
        private System.Windows.Forms.Button CheckBtn;
        private System.Windows.Forms.Label buildNameLabel;
        private System.Windows.Forms.ComboBox BuildNameBox;
        private System.Windows.Forms.Label ProjNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EPSInputButton;
        private System.Windows.Forms.TextBox EPSPathBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button FileBtn;
    }
}

