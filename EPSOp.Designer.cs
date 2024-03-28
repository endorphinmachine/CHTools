namespace CHTools
{
    partial class EPSOp
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
            this.EPSTable = new System.Windows.Forms.DataGridView();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EPSTable)).BeginInit();
            this.SuspendLayout();
            // 
            // EPSTable
            // 
            this.EPSTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.EPSTable.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.EPSTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EPSTable.Location = new System.Drawing.Point(15, 12);
            this.EPSTable.Name = "EPSTable";
            this.EPSTable.RowHeadersWidth = 50;
            this.EPSTable.RowTemplate.Height = 23;
            this.EPSTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EPSTable.Size = new System.Drawing.Size(927, 283);
            this.EPSTable.TabIndex = 0;
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Font = new System.Drawing.Font("宋体", 9F);
            this.ConfirmBtn.Location = new System.Drawing.Point(419, 301);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(114, 30);
            this.ConfirmBtn.TabIndex = 2;
            this.ConfirmBtn.Text = "确定";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // EPSOp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 338);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.EPSTable);
            this.Name = "EPSOp";
            this.Text = "选择目标图廓信息";
            ((System.ComponentModel.ISupportInitialize)(this.EPSTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView EPSTable;
        private System.Windows.Forms.Button ConfirmBtn;
    }
}