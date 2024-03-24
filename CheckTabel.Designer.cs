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

        }

        #endregion

        private System.Windows.Forms.DataGridView cTable;
    }
}