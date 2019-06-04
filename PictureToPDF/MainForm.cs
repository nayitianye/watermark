using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = System.Drawing.Image;

namespace PictureToPDF
{
    public partial class 图片转PDF工具 : Form
    {
        private List<string> ImagePaths = new List<string>();    //引入图片的地址
        private List<Image> images = new List<Image>();
        const int WWidth = 600;
        const int HHeight = 800;
        string PdfFileName = "";
        string Fileimport;   
        public 图片转PDF工具()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Fileimport = folderBrowserDialog1.SelectedPath;
            }
            MessageText.Text = Fileimport;
            GetImagePath(MessageText.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetPdfPath(PdfName.Text);
            ImageConvertToPdf(ImagePaths);
        }
        
        //设置Pdf的输出地址
        public void SetPdfPath(string path)
        {
            if (path != "")
            {
                PdfFileName = Fileimport + "//" + path;
            }
            else
            {
                PdfFileName = "C://Users//yyb//Desktop//图片转PDF.pdf";
            }
        }
        //图片转换成PDF
        public void ImageConvertToPdf(List<string> sourcepath)
        {
            ChangeTheImageToStandard(ImagePaths);
            Document document = new Document();
            document.SetPageSize(new iTextSharp.text.Rectangle(WWidth + 72f, HHeight + 72f));
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(PdfFileName, FileMode.OpenOrCreate, FileAccess.Write));
            document.Open();
            iTextSharp.text.Image image;
            for (int i = 0; i < images.Count; i++)
            {
                image = iTextSharp.text.Image.GetInstance(images[i], ImageFormat.Jpeg);
                document.NewPage();
                document.Add(image);
            }
            if (document != null && document.IsOpen())
            {
                document.Close();
            }
            if (writer != null)
            {
                writer.Close();
            }
        }
        //将所有的图片转换成标准图片
        public void ChangeTheImageToStandard(List<string> ImageName)
        {
            for(int i = 0; i < ImageName.Count; i++)
            {
                Bitmap bitmap = new Bitmap(ImageName[i]);
                Bitmap bmImage = new Bitmap(WWidth, HHeight);
                Graphics graphics = Graphics.FromImage(bmImage);
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(bitmap,new System.Drawing.Rectangle(0, 0,bmImage.Width, bmImage.Height), new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), GraphicsUnit.Pixel);
                graphics.Dispose();
                images.Add(bmImage);
            }
        }
        //获取文件夹下的所有图片的名称
        public void GetImagePath(string Fileimport)
        {
            List<string> files = new List<string>(Directory.GetFiles(Fileimport, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".jpg") || s.EndsWith(".tif")));
            files.ForEach(c =>
            {  
                string destFile = Path.Combine(new string[] { Fileimport , Path.GetFileName(c) });//destFile目标图片文件名    destPath目标地址
                ImagePaths.Add(destFile);
            });
        }
          
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
                //获得源文件下所有图片文件
                List<string> files = new List<string>(Directory.GetFiles(sourcePath, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".jpg") || s.EndsWith(".tif")));
                files.ForEach(c =>
                {
                    string destFile = Path.Combine(new string[] { destPath, Path.GetFileName(c) });//destFile目标图片文件名    destPath目标地址
                   
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
