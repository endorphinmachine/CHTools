using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace CHTools
{
    public partial class FileTrans : Form
    {
        public static object wordSave = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
        public static object excelSave = Microsoft.Office.Interop.Excel.XlSaveAction.xlDoNotSaveChanges;
        public static object missing = System.Reflection.Missing.Value;
        public FileTrans()
        {
            InitializeComponent();
        }
        public static void DocToDocx(string inPath)
        {
            string outPath = Path.ChangeExtension(inPath, ".docx");
            Word.Application app = new Word.Application();
            Word.Document doc = app.Documents.Open(inPath);
            doc.SaveAs2(outPath, Word.WdSaveFormat.wdFormatXMLDocument);
            doc.Close(wordSave, missing, missing);
            app.Quit(wordSave, missing, missing);
            ReleaseObject(doc);
            ReleaseObject(app);
        }

        public void DocxToDoc(string inPath)
        {
            string outPath = Path.ChangeExtension(inPath, ".doc");
            Word.Application app = new Word.Application();
            Word.Document docx = app.Documents.Open(inPath);
            docx.SaveAs2(outPath, Word.WdSaveFormat.wdFormatDocument);
            docx.Close(wordSave, missing, missing);
            app.Quit(wordSave, missing, missing);
            ReleaseObject(docx);
            ReleaseObject(app);
        }

        // 将 .xls 转换为 .xlsx
        public void XlsToXlsx(string inPath)
        {
            string outPath = Path.ChangeExtension(inPath, ".xlsx");
            var app = new Excel.Application();
            var workbook = app.Workbooks.Open(inPath);
            workbook.SaveAs(outPath, Excel.XlFileFormat.xlOpenXMLWorkbook);
            workbook.Close(excelSave, missing, missing);
            app.Quit();
            ReleaseObject(workbook);
            ReleaseObject(app);
        }

        // 将 .xlsx 转换为 .xls
        public void XlsxToXls(string inPath)
        {
            string outPath = Path.ChangeExtension(inPath, ".xls");
            var app = new Excel.Application();
            var workbook = app.Workbooks.Open(inPath);
            workbook.SaveAs(outPath, Excel.XlFileFormat.xlWorkbookNormal);
            workbook.Close(excelSave, missing, missing);
            app.Quit();
            ReleaseObject(workbook);
            ReleaseObject(app);
        }
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

        private void ChooseBtn_Click(object sender, EventArgs e)
        {
            string filterText = string.Empty;
            if (ToDocx.Checked)
            {
                filterText = "*.doc | *.doc";
            }
            else if(ToDoc.Checked)
            {
                filterText = "*.docx | *.docx";
            }
            else if(ToXlsx.Checked)
            {
                filterText = "*.xls | *.xls";
            }
            else if(ToXls.Checked)
            {
                filterText = "*.xlsx| *.xlsx";
            }
            using (var openFileDialog = new OpenFileDialog { Multiselect = true })
            {
                openFileDialog.Filter = filterText;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var item in openFileDialog.FileNames)
                    {
                        InputPathBox.Text += item + "\n";
                    }
                }
            }
        }

        public void TransBtn_Click(object sender, EventArgs e)
        {
            InputPathBox.Lines = InputPathBox.Lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
            if (ToDocx.Checked)
            {
                foreach (var path in InputPathBox.Lines)
                {
                    DocToDocx(path);
                }
            }

            else if (ToDoc.Checked)
            {
                foreach (var path in InputPathBox.Lines)
                {
                    DocxToDoc(path);
                }
            }
            else if (ToXlsx.Checked)
            {
                foreach (var path in InputPathBox.Lines)
                {
                    XlsToXlsx(path);
                }
            }
            else if (ToXls.Checked)
            {
                foreach (var path in InputPathBox.Lines)
                {
                    XlsxToXls(path);
                }
            }
            MessageBox.Show("文件格式转换完成", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

