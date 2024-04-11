namespace CHTools
{
    partial class CheckTabel
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
            this.cTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.cTable)).BeginInit();
            this.SuspendLayout();
            // 
            // cTable
            // 
            this.cTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.cTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cTable.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cTable.Location = new System.Drawing.Point(0, 0);
            this.cTable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cTable.Name = "cTable";
            this.cTable.RowHeadersWidth = 51;
            this.cTable.RowTemplate.Height = 27;
            this.cTable.Size = new System.Drawing.Size(600, 360);
            this.cTable.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择要检查的核实概况表文件：";
            // 
            // SelectBox
            // 
            this.SelectBox.FormattingEnabled = true;
            this.SelectBox.Location = new System.Drawing.Point(237, 8);
            this.SelectBox.Name = "SelectBox";
            this.SelectBox.Size = new System.Drawing.Size(933, 23);
            this.SelectBox.TabIndex = 2;
            // 
            // CheckTabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.cTable);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CheckTabel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "核实槪况信息检查";
            ((System.ComponentModel.ISupportInitialize)(this.cTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView cTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SelectBox;
    }
}