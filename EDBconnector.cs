using DocumentFormat.OpenXml.Office.CustomUI;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHTools
{
    public class EDBconnector
    {
        public static Project ReadEPS(string EPSPath)
        {
            Project project = new Project();
            string connectionString = $"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={EPSPath}";
            string projectNumber = Path.GetFileNameWithoutExtension(EPSPath).Substring(0, 11);
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
                                string number = reader["工程编号"].ToString();
                                if (number.Equals(projectNumber))
                                {
                                    project.Number = number;
                                    project.BJNo = reader["报建编号"].ToString();
                                    project.YDNo = reader["建设用地规划许可证"].ToString();
                                    project.Location = reader["建设位置"].ToString();
                                    project.Builder = reader["建设单位"].ToString();
                                    project.Designer = reader["设计单位"].ToString();
                                    project.Contractor = reader["施工单位"].ToString();
                                }
                            }
                            reader.Close();
                            return project;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
    }
}
