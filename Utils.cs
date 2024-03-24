using DocumentFormat.OpenXml.Wordprocessing;
using System;
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

            string newPath = Path.Combine(fileDir, buildName + "-概况表.docx");

            return newPath;
        }

        public static string GetCellVal(Table table, int row, int col)
        {
            TableRow targetRow = table.Elements<TableRow>().ElementAtOrDefault(row);
            TableCell targetCell = targetRow.Elements<TableCell>().ElementAtOrDefault(col);
            return targetCell.InnerText;
        }

        public static void SetCellVal(Table table, int row, int col, string newVal, bool isInt, bool isCenter)
        {
            var val = isCenter ? JustificationValues.Center : JustificationValues.Left;

            TableRow targetRow = table.Elements<TableRow>().ElementAtOrDefault(row);
            TableCell targetCell = targetRow.Elements<TableCell>().ElementAtOrDefault(col);

            newVal = isInt ? Utils.FloatStrToIntStr(newVal) : newVal;

            Paragraph newParagraph = new Paragraph();

            ParagraphProperties paragraphProperties = new ParagraphProperties(new Justification() { Val = val });

            newParagraph.Append(paragraphProperties);

            Run run = new Run(new Text(newVal));

            RunProperties runProperties = new RunProperties(new RunFonts() { Ascii = "宋体" }, new FontSize() { Val = "24" });

            run.Append(runProperties);

            newParagraph.Append(run);

            if (targetCell.Elements<Paragraph>().Any())
            {
                targetCell.RemoveAllChildren<Paragraph>();
            }

            targetCell.Append(newParagraph);
        }

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
