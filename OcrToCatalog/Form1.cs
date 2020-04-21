using IronOcr;
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

namespace OcrToCatalog
{
    public partial class Form1 : Form
    {
        private List<string> ImagePaths = new List<string>();
        private List<string> ImageName = new List<string>();
        private int Count = 0;//图片计数器
        private int markflag;//第几个图片
        private string sss;//临时保存字符串变量
        private string CurPath, SavePath;//当前选择的图片路径
        private int imgWidth, imgHeight;//图片的宽和高
        private string zjhtext, xmtext, sjtext;//阅卷人姓名，阅卷人证件号，当前时间
        private string sourceFolder;//源图片的所处文件夹
        private string Fileimport, Fileexport;//文件夹批量导入地址,文件夹批量导出地址
        private string watermarkLocation;
        private string pathname = string.Empty;
        private bool fontbtnflag = false;  //判断选择的水印字体是否触发过

        private void prebtn_Click(object sender, EventArgs e)
        {
            if (markflag == 0)
            {
                markflag = Count - 1;
                sss = ImagePaths[markflag];
            }
            else
            {
                markflag--;
                sss = ImagePaths[markflag];
            }
            Mtext.Text = sss;
            this.pictureBox.Image.Dispose();
            this.pictureBox.Load(sss);
        }

        private void nextbtn_Click(object sender, EventArgs e)
        {
            if (markflag == Count - 1)
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
            this.pictureBox.Image.Dispose();
            this.pictureBox.Load(sss);
        }

        private bool colorbtnflag = false;  //判断选择的水印字体颜色是否触发过
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"/Skins/OneBlue.ssk";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Ocr = new AdvancedOcr()
            {
                CleanBackgroundNoise = true,
                EnhanceContrast = true,
                EnhanceResolution = true,
                Language = IronOcr.Languages.ChineseSimplified.OcrLanguagePack,
                Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
                ColorSpace = AdvancedOcr.OcrColorSpace.Color,
                DetectWhiteTextOnDarkBackgrounds = true,
                InputImageType = AdvancedOcr.InputTypes.AutoDetect,
                RotateAndStraighten = true,
                ReadBarCodes = true,
                ColorDepth = 4
            };

            //var Ocr = new IronOcr.AutoOcr();
            var Result = Ocr.Read(Mtext.Text);
            richTextBox.Text = Result.Text;
            
        }

        private void selectbutton_Click(object sender, EventArgs e)
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
                    foreach (string pathss in Directory.GetFiles(sourceFolder, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".jpg") || s.EndsWith(".tif")))
                    {
                        ImagePaths.Add(pathss);
                        Count++;
                    }
                    for (int i = 0; i < Count; i++)
                    {
                        if (ImagePaths[i] == pathname)
                        {
                            markflag = i;
                        }
                    }
                    this.pictureBox.Load(pathname);
                    Mtext.Text = pathname;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                DirectoryInfo directoryInfo = new DirectoryInfo(sourceFolder);
                {
                    FileInfo[] fileInfosjpg = directoryInfo.GetFiles("*.jpg");
                    foreach (FileInfo info in fileInfosjpg)
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
    }
}
