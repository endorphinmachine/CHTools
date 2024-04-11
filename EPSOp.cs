using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace CHTools
{
    public partial class EPSOp : Form
    {
        public string EPSPath;

        public Project EpsProject = new Project();

        public EPSOp(string EPSPath)
        {
            InitializeComponent();
            Load += ShowEPSData;
            this.EPSPath = EPSPath;
        }

        private void ShowEPSData(object sender, EventArgs e)
        {
            // 创建一个新的 DataTable 
            DataTable table = new DataTable();
            table.Columns.Add("工程编号", typeof(string));
            table.Columns.Add("报建编号", typeof(string));
            table.Columns.Add("建设用地规划许可证", typeof(string));
            table.Columns.Add("建设位置", typeof(string));
            table.Columns.Add("建设单位", typeof(string));
            table.Columns.Add("设计单位", typeof(string));
            table.Columns.Add("施工单位", typeof(string));
            string connectionString = $"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={EPSPath}";
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM 建筑竣工验收平面关系图廓属性表";
                    using (OleDbCommand command = new OleDbCommand(query, con))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                table.Rows.Add(
                                    reader["工程编号"].ToString(),
                                    reader["报建编号"].ToString(),
                                    reader["建设用地规划许可证"].ToString(),
                                    reader["建设位置"].ToString(),
                                    reader["建设单位"].ToString(),
                                    reader["设计单位"].ToString(),
                                    reader["施工单位"].ToString());
                            }
                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            EPSTable.DataSource = table;
            EPSTable.ReadOnly = true;
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            int SelecetedRow = EPSTable.SelectedRows[0].Index;
            EpsProject.Number = EPSTable.Rows[SelecetedRow].Cells[0].Value.ToString();
            EpsProject.BJNo = EPSTable.Rows[SelecetedRow].Cells[1].Value.ToString();
            EpsProject.YDNo = EPSTable.Rows[SelecetedRow].Cells[2].Value.ToString();
            EpsProject.Location = EPSTable.Rows[SelecetedRow].Cells[3].Value.ToString();
            EpsProject.Builder = EPSTable.Rows[SelecetedRow].Cells[4].Value.ToString();
            EpsProject.Designer = EPSTable.Rows[SelecetedRow].Cells[5].Value.ToString();
            EpsProject.Contractor = EPSTable.Rows[SelecetedRow].Cells[6].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }
    }
}
