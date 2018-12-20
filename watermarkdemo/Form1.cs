using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
      
        //初始化
        public 水印工具()
        {
            InitializeComponent();
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            WatermarkLoaction.SelectedIndex = WatermarkLoaction.Items.IndexOf("左上角");
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
        private void open_Click(object sender, EventArgs e)
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
        private void watermarkbtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog()== DialogResult.OK)
            {
                SavePath = folderBrowserDialog1.SelectedPath;
            }
            InitWaterMark();
            Font font = new Font("黑体", 60, FontStyle.Bold);
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(120, 255, 0, 0));
            SizeF xmsizeF = new SizeF();
            SizeF zjhsizeF = new SizeF();
            SizeF sjsizeF = new SizeF();
            for (int i = 0; i < Count; i++)
            {
               //Mtext.Text = "正在处理文件:" + ImageName[i];
                CurPath = ImagePaths[i];
                 using (Image image = Image.FromFile(CurPath))
                {
                    Bitmap bitmap = new Bitmap(image);
                    imgWidth = bitmap.Width;
                    imgHeight = bitmap.Height;
                    Graphics graphics = Graphics.FromImage(bitmap);
                    graphics.DrawImage(bitmap, 0, 0);
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    graphics.DrawImage(image, new Rectangle(0, 0, imgWidth, imgHeight), 0, 0, imgWidth, imgHeight, GraphicsUnit.Pixel); 
                    //graphics.TranslateTransform(10, 10);
                    xmsizeF = graphics.MeasureString(xmtext, font);
                    zjhsizeF = graphics.MeasureString(zjhtext, font);
                    sjsizeF = graphics.MeasureString(sjtext, font);
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
                    else
                    {
                        graphics.DrawString(xmtext, font, solidBrush, new Point(imgWidth - (int)xmsizeF.Width - 5, imgHeight - (int)(sjsizeF.Height + zjhsizeF.Height + xmsizeF.Height) + 15));
                        graphics.DrawString(zjhtext, font, solidBrush, new Point(imgWidth - (int)zjhsizeF.Width - 5, imgHeight - (int)(sjsizeF.Height + zjhsizeF.Height) + 10));
                        graphics.DrawString(sjtext, font, solidBrush, new Point(imgWidth - (int)sjsizeF.Width - 5, imgHeight - (int)sjsizeF.Height + 5));
                    }
                    bitmap.Save(SavePath+"//"+ImageName[i], System.Drawing.Imaging.ImageFormat.Jpeg);
                    graphics.Dispose();
                    bitmap.Dispose();
                    image.Dispose();
                }
            }
            Mtext.Text = "一键加水印成功";
        }

        /*
        private void pdfInput_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2 = new FolderBrowserDialog();
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                Fileimport = folderBrowserDialog2.SelectedPath;
            }
            Mtext.Text = Fileimport;
        }*/

        /*
        private void pdfOutput_Click(object sender, EventArgs e)
        {
            folderBrowserDialog4 = new FolderBrowserDialog();
            if (folderBrowserDialog4.ShowDialog() == DialogResult.OK)
            {
                Fileexport = folderBrowserDialog4.SelectedPath;
            }
            PdfWaterMark(Fileimport, Fileexport);
            Mtext.Text = "pdf加水印完成";
        }
        */

        /// <summary>
        /// 给pdf文件添加水印
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destPath"></param>
        /*
        private void PdfWaterMark(string sourcePath, string destPath)
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
           
                //获取源文件下的所有pdf文件
                List<string> pdffiles = new List<string>(Directory.GetFiles(sourcePath, "*.pdf", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".pdf")));
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
                            PdfGState gs = new PdfGState();
                            for (int i = 1; i < total; i++)
                            {
                                content = pdfStamper.GetOverContent(i);//在内容上方加水印
                                //content = pdfStamper.GetUnderContent(i);//在内容下方加水印
                                gs.FillOpacity = 0.7f;//透明度
                                content.SetGState(gs);
                                //开始写入文本
                                content.BeginText();
                                content.SetColorFill(BaseColor.RED);
                                content.SetFontAndSize(pdffont,15);
                                content.SetTextMatrix(0, 0);
                                if(watermarkLocation == "左上角")
                                {
                                    content.ShowTextAligned(Element.ALIGN_TOP, xmtext, 5, height-15, 0);
                                    content.ShowTextAligned(Element.ALIGN_TOP, zjhtext, 5, height-35, 0);
                                    content.ShowTextAligned(Element.ALIGN_TOP, sjtext, 5, height-55, 0);
                                }else if (watermarkLocation == "右上角")
                                {
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, xmtext, width-5, height - 15, 0);
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, zjhtext, width-5, height - 35, 0);
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, sjtext, width-5, height - 55, 0);

                                }
                                else if (watermarkLocation == "左下角")
                                {
                                    content.ShowTextAligned(Element.ALIGN_TOP, xmtext, 5, 45, 0);
                                    content.ShowTextAligned(Element.ALIGN_TOP, zjhtext, 5, 25, 0);
                                    content.ShowTextAligned(Element.ALIGN_TOP, sjtext, 5, 5, 0);
                                }
                                else
                                {
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, xmtext, width-5, 45, 0);
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, zjhtext, width-5, 25, 0);
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, sjtext, width-5, 5, 0);
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
        */
     

        //初始化水印的三个字段
        public void InitWaterMark()
        {
            xmtext = yjrxm.Text + xmText.Text;
            zjhtext = yjrzjh.Text + zjhText.Text;
            sjtext = yjsj.Text + dateTimePicker.Text;    
        }
       
        //上一页
        private void prebtn_Click(object sender, EventArgs e)
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
        private void nextbtn_Click(object sender, EventArgs e)
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
        private void previewbtn_Click(object sender, EventArgs e)
        {
            this.pictureBox.Image.Dispose();
            CurPath = ImagePaths[markflag];
            InitWaterMark();
            Font font = new Font("黑体", 60, FontStyle.Bold);
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(120, 255, 0, 0));
            using (Image image = System.Drawing.Image.FromFile(CurPath))
            {
                Bitmap bitmap = new Bitmap(image);
                imgWidth = bitmap.Width;
                imgHeight = bitmap.Height;
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.DrawImage(bitmap, 0, 0);
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(image, new Rectangle(0, 0, imgWidth,imgHeight), 0, 0, imgWidth, imgHeight, GraphicsUnit.Pixel);       
                SizeF xmsizeF = new SizeF();
                xmsizeF = graphics.MeasureString(xmtext, font);
                SizeF zjhsizeF = new SizeF();
                zjhsizeF = graphics.MeasureString(zjhtext, font);
                SizeF sjsizeF = new SizeF();
                sjsizeF = graphics.MeasureString(sjtext, font);
                if(watermarkLocation == "左上角"){
                    graphics.DrawString(xmtext, font, solidBrush, new Point(5, 5));
                    graphics.DrawString(zjhtext, font, solidBrush, new Point(5, (int)xmsizeF.Height+10));
                    graphics.DrawString(sjtext, font, solidBrush, new Point(5, (int)(xmsizeF.Height+zjhsizeF.Height+15)));
                }
                else if(watermarkLocation=="右上角")
                {
                    graphics.DrawString(xmtext, font, solidBrush, new Point(imgWidth-(int)xmsizeF.Width-5, 5));
                    graphics.DrawString(zjhtext, font, solidBrush, new Point(imgWidth-(int)zjhsizeF.Width-5, (int)xmsizeF.Height + 10));
                    graphics.DrawString(sjtext, font, solidBrush, new Point(imgWidth-(int)sjsizeF.Width-5, (int)(xmsizeF.Height + zjhsizeF.Height + 15)));
                }
                else if (watermarkLocation == "左下角")
                {
                    graphics.DrawString(xmtext, font, solidBrush, new Point(5, imgHeight - (int)(sjsizeF.Height + zjhsizeF.Height+xmsizeF.Height) + 15));
                    graphics.DrawString(zjhtext, font, solidBrush, new Point(5, imgHeight - (int)(sjsizeF.Height +zjhsizeF.Height)+ 10));
                    graphics.DrawString(sjtext, font, solidBrush, new Point(5, imgHeight-(int)sjsizeF.Height+5));
                }
                else
                {
                    graphics.DrawString(xmtext, font, solidBrush, new Point(imgWidth - (int)xmsizeF.Width - 5, imgHeight - (int)(sjsizeF.Height + zjhsizeF.Height + xmsizeF.Height) + 15));
                    graphics.DrawString(zjhtext, font, solidBrush, new Point(imgWidth - (int)zjhsizeF.Width - 5, imgHeight - (int)(sjsizeF.Height + zjhsizeF.Height) + 10));
                    graphics.DrawString(sjtext, font, solidBrush, new Point(imgWidth - (int)sjsizeF.Width - 5, imgHeight - (int)sjsizeF.Height + 5));
                }
                this.pictureBox.Image=bitmap;
                graphics.Dispose();
                image.Dispose();
            }
        }

        //拷贝源文件夹下的所有文件和文件夹到目标文件夹下
        public  void CopyFolder(string sourcePath, string destPath)
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
                Font font = new Font("黑体", 60, FontStyle.Bold);
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(120, 255, 0, 0));
                SizeF xmsizeF = new SizeF();
                SizeF zjhsizeF = new SizeF();
                SizeF sjsizeF = new SizeF();
                //获得源文件下所有图片文件
                List<string> files = new List<string>(Directory.GetFiles(sourcePath, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".jpg") || s.EndsWith(".tif")));
                files.ForEach(c =>
                {
                    string destFile = Path.Combine(new string[] { destPath, Path.GetFileName(c) });//destFile目标文件名    destPath目标地址
                    using (System.Drawing.Image image = Image.FromFile(c))
                    {
                        Bitmap bitmap = new Bitmap(image);
                        imgWidth = bitmap.Width;
                        imgHeight = bitmap.Height;
                        Graphics graphics = Graphics.FromImage(bitmap);
                        graphics.DrawImage(bitmap, 0, 0);
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        graphics.DrawImage(image, new System.Drawing.Rectangle(0, 0, imgWidth, imgHeight), 0, 0, imgWidth, imgHeight, GraphicsUnit.Pixel);
                        xmsizeF = graphics.MeasureString(xmtext, font);
                        zjhsizeF = graphics.MeasureString(zjhtext, font);
                        sjsizeF = graphics.MeasureString(sjtext, font);
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
                        else
                        {
                            graphics.DrawString(xmtext, font, solidBrush, new Point(imgWidth - (int)xmsizeF.Width - 5, imgHeight - (int)(sjsizeF.Height + zjhsizeF.Height + xmsizeF.Height) + 15));
                            graphics.DrawString(zjhtext, font, solidBrush, new Point(imgWidth - (int)zjhsizeF.Width - 5, imgHeight - (int)(sjsizeF.Height + zjhsizeF.Height) + 10));
                            graphics.DrawString(sjtext, font, solidBrush, new Point(imgWidth - (int)sjsizeF.Width - 5, imgHeight - (int)sjsizeF.Height + 5));
                        }
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
                            PdfGState gs = new PdfGState();
                            for (int i = 1; i < total; i++)
                            {
                                content = pdfStamper.GetOverContent(i);//在内容上方加水印
                                //content = pdfStamper.GetUnderContent(i);//在内容下方加水印
                                gs.FillOpacity = 0.7f;//透明度
                                content.SetGState(gs);
                                //content.SetGrayFill(0.3f);
                                //开始写入文本
                                content.BeginText();
                                content.SetColorFill(BaseColor.RED);
                                content.SetFontAndSize(pdffont, 15);
                                content.SetTextMatrix(0, 0);
                                if (watermarkLocation == "左上角")
                                {
                                    content.ShowTextAligned(Element.ALIGN_TOP, xmtext, 5, height - 20, 0);
                                    content.ShowTextAligned(Element.ALIGN_TOP, zjhtext, 5, height - 40, 0);
                                    content.ShowTextAligned(Element.ALIGN_TOP, sjtext, 5, height - 60, 0);
                                }
                                else if (watermarkLocation == "右上角")
                                {
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, xmtext, width - 5, height - 20, 0);
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, zjhtext, width - 5, height - 40, 0);
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, sjtext, width - 5, height - 60, 0);

                                }
                                else if (watermarkLocation == "左下角")
                                {
                                    content.ShowTextAligned(Element.ALIGN_TOP, xmtext, 5, 48, 0);
                                    content.ShowTextAligned(Element.ALIGN_TOP, zjhtext, 5, 28, 0);
                                    content.ShowTextAligned(Element.ALIGN_TOP, sjtext, 5, 8, 0);
                                }
                                else
                                {
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, xmtext, width - 5, 48, 0);
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, zjhtext, width - 5, 28, 0);
                                    content.ShowTextAligned(Element.ALIGN_RIGHT, sjtext, width - 5, 8, 0);
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
    }
}
