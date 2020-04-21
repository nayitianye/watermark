using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Font = System.Drawing.Font;
using Image = System.Drawing.Image;
using Rectangle = System.Drawing.Rectangle;

namespace watermarkdemo
{
    public partial class 水印工具 : Form
    {
        private List<string> ImagePaths = new List<string>();
        private List<string> ImageName = new List<string> ();
        private int Count = 0;//图片计数器
        private int markflag;//第几个图片
        private string sss;//临时保存字符串变量
        private string CurPath,SavePath;//当前选择的图片路径
        private int imgWidth,imgHeight;//图片的宽和高
        private string zjhtext, xmtext, sjtext;//阅卷人姓名，阅卷人证件号，当前时间
        private string sourceFolder;//源图片的所处文件夹
        private string Fileimport, Fileexport;//文件夹批量导入地址,文件夹批量导出地址
        private string watermarkLocation;
        private string pathname = string.Empty;
        private bool fontbtnflag = false;  //判断选择的水印字体是否触发过
        private bool colorbtnflag = false;  //判断选择的水印字体颜色是否触发过
        //初始化
        public 水印工具()
        {
            InitializeComponent();
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            WatermarkLoaction.SelectedIndex = WatermarkLoaction.Items.IndexOf("左上角");
        }

        //选择文字水印的字体
        private void ChoiceFontbtn_Click(object sender, EventArgs e)
        {
            if (this.fontDialog.ShowDialog() == DialogResult.OK)
            {
                this.showlabel.Font = this.fontDialog.Font;
                Console.WriteLine(this.showlabel.Font);
                fontbtnflag = true;
            }
        }
        
        //选择文字水印的颜色
        private void ChoiceColorbtn_Click(object sender, EventArgs e)
        {
            if (this.colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.showlabel.ForeColor = this.colorDialog.Color;
                colorbtnflag = true;
            }
        }

