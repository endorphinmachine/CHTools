using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace CHTools
{
    public partial class Tools : Form
    {
        // 根据EXCEL文件路径读取建设项目信息
        public void ReadExcel()
        {
            project.Builds.Clear();

            using (var excelPackage = new ExcelPackage(new FileInfo(ExcelPathBox.Text)))
            {
                var excelSheet = excelPackage.Workbook.Worksheets[0];

                project.Number = excelSheet.Cells[2, 1].Text.Substring(5);

                List<int> MergedRow = FindMergedRow(excelSheet);

                foreach (int RowIndex in MergedRow)
                {
                    var buildName = excelSheet.Cells[RowIndex, 1].Text.Trim();

                    if (NonEmptyCellCount(excelSheet, RowIndex) == 1 && !string.IsNullOrEmpty(buildName))
                    {
                        Build build = new Build
                        {
                            Number = project.Number,
                            Name = buildName,
                        };

                        BuildNameBox.Items.Add(buildName);

                        int startRow = RowIndex;
                        while (NonEmptyCellCount(excelSheet, startRow) != 0 && excelSheet.Cells[startRow, 1].Text != "地上∑")
                        {
                            startRow += 1;
                        }

                        int endRow = startRow + 1;
                        while (NonEmptyCellCount(excelSheet, endRow) != 1 && excelSheet.Cells[endRow, 1].Text != "外墙饰面面积")
                        {
                            endRow += 1;
                        }
                        build.Units = GetBuildUnits(excelSheet, RowIndex, startRow, endRow - 3);

                        build.DS = excelSheet.Cells[endRow - 4, 2].Text.Trim();
                        build.DX = excelSheet.Cells[endRow - 3, 2].Text.Trim();
                        build.Z = excelSheet.Cells[endRow - 2, 2].Text.Trim();

                        build.YT = excelSheet.Cells[endRow - 2, 4].Text.Trim();
                        build.HS = excelSheet.Cells[endRow - 2, 11].Text.Trim();
                        build.JD = excelSheet.Cells[endRow - 1, 2].Text.Trim();
                        build.JRSM = excelSheet.Cells[endRow - 1, 6].Text.Trim();
                        build.JR = excelSheet.Cells[endRow - 1, 10].Text.Trim();
                        build.WQSM = excelSheet.Cells[endRow - 2, 3].Text.Trim();
                        build.SMHD = excelSheet.Cells[endRow, 9].Text.Trim();
                        project.Builds.Add(build);
                    }
                }
            }
        }

        //获取单元
        private static List<BuildUnit> GetBuildUnits(ExcelWorksheet worksheet, int nameRow, int startRow, int endRow)
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
                        // isUnderGround
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
        private static string GetBuildFloor(ExcelWorksheet worksheet, int startRow, int endRow, string name)
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

        // 定位面积汇总表中的合并单元格（整行）
        public static List<int> FindMergedRow(ExcelWorksheet worksheet)
        {
            List<int> MergedRow = new List<int>();

            int totalColumns = 11;

            // 遍历所有合并单元格
            foreach (var mergeAddress in worksheet.MergedCells)
            {
                // 解析合并单元格的地址
                var CellAddress = worksheet.Cells[mergeAddress];

                // 如果合并单元格的长度等于表格的总列数，则记录其列数
                if (CellAddress.Columns == totalColumns)
                {
                    MergedRow.Add(CellAddress.Start.Row);
                }
            }
            MergedRow.Sort();
            MergedRow.RemoveAt(0);
            MergedRow.RemoveAt(MergedRow.Count - 1);

            return MergedRow;
        }
        // 统计面积汇总表中一行的非空单元格
        public static int NonEmptyCellCount(ExcelWorksheet worksheet, int rowIndex)
        {
            var row = worksheet.Cells[rowIndex, 1, rowIndex, worksheet.Dimension.End.Column];

            return row.Count(cell => !string.IsNullOrEmpty(cell.Text));
        }

    }
}
