using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CHTools
{
    class Utils
    {
        public static float StrToFloat(string input)
        {
            if (input != null)
            {
                float.TryParse(input, out float output);
                return output;
            }
            return (float)0;
        }

        public static string FloatStrToIntStr(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (double.TryParse(str, out double floatValue))
                {
                    int intVal = (int)Math.Round(floatValue, 0);
                    return intVal.ToString();
                }
                else
                {
                    return str;
                }
            }
            else
            {
                return "";
            }
        }

        // 替换文件保存路径
        public static string ReplacePath(string originalPath, string buildName)
        {
            string fileDir = Path.GetDirectoryName(originalPath);

            string newPath = Path.Combine(fileDir, buildName);

            return newPath;
        }


        public static string GetCellVal(Table table, int row, int col)
        {
            TableRow targetRow = table.Elements<TableRow>().ElementAtOrDefault(row);
            TableCell targetCell = targetRow.Elements<TableCell>().ElementAtOrDefault(col);
            return targetCell.InnerText;
        }
        public static string Bracketcs(string name)
        {
            if (name.Contains("("))
            {
                name.Replace("(", "（");
            }
            if (name.Contains(")"))
            {
                name.Replace(")", "）");
            }
            return name;
        }

        public static void SetCellVal(Table table, int row, int col, string newVal, bool isInt, bool isCenter, int size)
        {
            var val = isCenter ? JustificationValues.Center : JustificationValues.Left;

            TableRow targetRow = table.Elements<TableRow>().ElementAtOrDefault(row);
            TableCell targetCell = targetRow.Elements<TableCell>().ElementAtOrDefault(col);

            newVal = isInt ? Utils.FloatStrToIntStr(newVal) : newVal;

            Paragraph newParagraph = new Paragraph()
            {
                ParagraphProperties = new ParagraphProperties(new Justification() { Val = val })
            };

            Run run = new Run(new Text(newVal))
            {
                RunProperties = new RunProperties(new RunFonts() { Ascii = "宋体" }, new FontSize() { Val = size.ToString() })
            };

            newParagraph.Append(run);

            if (targetCell.Elements<Paragraph>().Any())
            {
                targetCell.RemoveAllChildren<Paragraph>();
            }

            targetCell.Append(newParagraph);
        }

        public static Dictionary<int, string> IntToChinese = new Dictionary<int, string>
        {
            { 1,"一"},
            { 2,"二"},
            { 3,"三"},
            { 4,"四"},
            { 5,"五"},
            { 6,"六"},
            { 7,"七"},
            { 8,"八"},
            { 9,"九"},
            { 10,"十"},
            { 11,"十一"},
            { 12,"十二"},
            { 13,"十三"},
            { 14,"十四"},
            { 15,"十五"},
            { 16,"十六"},
            { 17,"十七"},
            { 18,"十八"},
            { 19,"十九"},
            { 20,"二十"},
            { 21,"二十一"},
            { 22,"二十二"},
            { 23,"二十三"},
            { 24,"二十四"},
            { 25,"二十五"},
            { 26,"二十六"},
            { 27,"二十七"},
            { 28,"二十八"},
            { 29,"二十九"},
            { 30,"三十"},
        };

        public static Tuple<int, int> FindCellIndex(Table table, string targetValue)
        {
            for (int rowIndex = 0; rowIndex < table.Elements<TableRow>().Count(); rowIndex++)
            {
                var row = table.Elements<TableRow>().ElementAt(rowIndex);

                for (int colIndex = 0; colIndex < row.Elements<TableCell>().Count(); colIndex++)
                {
                    var cell = row.Elements<TableCell>().ElementAt(colIndex);

                    string cellValue = cell.InnerText;

                    if (cellValue.Equals(targetValue) && !string.IsNullOrEmpty(targetValue))
                    {
                        return Tuple.Create(rowIndex, colIndex);
                    }
                }
            }
            return null;
        }
    }
}
