using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CHTools
{
    public partial class Tools : Form
    {
        public Project project = new Project();
        public Tools()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        // 导入Excel文件
        private void ExcelInputBtn_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog { Multiselect = true })
            {
                openFileDialog.Filter = "Excel 文件 (*.xlsx)|*.xlsx";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExcelPathBox.Text = openFileDialog.FileName;
                }
            }
        }

        // 更新建设项目信息，EXCEl文件路径变化后触发
        private void ExcelPathBox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(ExcelPathBox.Text))
            {
                BuildNameBox.Items.Clear();
                ReadExcel();
                BuildNameBox.SelectedIndex = 0;
            }
        }

        private void EPSInputButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "EPS 工程 (.edb)|*.edb";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    EPSPathBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void EPSPathBox_TextChanged(object sender, EventArgs e)
        {
            EPSOp EPSop = new EPSOp(EPSPathBox.Text);
            if (EPSop.ShowDialog() == DialogResult.OK)
            {
                NumberBox.Text = EPSop.EpsProject.Number;
                BuilderBox.Text = EPSop.EpsProject.Builder;
                DesignerBox.Text = EPSop.EpsProject.Designer;
                ContractorBox.Text = EPSop.EpsProject.Contractor;
                LocationBox.Text = EPSop.EpsProject.Location;
                JSGCGHXK.Text = EPSop.EpsProject.BJNo;
            }
        }

        // 导入Word文件
        private void WordInputBtn_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog { Multiselect = true })
            {
                openFileDialog.Filter = "Word 文档 (*.docx)|*.doc";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    WordPathBox.Items.Clear();
                    foreach (string file in openFileDialog.FileNames)
                    {
                        WordPathBox.Items.Add(file);
                        WordPathBox.SelectedIndex = 0;
                    }
                }
            }
        }

        // 生成核实概况
        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            noMatchItem.Clear();
            noMatchBuild.Clear();
            MatchedBuild.Clear();
            Cursor.Current = Cursors.WaitCursor;

            if (!File.Exists(ExcelPathBox.Text))
            {
                MessageBox.Show("请检查面积汇总表文件路径是否有误");
            }
            else if (!File.Exists(@"template\核实概况模板.docx"))
            {
                MessageBox.Show("未找到验收模板文件，请检查模板文件是否缺失");
            }
            else if (!File.Exists(@"template\违法测量模板.docx"))
            {
                MessageBox.Show("未找到违章模板文件，请检查模板文件是否缺失");
            }
            else
            {
                foreach (Build build in project.Builds)
                {
                    // 在此根据build.name搜索对应word并将路径给到下面的函数
                    Generate(build);
                }
                if (noMatchBuild.Count != 0)
                {
                    MessageBox.Show(string.Join("\n", noMatchBuild) + "\n建设项目名称未生成，请检查项目名称是否匹配",
                    "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (noMatchItem.Count != 0)
                {
                    MessageBox.Show(string.Join("\n", noMatchItem) + "\n建设项目字段未匹配，请检查字段名称并手动填写",
                    "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                MessageBox.Show(string.Join("\n", MatchedBuild) + "\n概况表已生成",
                 "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Cursor.Current = Cursors.Default;
        }

        //生成矢量数据
        private void GenVecBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string tempPath = @"template\矢量数据模板.xlsx";

            if (!File.Exists(tempPath))
            {
                MessageBox.Show("未找到矢量数据模板文件，请检查模板文件是否缺失");
            }
            else if (WordPathBox.Items.Count == 0)
            {
                MessageBox.Show("请选择核实槪况表文件");
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Title = "设置文件生成路径",

                    FileName = "+矢量数据",

                    Filter = "Excel 文件 (*.xlsx,*.xls)|*.xlsx;*.xls"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialog.FileName;
                    using (var excelPackage = new ExcelPackage(new FileInfo(tempPath)))
                    {
                        foreach (string path in WordPathBox.Items)
                        {
                            if (!string.IsNullOrWhiteSpace(path))
                            {
                                Vector vector = ReadVec(path);
                                WriteVec(excelPackage, vector);
                            }
                        }
                        FileInfo newFileInfo = new FileInfo(savePath);
                        excelPackage.SaveAs(newFileInfo);
                    }
                    MessageBox.Show("文件已保存在：" + savePath, "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        //检核槪况数据
        public void CheckBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!File.Exists(ExcelPathBox.Text))
            {
                MessageBox.Show("请检查面积汇总表文件路径是否有误");
            }
            else if (WordPathBox.Items.Count == 0)
            {
                MessageBox.Show("请选择待检查的核实槪况表文件");
            }
            else
            {
                List<object> wordPath = WordPathBox.Items.Cast<object>().ToList();

                CheckTabel checkTabel = new CheckTabel(project);

                checkTabel.WordPath = wordPath;

                checkTabel.ShowDialog();
            }
            Cursor.Current = Cursors.Default;
        }

        private void BuilderBox_TextChanged(object sender, EventArgs e)
        {
            project.Builder = BuilderBox.Text;
        }
        private void DesignerBox_TextChanged(object sender, EventArgs e)
        {
            project.Designer = DesignerBox.Text;
        }
        private void ContractorBox_TextChanged(object sender, EventArgs e)
        {
            project.Contractor = ContractorBox.Text;
        }
        private void LocationBox_TextChanged(object sender, EventArgs e)
        {
            project.Location = LocationBox.Text;
        }
        private void LicenseBox_TextChanged(object sender, EventArgs e)
        {
            project.BJNo = LicenseBox.Text;
        }
        private void ApprovmentBox_TextChanged(object sender, EventArgs e)
        {
            project.YDNo = ApprovmentBox.Text;
        }
        private void NumberBox_TextChanged(object sender, EventArgs e)
        {
            project.Number = NumberBox.Text;
        }

        private void FileBtn_Click(object sender, EventArgs e)
        {
            Form FileTrans = new FileTrans();
            FileTrans.Show();
        }
    }
 }