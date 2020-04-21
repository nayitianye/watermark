using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MergePDF
{
    public partial class Form1 : Form
    {
        public string MergeInputDectoryPath = "";
        public string MergeOutputDectoryPath = "";
        public string SplitInputPdfPath = "";
        public string SplitOutputDectoryPath = "";
        public int SplitPdfNum;
        public List<int> SplitPdfPageList=new List<int>();
        public int StartPages;
        public int EndPages;
        public Form1()
        {
            InitializeComponent();
        }
        private void Merge_InputDectory_Button_Click(object sender, EventArgs e)
        {
            Merge_InputDectory_Dialog = new FolderBrowserDialog();
            if (Merge_InputDectory_Dialog.ShowDialog() == DialogResult.OK)
            {
                Merge_InputDectory_Text.Text = Merge_InputDectory_Dialog.SelectedPath;
                MergeInputDectoryPath = Merge_InputDectory_Dialog.SelectedPath;
            }
        }

        private void Merge_OutputDectory_Button_Click(object sender, EventArgs e)
        {
            Merge_OutputDectory_Dialog = new FolderBrowserDialog();
            if (Merge_OutputDectory_Dialog.ShowDialog() == DialogResult.OK)
            {
                Merge_OutputDectory_Text.Text = Merge_OutputDectory_Dialog.SelectedPath;
                MergeOutputDectoryPath= Merge_OutputDectory_Dialog.SelectedPath;
            }
        }

        private void Split_IntputPdfPath_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = ".";
            file.Filter = "PDF文件（*.pdf）|*.pdf;";
            file.ShowDialog();
            if (file.FileName != string.Empty)
            {
                Split_InputPdfPath_Text.Text = file.FileName;
                SplitInputPdfPath = file.FileName;
            }   
        }

        private void Split_OutputPdfDectory_Button_Click(object sender, EventArgs e)
        {
            Split_OutputPdfDectory_Dialog = new FolderBrowserDialog();
            if (Split_OutputPdfDectory_Dialog.ShowDialog() == DialogResult.OK)
            {
                Split_OutputDectory_Text.Text = Split_OutputPdfDectory_Dialog.SelectedPath;
                SplitOutputDectoryPath = Split_OutputPdfDectory_Dialog.SelectedPath;
            }
        }     

        /// <summary>
        /// 合并pdf button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MergeButton_Click(object sender, EventArgs e)
        {
            if (MergePdfName.Text == "")
            {
                MergePdfName.Text = "输出文件名";
            }
            MergePDF(MergeInputDectoryPath, MergeOutputDectoryPath + "\\" + MergePdfName.Text + ".pdf");
            Tips1.Text = "合并完成";
        }
        private void SplitButton_Click(object sender, EventArgs e)
        {
            //SplitPdfNum = Convert.ToInt32(PdfNum.Text);
            string[] pages = PdfPageList.Text.ToString().Split('#');
            foreach(string i in pages)
            {
                SplitPdfPageList.Add(Convert.ToInt32(i));
            }
            SplitPdf(SplitInputPdfPath,SplitOutputDectoryPath, SplitPdfNum, SplitPdfPageList);
            Tips2.Text = "拆分完成";
        }

        /// <summary>
        /// 获取合并文件夹下的所有PDF文件路径
        /// </summary>
        /// <param name="DirectoryPath"></param>
        /// <param name="outPath"></param>
        public static void MergePDF(string DirectoryPath, string outPath)
        {
            List<string> fileList = new List<string>();
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(DirectoryPath);
            FileInfo[] fileInfos = directoryInfo.GetFiles("*.pdf");
            foreach (FileInfo fileInfo in fileInfos)
            {
                fileList.Add(DirectoryPath + "\\" + fileInfo.Name);
            }
            MergePDFFiles(fileList, outPath);
        }

        /// <summary>
        /// 合并文件并输出
        /// </summary>
        /// <param name="fileList"></param>
        /// <param name="outMergeFile"></param>
        private static void MergePDFFiles(List<string> fileList, string outMergeFile)
        {
            PdfReader reader;
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
            }
            document.Close();
        }

        /// <summary>
        /// 分割文件
        /// </summary>
        /// <param name="FileInputPath"></param>
        /// <param name="FileOutputPath"></param>
        /// <param name="pdfnames"></param>
        /// <param name="pages"></param>
        private static void SplitPdf(string FileInputPath,string FileOutputPath,int pdfnums, List<int> pages)
        {
            int start = 1;
            int end = 0;
            for(int i = 0; i < pages.Count; i++)
            {
                end += pages[i];
                string pdfname = FileOutputPath + "\\" + start.ToString()+"-"+end.ToString() + ".pdf";
                ExtractPages(FileInputPath, pdfname, start, end);
                start += pages[i];
            }
        }

        private static void ExtractPages(string FileInputPath,string FileOutputPath,int StartPage,int EndPage)
        {
            PdfReader pdfReader = null;
            Document document = null;
            PdfCopy pdfCopy = null;
            PdfImportedPage importedPage = null;
            try
            { 
                pdfReader = new PdfReader(FileInputPath);
                document = new Document(pdfReader.GetPageSizeWithRotation(StartPage));
                pdfCopy = new PdfCopy(document, new FileStream(FileOutputPath, FileMode.Create));
                document.Open();
                for (int i = StartPage; i <= EndPage; i++)
                {
                    importedPage = pdfCopy.GetImportedPage(pdfReader, i);
                    pdfCopy.AddPage(importedPage);
                }
                document.Close();
                pdfReader.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            StartPages = Convert.ToInt32(StartPage.Text);
            EndPages = Convert.ToInt32(EndPage.Text);
            if (CopyPdfName.Text == "")
            {
                CopyPdfName.Text = "新复制的pdf";
            }
            SplitOutputDectoryPath = SplitOutputDectoryPath + "\\" + CopyPdfName.Text + ".pdf";
            ExtractPages(SplitInputPdfPath, SplitOutputDectoryPath, StartPages, EndPages);
            Tips3.Text = "复制完成，文件位置为：" + SplitOutputDectoryPath;
        }
    }
}