        //批量导入文件夹
        private void Bulkimport_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2 = new FolderBrowserDialog();
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                Fileimport = folderBrowserDialog2.SelectedPath;
            }
            Mtext.Text = Fileimport;
        }

        //批量导出文件夹
        private void Batchexport_Click(object sender, EventArgs e)
        {
            folderBrowserDialog3 = new FolderBrowserDialog();
            if (folderBrowserDialog3.ShowDialog() == DialogResult.OK)
            {
                Fileexport = folderBrowserDialog3.SelectedPath;
            }
            CopyFolder(Fileimport, Fileexport);
            Mtext.Text = "导出完成";
        }

        //打开文件夹
        private void Open_Click(object sender, EventArgs e)
        {
            ImagePaths.Clear();
            ImageName.Clear();
            markflag = 0;
            Count = 0;
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = ".";
            file.Filter = "图片文件（*.jpg;*.tif）|*.jpg;*.tif;";
            file.ShowDialog();
            if (file.FileName != string.Empty)
            {
                try
                {
                    pathname = file.FileName;//获得文件的绝对路径
                    sourceFolder = Path.GetDirectoryName(file.FileName);//获取文件所在的文件夹地址
                    foreach (string pathss in Directory.GetFiles(sourceFolder,"*.*",SearchOption.TopDirectoryOnly).Where(s=>s.EndsWith(".jpg")||s.EndsWith(".tif"))) 
                    {
                        ImagePaths.Add(pathss);
                        Count++;
                    }
                    for (int i = 0; i < Count; i++)
                    {
                        if (ImagePaths[i] == pathname)
                        {
                            markflag = i ;
                        }
                    }
                    this.pictureBox.Load(pathname);
                    Mtext.Text = pathname;          
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                DirectoryInfo directoryInfo = new DirectoryInfo(sourceFolder);
                {
                    FileInfo[] fileInfosjpg = directoryInfo.GetFiles("*.jpg");  
                    foreach(FileInfo info in fileInfosjpg)
                    {
                        ImageName.Add(info.Name);
                    }
                    FileInfo[] fileInfostif = directoryInfo.GetFiles("*.tif");
                    foreach (FileInfo info in fileInfostif)
                    {
                        ImageName.Add(info.Name);
                    }
                }
            }
           
        }

        //水印位置选择变换后
        private void WatermarkLoaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            watermarkLocation = WatermarkLoaction.SelectedItem.ToString();
        }

        //给指定文件夹下面的图片加水印
        private void Watermarkbtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SavePath = folderBrowserDialog1.SelectedPath;
            }
            InitWaterMark();
            //设置水印字体
            Font font = SetFont();
            //设置水印字体的填充颜色,填充透明度
            SolidBrush solidBrush = SetColorAndTransparnece();
            for (int i = 0; i < Count; i++)
            {
                //Mtext.Text = "正在处理文件:" + ImageName[i];
                CurPath = ImagePaths[i];
                using (Image image = Image.FromFile(CurPath))
                {
                    Bitmap bitmap;
                    Graphics graphics;
                    GenerateWaterMarking(font, solidBrush, image, out bitmap, out graphics);
                    bitmap.Save(SavePath + "//" + ImageName[i], System.Drawing.Imaging.ImageFormat.Jpeg);
                    graphics.Dispose();
                    bitmap.Dispose();
                    image.Dispose();
                }
            }
            Mtext.Text = "一键加水印成功";
        }

        //上一页
        private void Prebtn_Click(object sender, EventArgs e)
        {
            if (markflag == 0)
            {
                markflag = Count-1;
                sss = ImagePaths[markflag];
            }
            else
            {
                markflag--;
                sss=ImagePaths[markflag];  
            }
            Mtext.Text = sss;
            this.pictureBox.Image.Dispose() ;
            this.pictureBox.Load(sss);
        }
        
        //下一页
        private void Nextbtn_Click(object sender, EventArgs e)
        {
            if (markflag == Count-1)
            {
                markflag = 0;
                sss = ImagePaths[markflag];    
            }
            else
            {
                markflag++;
                sss = ImagePaths[markflag];
            }
            Mtext.Text = sss;
            this.pictureBox.Image.Dispose() ;
            this.pictureBox.Load(sss);
        }

        //指定图片进行预览
        private void Previewbtn_Click(object sender, EventArgs e)
        {
            this.pictureBox.Image.Dispose();
            CurPath = ImagePaths[markflag];
            InitWaterMark();
            //设置水印字体
            Font font = SetFont();
            //设置水印字体的填充颜色,填充透明度
            SolidBrush solidBrush = SetColorAndTransparnece();
            using (Image image = System.Drawing.Image.FromFile(CurPath))
            {
                Bitmap bitmap;
                Graphics graphics;
                GenerateWaterMarking(font, solidBrush, image, out bitmap, out graphics);
                this.pictureBox.Image = bitmap;
                graphics.Dispose();
                image.Dispose();
            }
        }

        //拷贝源文件夹下的所有文件和文件夹到目标文件夹下
        public void CopyFolder(string sourcePath, string destPath)
        {
            if (Directory.Exists(sourcePath))
            {
                if (!Directory.Exists(destPath))
                {
                    //目标目录不存在则创建
                    try
                    {
                        Directory.CreateDirectory(destPath);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("创建目标目录失败：" + ex.Message);
                    }
                }
                //创建水印信息
                InitWaterMark();
                //设置水印字体
                Font font = SetFont();
                //设置水印字体的填充颜色,填充透明度
                SolidBrush solidBrush = SetColorAndTransparnece();
                //获得源文件下所有图片文件
                List<string> files = new List<string>(Directory.GetFiles(sourcePath, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".jpg") || s.EndsWith(".tif")));
                files.ForEach(c =>
                {
                    string destFile = Path.Combine(new string[] { destPath, Path.GetFileName(c) });//destFile目标文件名    destPath目标地址
                    using (System.Drawing.Image image = Image.FromFile(c))
                    {
                        Bitmap bitmap;
                        Graphics graphics;
                        GenerateWaterMarking(font, solidBrush, image, out bitmap, out graphics);
                        bitmap.Save(destFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                        graphics.Dispose();
                        bitmap.Dispose();
                        image.Dispose();
                    }
                });
                //获取源文件下的所有pdf文件
                List<string> pdffiles = new List<string>(Directory.GetFiles(sourcePath, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".pdf")));
                PdfStamper pdfStamper = null;
                pdffiles.ForEach(c =>
                {
                    string destFile = Path.Combine(new string[] { destPath, Path.GetFileName(c) });
                    using (PdfReader pdfReader = new PdfReader(c))
                    {
                        try
                        {
                            pdfStamper = new PdfStamper(pdfReader, new FileStream(destFile, FileMode.Create));
                            int total = pdfReader.NumberOfPages + 1;
                            iTextSharp.text.Rectangle psize = pdfReader.GetPageSize(1);
                            float width = psize.Width;
                            float height = psize.Height;
                            PdfContentByte content;
                            BaseFont pdffont = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\SIMFANG.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                            for (int i = 1; i < total; i++)
                            {
                                PdfGState gs = new PdfGState();
                                content = pdfStamper.GetOverContent(i);//在内容上方加水印
                                //content = pdfStamper.GetUnderContent(i);//在内容下方加水印
                                gs.FillOpacity = 0.7f;
                                if (transparenceBox.Text != "")
                                {
                                    gs.FillOpacity = (int.Parse(transparenceBox.Text) / 255);//透明度
                                }
                                content.SetGState(gs);
                                //content.SetGrayFill(0.3f);
                                //开始写入文本
                                content.BeginText();
                                content.SetColorFill(BaseColor.RED);
                                if (colorbtnflag == true)
                                {
                                    int R = this.showlabel.ForeColor.R;
                                    int G = this.showlabel.ForeColor.G;
                                    int B = this.showlabel.ForeColor.B;
                                    int A;
                                    if (transparenceBox.Text != "")
                                    {
                                        A = int.Parse(this.transparenceBox.Text);
                                    }
                                    A = 180;
                                    BaseColor baseColor = new BaseColor(R, G, B, A);
                                    content.SetColorFill(baseColor);
                                }
                                content.SetFontAndSize(pdffont, 15);
                                float fontsize = this.showlabel.Font.Size;
                                if (fontbtnflag == true)
                                {
                                    content.SetFontAndSize(pdffont, fontsize);
                                }
                                content.SetTextMatrix(0, 0);

                                if (watermarkLocation == "左上角")
                                {
                                    content.ShowTextAligned(Element.ALIGN_TOP, xmtext, 5, height - fontsize-5, 0);
                                    content.ShowTextAligned(Element.ALIGN_TOP, zjhtext, 5, height - fontsize*2-5, 0);
                                    content.ShowTextAligned(Element.ALIGN_TOP, sjtext, 5, height -fontsize*3-5, 0);
                                }
                                else if (watermarkLocation == "右上角")
                                {
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, xmtext, width - 5, height - fontsize - 5, 0);
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, zjhtext, width - 5, height - fontsize*2 - 5, 0);
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, sjtext, width - 5, height - fontsize*3 - 5, 0);

                                }
                                else if (watermarkLocation == "左下角")
                                {
                                    content.ShowTextAligned(Element.ALIGN_TOP, xmtext, 5, 5+fontsize*3, 0);
                                    content.ShowTextAligned(Element.ALIGN_TOP, zjhtext, 5, 5+fontsize*2, 0);
                                    content.ShowTextAligned(Element.ALIGN_TOP, sjtext, 5, 5+fontsize, 0);
                                }
                                else if (watermarkLocation == "右下角")
                                {
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, xmtext, width - 5, 5+fontsize*3, 0);
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, zjhtext, width - 5, 5+fontsize*2, 0);
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, sjtext, width - 5, 5+fontsize, 0);
                                }
                                else
                                {
                                    content.ShowTextAligned(Element.ALIGN_CENTER, xmtext, width / 2, height / 2 + fontsize+3, 0);
                                    content.ShowTextAligned(Element.ALIGN_CENTER, zjhtext, width / 2, height / 2, 0);
                                    content.ShowTextAligned(Element.ALIGN_CENTER, sjtext, width / 2, height / 2 - fontsize-3, 0);
                                }
                                content.EndText();
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {

                            if (pdfStamper != null)
                                pdfStamper.Close();

                            if (pdfReader != null)
                                pdfReader.Close();
                        }
                    }
                });
                //获得源文件下所有目录文件
                List<string> folders = new List<string>(Directory.GetDirectories(sourcePath));
                folders.ForEach(c =>
                {
                    string destDir = Path.Combine(new string[] { destPath, Path.GetFileName(c) });
                    //采用递归的方法实现
                    CopyFolder(c, destDir);
                });
            }
            else
            {
                throw new DirectoryNotFoundException("源目录不存在！");
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void 水印工具_Load(object sender, EventArgs e)
        {
           skinEngine1.SkinFile = Application.StartupPath + @"/Skins/OneBlue.ssk";
        }

        //初始化文字水印的三个字段
        public void InitWaterMark()
        {
            xmtext = yjrxm.Text + xmText.Text;
            zjhtext = yjrzjh.Text + zjhText.Text;
            sjtext = yjsj.Text + dateTimePicker.Text;
        }
        /// <summary>
        /// 用来设置图片所加水印的颜色和透明度
        /// </summary>
        /// <returns></returns>
        private SolidBrush SetColorAndTransparnece()
        {
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(120, 255, 0, 0));
            if (colorbtnflag == true)
            {
                int R = this.showlabel.ForeColor.R;
                int G = this.showlabel.ForeColor.G;
                int B = this.showlabel.ForeColor.B;
                int A;
                if (transparenceBox.Text != "")
                {
                    A = int.Parse(this.transparenceBox.Text);
                }
                else
                {
                    A = 180;
                }
                solidBrush = new SolidBrush(Color.FromArgb(A, R, G, B));
            }

            return solidBrush;
        }

        /// <summary>
        /// 用来设置图片所加水印的字体的，默认为黑体,大小60，字体样式为加粗
        /// </summary>
        /// <returns></returns>
        private Font SetFont()
        {
            Font font = new Font("黑体", 60, FontStyle.Bold);
            if (fontbtnflag == true)
            {
                float fontsize = this.showlabel.Font.Size * 5;
                FontStyle fontstyle = this.showlabel.Font.Style;
                string fontname = this.showlabel.Font.Name;
                font = new Font(fontname, fontsize, fontstyle);
            }
            return font;
        }
        /// <summary>
        /// 选择文字水印的位置，添加相关的文字水印
        /// </summary>
        /// <param name="font"></param>
        /// <param name="solidBrush"></param>
        /// <param name="xmsizeF"></param>
        /// <param name="zjhsizeF"></param>
        /// <param name="sjsizeF"></param>
        /// <param name="graphics"></param>
        private void AddCharacterLocation(Font font, SolidBrush solidBrush, SizeF xmsizeF, SizeF zjhsizeF, SizeF sjsizeF, Graphics graphics)
        {
            if (watermarkLocation == "左上角")
            {
                graphics.DrawString(xmtext, font, solidBrush, new Point(5, 5));
                graphics.DrawString(zjhtext, font, solidBrush, new Point(5, (int)xmsizeF.Height + 10));
                graphics.DrawString(sjtext, font, solidBrush, new Point(5, (int)(xmsizeF.Height + zjhsizeF.Height + 15)));
            }
            else if (watermarkLocation == "右上角")
            {
                graphics.DrawString(xmtext, font, solidBrush, new Point(imgWidth - (int)xmsizeF.Width - 5, 5));
                graphics.DrawString(zjhtext, font, solidBrush, new Point(imgWidth - (int)zjhsizeF.Width - 5, (int)xmsizeF.Height + 10));
                graphics.DrawString(sjtext, font, solidBrush, new Point(imgWidth - (int)sjsizeF.Width - 5, (int)(xmsizeF.Height + zjhsizeF.Height + 15)));
            }
            else if (watermarkLocation == "左下角")
            {
                graphics.DrawString(xmtext, font, solidBrush, new Point(5, imgHeight - (int)(sjsizeF.Height + zjhsizeF.Height + xmsizeF.Height) + 15));
                graphics.DrawString(zjhtext, font, solidBrush, new Point(5, imgHeight - (int)(sjsizeF.Height + zjhsizeF.Height) + 10));
                graphics.DrawString(sjtext, font, solidBrush, new Point(5, imgHeight - (int)sjsizeF.Height + 5));
            }
            else if (watermarkLocation == "右下角")
            {
                graphics.DrawString(xmtext, font, solidBrush, new Point(imgWidth - (int)xmsizeF.Width - 5, imgHeight - (int)(sjsizeF.Height + zjhsizeF.Height + xmsizeF.Height) + 15));
                graphics.DrawString(zjhtext, font, solidBrush, new Point(imgWidth - (int)zjhsizeF.Width - 5, imgHeight - (int)(sjsizeF.Height + zjhsizeF.Height) + 10));
                graphics.DrawString(sjtext, font, solidBrush, new Point(imgWidth - (int)sjsizeF.Width - 5, imgHeight - (int)sjsizeF.Height + 5));
            }
            else
            {
                graphics.DrawString(xmtext, font, solidBrush, new Point((imgWidth - (int)xmsizeF.Width) / 2, (imgHeight - (int)(sjsizeF.Height + zjhsizeF.Height + xmsizeF.Height)) / 2 - (int)zjhsizeF.Height + 10));
                graphics.DrawString(zjhtext, font, solidBrush, new Point((imgWidth - (int)zjhsizeF.Width) / 2, (imgHeight - (int)(sjsizeF.Height + zjhsizeF.Height + xmsizeF.Height)) / 2));
                graphics.DrawString(sjtext, font, solidBrush, new Point((imgWidth - (int)sjsizeF.Width) / 2, (imgHeight - (int)(sjsizeF.Height + zjhsizeF.Height + xmsizeF.Height)) / 2 + (int)zjhsizeF.Height + 10));
            }
        }

        /// <summary>
        /// 在图片上添加文字水印
        /// </summary>
        /// <param name="font"></param>
        /// <param name="solidBrush"></param>
        /// <param name="image"></param>
        /// <param name="bitmap"></param>
        /// <param name="graphics"></param>
        private void GenerateWaterMarking(Font font, SolidBrush solidBrush, Image image, out Bitmap bitmap, out Graphics graphics)
        {
            bitmap = new Bitmap(image);
            graphics = Graphics.FromImage(bitmap);
            imgWidth = bitmap.Width;
            imgHeight = bitmap.Height;
            graphics.DrawImage(bitmap, 0, 0);
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.DrawImage(image, new Rectangle(0, 0, imgWidth, imgHeight), 0, 0, imgWidth, imgHeight, GraphicsUnit.Pixel);
            SizeF xmsizeF = new SizeF();
            xmsizeF = graphics.MeasureString(xmtext, font);
            SizeF zjhsizeF = new SizeF();
            zjhsizeF = graphics.MeasureString(zjhtext, font);
            SizeF sjsizeF = new SizeF();
            sjsizeF = graphics.MeasureString(sjtext, font);
            AddCharacterLocation(font, solidBrush, xmsizeF, zjhsizeF, sjsizeF, graphics);
        }
    }
}
