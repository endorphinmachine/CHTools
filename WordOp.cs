﻿using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace CHTools
{
    public partial class Tools : Form
    {
        public List<string> noMatchBuild = new List<string>();
        public List<string> MatchedBuild = new List<string>();
        public List<string> noMatchItem = new List<string>();
        private void Generate(Build build)
        {
            int shift = WeiZhang.Checked ? 1 : 0;
            if (WordPathBox.Items.Count != 0)
            {
                foreach (var path in WordPathBox.Items)
                {
                    WriteWord(build, path.ToString(), path.ToString(), shift);
                }
            }
            else
            {
                string inputPath = WeiZhang.Checked ? @"template\违法测量模板.docx" : @"template\核实概况模板.docx";
                string outputPath = Utils.ReplacePath(ExcelPathBox.Text, build.Name);
                WriteWord(build, inputPath, outputPath, shift);
            }
        }

        // 写入概况表
        public void WriteWord(Build build, string inputPath, string outputPath, int shift)
        {
            if (!File.Exists(inputPath))
            {
                MessageBox.Show($"未找到概况表，请检查文件路径:{inputPath}是否有误");
            }
            if (inputPath != outputPath)
            {
                File.Copy(inputPath, outputPath, true);
            }

            using (WordprocessingDocument doc = WordprocessingDocument.Open(outputPath, true))
            {
                MainDocumentPart docPart = doc.MainDocumentPart;

                var tables = docPart.Document.Body.Elements<Table>();

                // 2张表格：核实概况表，成果汇总表
                Table tableA = tables.ElementAtOrDefault(0);

                Table tableB = tables.ElementAtOrDefault(1);

                //判断概况表是否为模板，或者是否与当前buildName匹配
                var wordBuildName = Utils.GetCellVal(tableA, shift + 1, 1);

                if (Utils.FindCellIndex(tableA, wordBuildName) is null && !string.IsNullOrEmpty(wordBuildName))
                {
                    noMatchBuild.Add(wordBuildName);
                }

                if (wordBuildName == build.Name || inputPath.Contains("模板"))
                {
                    MatchedBuild.Add(wordBuildName);
                    // 写入核实槪况表 tableA

                    //建设单位
                    Utils.SetCellVal(tableA, 0 + shift, 1, project.Builder, true, false);

                    // 建设项目名称
                    Utils.SetCellVal(tableA, 1 + shift, 1, build.Name, true, false);

                    //建设位置
                    Utils.SetCellVal(tableA, 2 + shift, 1, project.Location, true, false);

                    //设计单位
                    Utils.SetCellVal(tableA, 3 + shift, 1, project.Designer, true, false);

                    //施工单位
                    Utils.SetCellVal(tableA, 4 + shift, 1, project.Contractor, true, false);

                    //建设工程规划许可证号
                    Utils.SetCellVal(tableA, 6 + shift, 1, project.YDNo, true, false);

                    //相关批文号
                    Utils.SetCellVal(tableA, 7 + shift, 1, project.BJNo, true, false);

                    // 放线/验收案号
                    Utils.SetCellVal(tableA, 8 + shift, 1, project.Number, true, false);

                    // 基底面积（m2）
                    Utils.SetCellVal(tableA, 12 + shift, 3, build.JD, true, true);

                    // 计算容积率面积（m2）
                    Utils.SetCellVal(tableA, 13 + shift, 3, build.JR, true, true);

                    // 阳台面积（m2）
                    Utils.SetCellVal(tableA, 14 + shift, 3, build.YT, true, true);

                    // 住宅户数
                    Utils.SetCellVal(tableA, 16 + shift, 3, build.HS, true, true);

                    //外墙饰面建筑面积（不取整）
                    Utils.SetCellVal(tableA, 17 + shift, 2, build.WQSM, false, true);

                    //计算容积率饰面面积（不取整）
                    Utils.SetCellVal(tableA, 17 + shift, 4, build.JRSM, false, true);

                    //饰面厚（不取整）
                    Utils.SetCellVal(tableA, 17 + shift, 4, build.SMHD, false, true);

                    //写入成果汇总表 

                    //总建筑面积(m2) 地上面积(m2）地下面积(m2)

                    //处理面积闭合差
                    float ZMJ = Utils.StrToFloat(build.Z);
                    float DSMJ = Utils.StrToFloat(build.DS);
                    float DXMJ = Utils.StrToFloat(build.DX);

                    int intZMJ = (int)Math.Round(ZMJ, 0);
                    int intDSMJ = (int)Math.Round(DSMJ, 0);
                    int intDXMJ = (int)Math.Round(DXMJ, 0);

                    if (DSMJ != 0 && DXMJ != 0)
                    {
                        while (intDSMJ + intDXMJ != intZMJ)
                        {
                            if ((DSMJ - Math.Floor(DSMJ)) > (DXMJ - Math.Floor(DXMJ)))
                            {
                                intDSMJ = AdjustArea(build, intDSMJ, false);
                            }
                            else
                            {
                                intDXMJ = AdjustArea(build, intDXMJ, true);
                            }
                        }
                    }
                    else if (DSMJ == 0)
                    {
                        while (intDXMJ != build.GetDX())
                        {
                            int sumDXMJ = build.GetDX();
                            intDXMJ = AdjustArea(build, intDXMJ, true);
                        }
                    }
                    else if (DXMJ == 0)
                    {
                        while (intDSMJ != build.GetDS())
                        {
                            int sumDSMJ = build.GetDS();
                            intDSMJ = AdjustArea(build, intDSMJ, false);
                        }
                    }
                    Utils.SetCellVal(tableB, 1, 4, intZMJ.ToString(), true, true);
                    Utils.SetCellVal(tableB, 2, 5, intDSMJ.ToString(), true, true);
                    Utils.SetCellVal(tableB, 3, 5, intDXMJ.ToString(), true, true);
                    // 填写主要功能
                    int Mrow = (Utils.FindCellIndex(tableB, "主要功能") ?? Utils.FindCellIndex(tableB, "主")).Item1 + 2;

                    foreach (var u in build.Units.FindAll(u => u.Function == "Main"))
                    {
                        Tuple<int, int> Cell = Utils.FindCellIndex(tableB, u.Name);
                        int row;
                        if (Cell != null)
                        {
                            row = Cell.Item1;
                        }
                        else
                        {
                            row = Mrow;
                            Mrow += 1;
                        }
                        Utils.SetCellVal(tableB, row, 1, u.Name, true, true);
                        Utils.SetCellVal(tableB, row, 3, u.Area, true, true);
                        Utils.SetCellVal(tableB, row, 5, u.Floor, true, true);
                    }

                    // 公共服务设施
                    int PRow = (Utils.FindCellIndex(tableB, "公共服务设施") ?? Utils.FindCellIndex(tableB, "公")).Item1 + 2;
                    foreach (var u in build.Units.FindAll(u => u.Function == "Pubilc"))
                    {
                        Tuple<int, int> Cell = Utils.FindCellIndex(tableB, u.Name);
                        int row;
                        if (Cell != null)
                        {
                            row = Cell.Item1;
                        }
                        else
                        {
                            row = PRow;
                            PRow += 1;
                        }
                        Utils.SetCellVal(tableB, row, 1, u.Name, true, true);
                        Utils.SetCellVal(tableB, row, 3, u.Area, true, true);
                        Utils.SetCellVal(tableB, row, 5, u.Floor, true, true);
                    }

                    // 车库配建&其他功能
                    foreach (var u in build.Units.FindAll(u => u.Function == "Other"))
                    {
                        Tuple<int, int> Cell = Utils.FindCellIndex(tableB, u.Name);
                        if (u.Name == "地上机动车库")
                        {
                            Cell = Utils.FindCellIndex(tableB, "地上汽车库");
                        }
                        else if (u.Name == "地下机动车库")
                        {
                            Cell = Utils.FindCellIndex(tableB, "地下汽车库");
                        }
                        else if (u.Name == "其它")
                        {
                            Cell = Utils.FindCellIndex(tableB, "其他");
                        }
                        else if (u.Name == "天面梯屋及机房" || u.Name == "梯屋机房")
                        {
                            Cell = Utils.FindCellIndex(tableB, "屋顶梯屋及电梯机房");
                        }

                        // 如果excel表格有匹配项，则直接写入word表格; 如果excel表格无匹配项，则在窗口中提示
                        if (Cell != null)
                        {
                            Utils.SetCellVal(tableB, Cell.Item1, Cell.Item2 + 2, u.Area, true, true);
                            Utils.SetCellVal(tableB, Cell.Item1, Cell.Item2 + 4, u.Floor, true, true);
                        }
                        else
                        {
                            noMatchItem.Add(build.Name + ":" + u.Name);
                        }
                    }
                }
            }
        }


        //调整闭合差
        private int AdjustArea(Build build, float sumArea, bool isUnderground)
        {
            int sum = 0;
            float max = 0;
            float min = 0;
            float totalArea = 0;
            string maxKey = string.Empty;
            string minKey = string.Empty;

            foreach (var u in build.Units)
            {
                bool isTargetUnit = isUnderground ? u.Name.Contains("地下") : !u.Name.Contains("地下");
                if (isTargetUnit)
                {
                    float area = Utils.StrToFloat(u.Area);
                    int intArea = (int)Math.Round(area, 0);
                    // 计算取整后的增量
                    float diff = area - intArea;
                    if (diff >= 0 && diff > max)
                    {
                        max = diff;
                        maxKey = u.Name;
                    }
                    if (diff < 0 && diff < min)
                    {
                        min = diff;
                        minKey = u.Name;
                    }
                    sum += intArea;
                }
            }

            foreach (var u in build.Units)
            {
                float area = Utils.StrToFloat(u.Area);
                totalArea += area;
                if (sum > sumArea && u.Name == minKey)
                {
                    u.Area = (area - 0.1).ToString();
                }
                else if (sum < sumArea && u.Name == maxKey)
                {
                    u.Area = (area + 0.1).ToString();
                }
            }
            return (int)Math.Round(totalArea, 0);
        }
    }
}
