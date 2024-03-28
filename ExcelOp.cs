using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CHTools
{
    public partial class Tools : Form
    {
        public void ReadExcel()
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excelApp.Workbooks.Open(ExcelPathBox.Text);
            Worksheet worksheet = workbook.Worksheets[1];
            project.Number = worksheet.Cells[2, 1].Text.Substring(5);

            Range usedRange = worksheet.UsedRange;
            Range head = worksheet.Rows["1:5"];
            Range tail = worksheet.Rows[usedRange.Rows.Count - 5 + ":" + usedRange.Rows.Count];
            tail.Delete();
            head.Delete();

            foreach (Range cell in usedRange.Cells)
            {
                int count = cell.MergeArea.Columns.Count;
                string val = cell.Text.Trim();
                if (count==11 && !string.IsNullOrEmpty(val))
                {
                    Build build = new Build
                    {
                        Number = project.Number,
                        Name = val,
                    };
                    BuildNameBox.Items.Add(val);

                    int start = cell.Row;
                    int end = start + 1;
                    while (worksheet.Cells[end, 1].Text != "外墙饰面面积")
                    {
                        end++;
                    }

                    build.Units = GetBuildUnits(worksheet, cell.Row, start, end - 3);
                    build.DS = worksheet.Cells[end - 4, 2].Text.Trim();
                    build.DX = worksheet.Cells[end - 3, 2].Text.Trim();
                    build.Z = worksheet.Cells[end - 2, 2].Text.Trim();
                    build.YT = worksheet.Cells[end - 2, 4].Text.Trim();
                    build.HS = worksheet.Cells[end - 2, 11].Text.Trim();
                    build.JD = worksheet.Cells[end - 1, 2].Text.Trim();
                    build.JRSM = worksheet.Cells[end - 1, 6].Text.Trim();
                    build.JR = worksheet.Cells[end - 1, 10].Text.Trim();
                    build.WQSM = worksheet.Cells[end - 2, 3].Text.Trim();
                    build.SMHD = worksheet.Cells[end, 9].Text.Trim();
                    project.Builds.Add(build);
                }
            }
            workbook.Close(false);
            excelApp.Quit();
            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);
        }

        //获取单元
        private static List<BuildUnit> GetBuildUnits(Worksheet worksheet, int nameRow, int startRow, int endRow)
        {
            List<BuildUnit> units = new List<BuildUnit>();

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = 5; j <= 10; j++)
                {
                    var cellA = worksheet.Cells[i, j];

                    var cellB = worksheet.Cells[i, j + 1];

                    string name = cellA.Text.Trim();

                    string area = cellB.Text.Trim();

                    if (Regex.IsMatch(name, @"[\u4e00-\u9fa5]") && Regex.IsMatch(area, @"\d"))
                    {
                        BuildUnit unit = new BuildUnit
                        {
                            Name = name,
                            Area = area
                        };
                        
                        if (name.Contains("地下"))
                        {
                            unit.IsUdGround = true;
                        }
                        else
                        {
                            unit.IsUdGround = false;
                        }
                        // Function
                        if (j == 5 || j == 6)
                        {
                            unit.Function = "Main";
                        }
                        else if (j == 7 || j == 8)
                        {
                            unit.Function = "Public";
                        }
                        else if (j == 9 || j == 10)
                        {
                            unit.Function = "Other";
                        }
                        // Floor
                        unit.Floor = GetBuildFloor(worksheet, nameRow, startRow - 1, name);

                        units.Add(unit);
                    }

                }
            }
            return units;
        }

        //获取单元层数
        private static string GetBuildFloor(Worksheet worksheet, int startRow, int endRow, string name)
        {
            List<string> FloorList = new List<string>();
            string floor = string.Empty;
            for (int i = startRow; i <= endRow; i++)
            {
                string text = worksheet.Cells[i, 1].Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    floor = text;
                }
                for (int j = 5; j <= 10; j++)
                {
                    string cell = worksheet.Cells[i, j].Text.Trim();
                    if (cell == name)
                    {
                        FloorList.Add(floor);
                    }
                }
            }
            return string.Join("、", FloorList);
        }
    }
}
