//using DocumentFormat.OpenXml;
//using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
//using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
//using Picture = DocumentFormat.OpenXml.Drawing.Picture;
//using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
//using RunProperties = DocumentFormat.OpenXml.Wordprocessing.RunProperties;
//using Table = DocumentFormat.OpenXml.Wordprocessing.Table;
//using TableCell = DocumentFormat.OpenXml.Wordprocessing.TableCell;
//using TableRow = DocumentFormat.OpenXml.Wordprocessing.TableRow;
//using Text = DocumentFormat.OpenXml.Wordprocessing.Text;

namespace CHTools
{
    public partial class Photo : Form
    {
        public List<object> Names { get; set; }
        public string NorthPath { get; set; }
        public string SouthPath { get; set; }
        public string EastPath { get; set; }
        public string WestPath { get; set; }
        public bool WeiZhang { get; set; }

        public Photo()
        {
            Load += Photo_Load;
            InitializeComponent();
        }

        private void Photo_Load(object sender, EventArgs e)
        {
            NameBox.DataSource = Names;
            NorthPicture.AllowDrop = true;
            SouthPicture.AllowDrop = true;
            EastPicture.AllowDrop = true;
            WestPicture.AllowDrop = true;
        }

        private void NorthPicture_DragDrop(object sender, DragEventArgs e)
        {
            NorthPath = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            using (var img = Image.FromFile(NorthPath))
            {
                NorthPicture.Image = new Bitmap(img);
            }
        }

        private void NorthPicture_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }
        private void SouthPicture_DragDrop(object sender, DragEventArgs e)
        {
            SouthPath = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            using (var img = Image.FromFile(SouthPath))
            {
                SouthPicture.Image = new Bitmap(img);
            }
        }

