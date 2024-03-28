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

        public static void DocToDocx(Word.Application app, string inPath)
        {
            string outPath = Path.ChangeExtension(inPath, ".docx");
            Word.Document doc = app.Documents.Open(inPath);
            doc.SaveAs2(outPath, Word.WdSaveFormat.wdFormatXMLDocument);
            doc.Close(wordSave, missing, missing);
            GC.Collect();
        }

        public void DocxToDoc(Word.Application app, string inPath)
        {
            string outPath = Path.ChangeExtension(inPath, ".doc");
            Word.Document docx = app.Documents.Open(inPath);
            docx.SaveAs2(outPath, Word.WdSaveFormat.wdFormatDocument);
            docx.Close(wordSave, missing, missing);
            ReleaseObject(docx);
        }

        // 将 .xls 转换为 .xlsx
        public void XlsToXlsx(Excel.Application app, string inPath)
        {
            string outPath = Path.ChangeExtension(inPath, ".xlsx");
            var workbook = app.Workbooks.Open(inPath);
            workbook.SaveAs(outPath, Excel.XlFileFormat.xlOpenXMLWorkbook);
            workbook.Close(excelSave, missing, missing);
            ReleaseObject(workbook);
        }

        // 将 .xlsx 转换为 .xls
        public void XlsxToXls(Excel.Application app, string inPath)
        {
            string outPath = Path.ChangeExtension(inPath, ".xls");
            var workbook = app.Workbooks.Open(inPath);
            workbook.SaveAs(outPath, Excel.XlFileFormat.xlWorkbookNormal);
            workbook.Close(excelSave, missing, missing);
            ReleaseObject(workbook);
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
            InputPathBox.Text = string.Empty;
            string filterText = string.Empty;
            if (ToDocx.Checked)
            {
                filterText = "*.doc | *.doc";
            }
            else if (ToDoc.Checked)
            {
                filterText = "*.docx | *.docx";
            }
            else if (ToXlsx.Checked)
            {
                filterText = "*.xls | *.xls";
            }
            else if (ToXls.Checked)
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
            Cursor.Current = Cursors.WaitCursor;
            InputPathBox.Lines = InputPathBox.Lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

            if (ToDocx.Checked)
            {
                Word.Application app = new Word.Application();
                foreach (var path in InputPathBox.Lines)
                {
                    DocToDocx(app, path);
                }
                app.Quit(wordSave, missing, missing);
                ReleaseObject(app);
            }

            else if (ToDoc.Checked)
            {
                Word.Application app = new Word.Application();
                foreach (var path in InputPathBox.Lines)
                {
                    DocxToDoc(app, path);
                }
                app.Quit(wordSave, missing, missing);
                ReleaseObject(app);
            }

            else if (ToXlsx.Checked)
            {
                Excel.Application app = new Excel.Application();
                foreach (var path in InputPathBox.Lines)
                {
                    XlsToXlsx(app, path);
                }
                app.Quit();
                ReleaseObject(app);
            }

            else if (ToXls.Checked)
            {
                Excel.Application app = new Excel.Application();
                foreach (var path in InputPathBox.Lines)
                {
                    XlsxToXls(app, path);
                }
                app.Quit();
                ReleaseObject(app);
            }
            Cursor.Current = Cursors.Default;
            MessageBox.Show("文件格式转换完成", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}