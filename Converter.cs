using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using wordApplication = Microsoft.Office.Interop.Word.Application;
using excelApplication = Microsoft.Office.Interop.Excel.Application;
using System;

namespace CHTools
{
    class Converter
    {
        public object wordSave = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
        public object excelSave = Microsoft.Office.Interop.Excel.XlSaveAction.xlDoNotSaveChanges;
        public object missing = System.Reflection.Missing.Value;
        public void ConvertDocToDocx(string docFilePath, string docxFilePath)
        {
            wordApplication word = new wordApplication();
            Document doc = word.Documents.Open(docFilePath);
            doc.SaveAs2(docxFilePath, WdSaveFormat.wdFormatXMLDocument);
            doc.Close(wordSave, missing, missing);
            word.Quit(wordSave, missing, missing);
            ReleaseObject(word);
            ReleaseObject(doc);
    }

    // 将 .docx 转换为 .doc 
    public void ConvertDocxToDoc(string docxFilePath, string docFilePath)
        {
            wordApplication word = new wordApplication();
            Document docx = word.Documents.Open(docxFilePath);
            docx.SaveAs2(docFilePath, WdSaveFormat.wdFormatDocument);
            docx.Close(wordSave, missing, missing);
            word.Quit(wordSave, missing, missing);
            ReleaseObject(word);
            ReleaseObject(docx);
        }

        // 将 .xls 转换为 .xlsx
        public void ConvertXlsToXlsx(string xlsFilePath, string xlsxFilePath)
        {
            var excelApp = new excelApplication();
            var workbook = excelApp.Workbooks.Open(xlsFilePath);
            workbook.SaveAs(xlsxFilePath, XlFileFormat.xlOpenXMLWorkbook);
            workbook.Close(excelSave, missing, missing);
            excelApp.Quit();
        }

        // 将 .xlsx 转换为 .xls
        public void ConvertXlsxToXls(string xlsxFilePath, string xlsFilePath)
        {
            var excelApp = new excelApplication();
            var workbook = excelApp.Workbooks.Open(xlsxFilePath);
            workbook.SaveAs(xlsFilePath, XlFileFormat.xlWorkbookNormal);
            workbook.Close(excelSave, missing, missing);
            excelApp.Quit();
        }
 
        // 释放 COM 对象
        static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred while releasing object: " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}

