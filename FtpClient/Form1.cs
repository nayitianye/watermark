using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FtpClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string filename = openFileDialog.FileName;
            this.fileName.Text = filename;
            Thread thread = new Thread(new ThreadStart(delegate ()
            {
                  this.UploadFileByFtpWebRequest(filename, this.FTPServer.Text, this.Folder.Text,
                      this.UserName.Text, this.password.Text);
            }));
            thread.Start();
        }

        private bool UploadFileByFtpWebRequest(string fileName,string ftpServerIp,string path,string userName,string passoword){
            bool res = true;
            string url = string.Format("ftp://{0}/{1}/{2}", ftpServerIp, path,fileName.Substring(fileName.LastIndexOf(@"")+1));
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Credentials = new NetworkCredential(userName, passoword);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            Stream stream = request.GetRequestStream();
            FileStream fileStream = new FileStream(fileName, FileMode.Open);
            int packageSize = 1024 * 1024;
            int packageCount = (int)(fileStream.Length / packageSize);
            int rest = (int)(fileStream.Length % packageSize);
            this.BeginInvoke(new DoSomething(delegate (){
                this.progressBar.Maximum = packageCount;
                if (rest != 0) this.progressBar.Maximum += 1;
            }));
            for (int index = 0; index < packageCount; index++)
            {
                byte[] buffer = new byte[packageSize];
                fileStream.Read(buffer, 0, buffer.Length);
                stream.Write(buffer, 0, buffer.Length);
                this.BeginInvoke(new DoSomething(delegate ()
                {
                    this.progressBar.Value = index;
                }));
            }
            if (rest != 0)
            {
                byte[] buffer = new byte[rest];
                fileStream.Read(buffer, 0, buffer.Length);
                stream.Write(buffer, 0, buffer.Length);
                this.BeginInvoke(new DoSomething(delegate ()
                {
                    this.progressBar.Value += 1;
                }));
            }
            stream.Close();
            fileStream.Close();
            this.BeginInvoke(new DoSomething(delegate ()
            {
                this.progressBar.Value = 0;
            }));
            return res;
        }
        private delegate void DoSomething();
    }
}