        private void SouthPicture_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }
        private void EastPicture_DragDrop(object sender, DragEventArgs e)
        {
            EastPath = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            using (var img = Image.FromFile(EastPath))
            {
                EastPicture.Image = new Bitmap(img);
            }
        }

        private void EastPicture_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }
        private void WestPicture_DragDrop(object sender, DragEventArgs e)
        {
            WestPath = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            using (var img = Image.FromFile(WestPath))
            {
                WestPicture.Image = new Bitmap(img);
            }
        }

        private void WestPicture_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void FindBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "设置保存路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveBox.Text = dialog.SelectedPath;
            }
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            string title = WeiZhang ? "违法建设测量现场照片" : "规划条件核实现场照片";

            if (!Directory.Exists(SaveBox.Text))
            {
                MessageBox.Show("请选择文件保存路径");
            }
            else
            {
                string output = SaveBox.Text + "\\现场照片-" + NameBox.Text + ".docx";

                File.Copy(@"template\现场照片模板.docx", output, true);

                using (WordprocessingDocument doc = WordprocessingDocument.Open(output, true))
                {
                    MainDocumentPart mainPart = doc.MainDocumentPart;

                    Body docPart = doc.MainDocumentPart.Document.Body;

                    var pgs = docPart.Elements<Paragraph>().FirstOrDefault();

                    var dec = docPart.Elements<Paragraph>().ElementAt(1);

                    var table = docPart.Elements<Table>().FirstOrDefault();

                    Run r1 = new Run(new Text(title))
                    {
                        RunProperties = new RunProperties(new RunFonts() { Ascii = "宋体" }, new FontSize() { Val = "30" }, new Bold() { Val = true })
                    };
                    pgs.Append(r1);

                    Run r2 = new Run(new Text("工程编号：" + NumberBox.Text + "  拍照人：" + PhotographerBox.Text + "  拍照时间：" + dateTimePicker.Text))
                    {
                        RunProperties = new RunProperties(new RunFonts() { Ascii = "宋体" }, new FontSize() { Val = "26" })
                    };
                    dec.Append(r2);

                    Utils.SetCellVal(table, 0, 0, NameBox.Text, false, false, 24);

                    TableCell cellE = table.Elements<TableRow>().ElementAtOrDefault(2).Elements<TableCell>().ElementAtOrDefault(0);
                    TableCell cellS = table.Elements<TableRow>().ElementAtOrDefault(2).Elements<TableCell>().ElementAtOrDefault(1);
                    TableCell cellW = table.Elements<TableRow>().ElementAtOrDefault(4).Elements<TableCell>().ElementAtOrDefault(0);
                    TableCell cellN = table.Elements<TableRow>().ElementAtOrDefault(4).Elements<TableCell>().ElementAtOrDefault(1);

                    ImagePart imagePartN = mainPart.AddImagePart(ImagePartType.Jpeg);

                    using (FileStream stream = new FileStream(NorthPath, FileMode.Open))
                    {
                        imagePartN.FeedData(stream);
                    }

                    ImagePart imagePartS = mainPart.AddImagePart(ImagePartType.Jpeg);

                    using (FileStream stream = new FileStream(SouthPath, FileMode.Open))
                    {
                        imagePartS.FeedData(stream);
                    }
                    ImagePart imagePartE = mainPart.AddImagePart(ImagePartType.Jpeg);

                    using (FileStream stream = new FileStream(EastPath, FileMode.Open))
                    {
                        imagePartE.FeedData(stream);
                    }
                    ImagePart imagePartW = mainPart.AddImagePart(ImagePartType.Jpeg);

                    using (FileStream stream = new FileStream(WestPath, FileMode.Open))
                    {
                        imagePartW.FeedData(stream);
                    }

                    AddImageToBody(cellN, mainPart.GetIdOfPart(imagePartN));
                    AddImageToBody(cellS, mainPart.GetIdOfPart(imagePartS));
                    AddImageToBody(cellE, mainPart.GetIdOfPart(imagePartE));
                    AddImageToBody(cellW, mainPart.GetIdOfPart(imagePartW));

                    MessageBox.Show("照片导入完成");
                }
            }
        }
        static void AddImageToBody(TableCell cell, string relationshipId)
        {
            // Define the reference of the image.
            var element =
                 new Drawing(
                     new DW.Inline(
                         new DW.Extent() { Cx = 6 * 360000L, Cy = 8 * 360000L },
                         new DW.EffectExtent()
                         {
                             LeftEdge = 0L,
                             TopEdge = 0L,
                             RightEdge = 0L,
                             BottomEdge = 0L
                         },
                         new DW.DocProperties()
                         {
                             Id = (UInt32Value)1U,
                             Name = "Picture 1"
                         },
                         new DW.NonVisualGraphicFrameDrawingProperties(
                             new A.GraphicFrameLocks() { NoChangeAspect = true }),
                         new A.Graphic(
                             new A.GraphicData(
                                 new PIC.Picture(
                                     new PIC.NonVisualPictureProperties(
                                         new PIC.NonVisualDrawingProperties()
                                         {
                                             Id = (UInt32Value)0U,
                                             Name = "New Bitmap Image.jpg"
                                         },
                                         new PIC.NonVisualPictureDrawingProperties()),
                                     new PIC.BlipFill(
                                         new A.Blip(
                                             new A.BlipExtensionList(
                                                 new A.BlipExtension()
                                                 {
                                                     Uri =
                                                        "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                 })
                                         )
                                         {
                                             Embed = relationshipId,
                                             CompressionState =
                                             A.BlipCompressionValues.Print
                                         },
                                         new A.Stretch(
                                             new A.FillRectangle())),
                                     new PIC.ShapeProperties(
                                         new A.Transform2D(
                                             new A.Offset() { X = 0, Y = 0 },
                                             new A.Extents() { Cx = 30L, Cy = 40L }),
                                         new A.PresetGeometry(
                                             new A.AdjustValueList()
                                         )
                                         { Preset = A.ShapeTypeValues.Rectangle }))
                             )
                             { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                     )
                     {
                         DistanceFromTop = (UInt32Value)0U,
                         DistanceFromBottom = (UInt32Value)0U,
                         DistanceFromLeft = (UInt32Value)0U,
                         DistanceFromRight = (UInt32Value)0U,
                         EditId = "50D07946"
                     });

            // Append the reference to body, the element should be in a Run.
            cell.Elements<Paragraph>().FirstOrDefault().Append(new Run(element));
        }
    }
}
