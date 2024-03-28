using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CHTools
{
    public partial class CheckTabel : Form
    {
        public Project project;
        public List<object> WordPath { get; set; }

        public CheckTabel(Project project)
        {
            InitializeComponent();
            Load += GetPath;
            SelectBox.SelectedIndexChanged += Check;
            this.project = project;
        }

        public void GetPath(object sender, EventArgs e)
        {
            SelectBox.DataSource = WordPath;
        }

        public void Check(object sender, EventArgs e)
        {
            List<Build> builds = GetBuild(SelectBox.SelectedItem.ToString());

            GenerateTable(builds);
        }


        private void GenerateTable(List<Build> builds)
        {
            Build ebuild = builds[0];
            Build wbuild = builds[1];
            // 创建一个新的 DataTable 用于存储转置后的数据
            DataTable table = new DataTable();

            // 添加列到转置后的 DataTable 中，列的数量等于原始数据行的数量
            table.Columns.Add("字段名称", typeof(string));
            table.Columns.Add("面积汇总表", typeof(string));
            table.Columns.Add("核实概况表", typeof(string));
            table.Columns.Add("是否一致", typeof(bool));
            table.Columns.Add("同步修改数据(待开发)", typeof(string));

            // 添加行到转置后的 DataTable 中，行的数量等于原始数据列的数量
            table.Rows.Add("工程编号", ebuild.Number, wbuild.Number, IsMatch(ebuild.Number, wbuild.Number));
            table.Rows.Add("建设项目名称", ebuild.Name, wbuild.Name, IsMatch(ebuild.Name, wbuild.Name));
            table.Rows.Add("总面积", ebuild.Z, wbuild.Z, IsMatch(ebuild.Z, wbuild.Z));
            table.Rows.Add("地上面积", ebuild.DS, wbuild.DS, IsMatch(ebuild.DS, wbuild.DS));
            table.Rows.Add("地下面积", ebuild.DX, wbuild.DX, IsMatch(ebuild.DX, wbuild.DX));
            table.Rows.Add("基底面积", ebuild.JD, wbuild.JD, IsMatch(ebuild.JD, wbuild.JD));
            table.Rows.Add("计算容积率面积", ebuild.JR, wbuild.JR, IsMatch(ebuild.JR, wbuild.JR));
            table.Rows.Add("计算容积率饰面面积", ebuild.JRSM, wbuild.JRSM, IsMatch(ebuild.JRSM, wbuild.JRSM));
            table.Rows.Add("外墙饰面面积", ebuild.WQSM, wbuild.WQSM, IsMatch(ebuild.WQSM, wbuild.WQSM));
            table.Rows.Add("饰面厚", ebuild.SMHD, wbuild.SMHD, IsMatch(ebuild.SMHD, wbuild.SMHD));
            table.Rows.Add("阳台面积", ebuild.YT, wbuild.YT, IsMatch(ebuild.YT, wbuild.YT));
            table.Rows.Add("住宅户数", ebuild.HS, wbuild.HS, IsMatch(ebuild.HS, wbuild.HS));

            foreach (var eunit in ebuild.Units)
            {
                foreach (var wunit in wbuild.Units)
                {
                    if (eunit.Name == wunit.Name)
                    {
                        table.Rows.Add(eunit.Name, eunit.Area, wunit.Area, IsMatch(eunit.Area, wunit.Area));
                    }
                }
            }


            cTable.DataSource = table;

            cTable.Columns["字段名称"].ReadOnly = true;
            //cTable.Columns["EPS平面图廓"].ReadOnly = true;
            cTable.Columns["面积汇总表"].ReadOnly = true;
            cTable.Columns["核实概况表"].ReadOnly = true;
            cTable.Columns["是否一致"].ReadOnly = true;
            //cTable.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
        }



        private List<Build> GetBuild(string path)
        {
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show($"请检查文件路径:{path}");
                return null;
            }
            Build wBuild = new Build();

            Build eBuild = new Build();

            using (WordprocessingDocument doc = WordprocessingDocument.Open(path, true))
            {
                MainDocumentPart docPart = doc.MainDocumentPart;

                var firstParagraph = docPart.Document.Body.Elements<Paragraph>().FirstOrDefault();

                string title = firstParagraph.InnerText.Trim();

                int shift = title.Contains("违法") ? 1 : 0;

                var tables = docPart.Document.Body.Elements<Table>();

                // 2张表格：核实概况表，成果汇总表
                Table tableA = tables.ElementAtOrDefault(0);

                Table tableB = tables.ElementAtOrDefault(1);

                wBuild.Name = Utils.GetCellVal(tableA, 1 + shift, 1);

                wBuild.Number = Utils.GetCellVal(tableA, 8 + shift, 1);

                wBuild.JD = Utils.GetCellVal(tableA, 12 + shift, 3);

                wBuild.JR = Utils.GetCellVal(tableA, 13 + shift, 3);

                wBuild.YT = Utils.GetCellVal(tableA, 14 + shift, 3);

                wBuild.HS = Utils.GetCellVal(tableA, 16 + shift, 3);

                wBuild.WQSM = Utils.GetCellVal(tableA, 17 + shift, 2);

                wBuild.JRSM = Utils.GetCellVal(tableA, 17 + shift, 4);

                wBuild.SMHD = Utils.GetCellVal(tableA, 17 + shift, 6);

                wBuild.Z = Utils.GetCellVal(tableB, 1, 4);

                wBuild.DS = Utils.GetCellVal(tableB, 2, 5);

                wBuild.DX = Utils.GetCellVal(tableB, 3, 5);


                int start = (Utils.FindCellIndex(tableB, "主要功能") ?? Utils.FindCellIndex(tableB, "主")).Item1;
                int end = (Utils.FindCellIndex(tableB, "说明") ?? Utils.FindCellIndex(tableB, "说")).Item1;

                for (int i = start; i < end; i++)
                {
                    string strArea = Utils.GetCellVal(tableB, i, 3);
                    if (int.TryParse(strArea, out _))
                    {
                        BuildUnit unit = new BuildUnit
                        {
                            Area = strArea,
                            Name = Utils.GetCellVal(tableB, i, 1),
                            Floor = Utils.GetCellVal(tableB, i, 5),
                            IsUdGround = Name.Contains("地下")
                        };
                        wBuild.Units.Add(unit);
                    }
                }
            }
            foreach (var build in project.Builds)
            {
                if (build.Name.Equals(wBuild.Name))
                {
                    eBuild = build;
                }
            }
            List<Build> BList = new List<Build> 
            {
                eBuild, wBuild
            };

            return BList;
        }


        public bool IsMatch(string excelVal, string wordVal)
        {
            if (excelVal == wordVal)
            {
                return true;
            }
            else if (!string.IsNullOrEmpty(excelVal) && !string.IsNullOrEmpty(wordVal))
            {
                if (float.TryParse(excelVal, out float eVal) && int.TryParse(wordVal, out int wVal))
                {
                    eVal = (int)Math.Round(eVal, 0);
                    if (eVal == wVal)
                    {
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else { return false; }
        }

    }
}
