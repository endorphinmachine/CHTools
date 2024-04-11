using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CHTools
{
    public partial class Tools : Form
    {

        public Vector ReadVec(string wordPath)
        {
            Vector Vector = new Vector();

            Vector.Initialize();

            if (File.Exists(wordPath))
            {
                using (WordprocessingDocument doc = WordprocessingDocument.Open(wordPath, true))
                {
                    MainDocumentPart docPart = doc.MainDocumentPart;

                    var tables = docPart.Document.Body.Elements<Table>();

                    Table tableA = tables.ElementAtOrDefault(0);

                    Table tableB = tables.ElementAtOrDefault(1);

                    //建筑单体规划许可信息
                    Vector.Permission["楼幢编号"] = Utils.GetCellVal(tableA, 1, 1).Trim();

                    // 提取幢数
                    System.Text.RegularExpressions.Match matchZS = Regex.Match(Utils.GetCellVal(tableA, 9, 1), @"\d+");

                    if (matchZS.Success)
                    {
                        string ZS = matchZS.Value;
                        Vector.Permission["幢数"] = ZS.Trim();
                    }

                    Vector.Permission["总面积计和"] = Utils.GetCellVal(tableB, 1, 4).Trim();

                    Vector.Permission["总建筑面积地上"] = Utils.GetCellVal(tableB, 2, 5).Trim();

                    Vector.Permission["总建筑面积地下"] = Utils.GetCellVal(tableB, 3, 5).Trim();

                    //建筑层数
                    Vector.Permission["建筑层数地上"] = Utils.GetCellVal(tableB, 4, 4).Trim();

                    Vector.Permission["建筑层数地下"] = Utils.GetCellVal(tableB, 5, 4).Trim();

                    Vector.Permission["总计算容积率面积计和"] = Utils.GetCellVal(tableA, 13, 3).Trim();

                    Vector.Permission["基底面积"] = Utils.GetCellVal(tableA, 12, 3).Trim();

                    string WQSM = Utils.GetCellVal(tableA, 17, 2).Trim();

                    string JRSM = Utils.GetCellVal(tableA, 17, 4).Trim();

                    Vector.Permission["备注"] = "外墙饰面建筑面积：" + WQSM + "平方米（其中计算容积率饰面面积：" + JRSM + "平方米）";

                    var funtion = Extract(tableB, "主要功能", "公共服务设施");

                    Vector.Function["功能名称"] = funtion.Item1;
                    Vector.Function["建筑面积"] = funtion.Item2;
                    Vector.Function["所在位置"] = funtion.Item3;

                    var pubilc = Extract(tableB, "公共服务设施", "车库配建");
                    Vector.Facility["功能名称"] = pubilc.Item1;
                    Vector.Facility["建筑面积"] = pubilc.Item2;
                    Vector.Facility["所在位置"] = pubilc.Item3;

                    var other = Extract(tableB, "车库配建", "说明");
                    Vector.Other["功能名称"] = other.Item1;
                    Vector.Other["建筑面积"] = other.Item2;
                    Vector.Other["所在位置"] = other.Item3;
                }
            }
            else
            {
                MessageBox.Show($"文件路径：{wordPath}错误");
            }
            return Vector;
        }


        private void WriteVec(ExcelPackage excelPackage, Vector Vector)
        {
            ExcelWorksheet Permissionsheet = excelPackage.Workbook.Worksheets[0];

            foreach (var kvp in Vector.Permission)
            {
                Tuple<int, int> Idx = Locate(Permissionsheet, kvp.Key);
                Permissionsheet.SetValue(Idx.Item1, Idx.Item2, kvp.Value);
            }
            SetCell(excelPackage.Workbook.Worksheets[1], Vector.Function, Vector.Permission["楼幢编号"]);
            SetCell(excelPackage.Workbook.Worksheets[2], Vector.Facility, Vector.Permission["楼幢编号"]);
            SetCell(excelPackage.Workbook.Worksheets[3], Vector.Other, Vector.Permission["楼幢编号"]);
        }

        private void SetCell(ExcelWorksheet sheet, Dictionary<string, List<string>> dic, string buildName)
        {
            foreach (var kvp in dic)
            {
                if (!string.IsNullOrEmpty(kvp.Key))
                {
                    foreach (string v in kvp.Value)
                    {
                        Tuple<int, int> Idx = Locate(sheet, kvp.Key);
                        if (!string.IsNullOrEmpty(v))
                        {
                            sheet.SetValue(Idx.Item1, Idx.Item2, v);
                            sheet.SetValue(Idx.Item1, 1, buildName);
                        }
                        else
                        {
                            sheet.SetValue(Idx.Item1, Idx.Item2, "/");
                        }
                    }
                }
                else if (kvp.Key == "楼幢编号")
                {
                    Tuple<int, int> Idx = Locate(sheet, kvp.Key);
                    sheet.SetValue(Idx.Item1, Idx.Item2, kvp.Value);
                }
            }
        }


        public Tuple<List<string>, List<string>, List<string>> Extract(Table table, string startword, string endword)
        {
            int startRow = (Utils.FindCellIndex(table, startword) ?? Utils.FindCellIndex(table, startword[0].ToString())).Item1 + 2;
            int endRow = (Utils.FindCellIndex(table, endword) ?? Utils.FindCellIndex(table, endword[0].ToString())).Item1;

            List<string> itemName = new List<string>();
            List<string> itemArea = new List<string>();
            List<string> itemLayer = new List<string>();
            for (int i = startRow; i < endRow; i++)
            {
                string name = Utils.GetCellVal(table, i, 1).Trim();
                if (!string.IsNullOrEmpty(name))
                {
                    string area = Utils.GetCellVal(table, i, 3).Trim();
                    string layer = Utils.GetCellVal(table, i, 5).Trim();
                    if (!string.IsNullOrEmpty(area) && !string.IsNullOrEmpty(layer))
                    {
                        itemName.Add(name);
                        itemArea.Add(area);
                        itemLayer.Add(layer);
                    }
                }
            }
            return Tuple.Create(itemName, itemArea, itemLayer);
        }


        private Tuple<int, int> Locate(ExcelWorksheet sheet, string key)
        {
            int row = 1;
            int col = 1;
            for (int i = 1; i <= 16; i++)
            {
                string head = sheet.Cells[1, i].Value?.ToString();
                if (head == key)
                {
                    col = i;
                }
            }

            while (sheet.Cells[row, col].Value != null)
            {
                row += 1;
            }
            return Tuple.Create(row, col);
        }
    }
}
