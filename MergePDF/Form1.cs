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

namespace MergePDF
{
    public partial class Form1 : Form
    {
        public string Directorypath = "";
        public string outpath = "";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                InputPath.Text = folderBrowserDialog1.SelectedPath;
                Directorypath = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2 = new FolderBrowserDialog();
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                OutputPath.Text = folderBrowserDialog2.SelectedPath;
                outpath = folderBrowserDialog2.SelectedPath;
            }
        }

        public static void MergePDF(string DirectoryPath,string outPath)
        {
            List<string> fileList = new List<string>();
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(DirectoryPath);
            FileInfo[] fileInfos = directoryInfo.GetFiles("*.pdf");
            foreach(FileInfo fileInfo in fileInfos)
            {
                fileList.Add(DirectoryPath + "\\" + fileInfo.Name);
            }
            MergePDFFiles(fileList, outPath);
        }

        private static void MergePDFFiles(List<string> fileList, string outMergeFile)
        {
            PdfReader reader;
            //List<PdfReader> readerList = new List<PdfReader>();
            Document document = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outMergeFile, FileMode.Create));
            document.Open();
            PdfContentByte cb = writer.DirectContent;
            PdfImportedPage newPage;
            for (int i = 0; i < fileList.Count; i++)
            {
                reader = new PdfReader(fileList[i]);
                int iPageNum = reader.NumberOfPages;
                for (int j = 1; j <= iPageNum; j++)
                {
                    document.NewPage();
                    newPage = writer.GetImportedPage(reader, j);
                    cb.AddTemplate(newPage, 0, 0);
                }
                //readerList.Add(reader);
            }
            document.Close();
            /* foreach(var rd in readerList)
             {
                rd.Close();
             }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (OutputPdfName.Text == "")
            {
                OutputPdfName.Text = "输出文件名";
            }
            MergePDF(Directorypath, outpath+"\\"+OutputPdfName.Text+".pdf");
            EndLabel.Text = "合并完成";
        }
    }
}
