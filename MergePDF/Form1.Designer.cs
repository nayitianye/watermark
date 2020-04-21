namespace MergePDF
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Merge_InputDectory_Button = new System.Windows.Forms.Button();
            this.Merge_OutputDectory_Button = new System.Windows.Forms.Button();
            this.MergeButton = new System.Windows.Forms.Button();
            this.MergePdfName = new System.Windows.Forms.TextBox();
            this.Merge_InputDectory_Text = new System.Windows.Forms.Label();
            this.Merge_OutputDectory_Text = new System.Windows.Forms.Label();
            this.Merge_InputDectory_Dialog = new System.Windows.Forms.FolderBrowserDialog();
            this.Merge_OutputDectory_Dialog = new System.Windows.Forms.FolderBrowserDialog();
            this.Tips1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Split_IntputPdfPath_Button = new System.Windows.Forms.Button();
            this.Split_InputPdfPath_Text = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Split_OutputPdfDectory_Button = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Tips2 = new System.Windows.Forms.Label();
            this.SplitButton = new System.Windows.Forms.Button();
            this.Split_OutputDectory_Text = new System.Windows.Forms.Label();
            this.Split_OutputPdfDectory_Dialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.PdfNum = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PdfPageList = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Split_InputPdfPath_Dialog = new System.Windows.Forms.OpenFileDialog();
            this.label11 = new System.Windows.Forms.Label();
            this.StartPage = new System.Windows.Forms.TextBox();
            this.EndPage = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Tips3 = new System.Windows.Forms.Label();
            this.CopyButton = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.CopyPdfName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "导入PDF目录:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "导出PDF目录:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "合并后的文件名称：";
            // 
            // Merge_InputDectory_Button
            // 
            this.Merge_InputDectory_Button.Location = new System.Drawing.Point(199, 12);
            this.Merge_InputDectory_Button.Name = "Merge_InputDectory_Button";
            this.Merge_InputDectory_Button.Size = new System.Drawing.Size(163, 42);
            this.Merge_InputDectory_Button.TabIndex = 4;
            this.Merge_InputDectory_Button.Text = "InputDectory";
            this.Merge_InputDectory_Button.UseVisualStyleBackColor = true;
            this.Merge_InputDectory_Button.Click += new System.EventHandler(this.Merge_InputDectory_Button_Click);
            // 
            // Merge_OutputDectory_Button
            // 
            this.Merge_OutputDectory_Button.Location = new System.Drawing.Point(199, 70);
            this.Merge_OutputDectory_Button.Name = "Merge_OutputDectory_Button";
            this.Merge_OutputDectory_Button.Size = new System.Drawing.Size(163, 42);
            this.Merge_OutputDectory_Button.TabIndex = 5;
            this.Merge_OutputDectory_Button.Text = "OutDectory";
            this.Merge_OutputDectory_Button.UseVisualStyleBackColor = true;
            this.Merge_OutputDectory_Button.Click += new System.EventHandler(this.Merge_OutputDectory_Button_Click);
            // 
            // MergeButton
            // 
            this.MergeButton.Location = new System.Drawing.Point(233, 183);
            this.MergeButton.Name = "MergeButton";
            this.MergeButton.Size = new System.Drawing.Size(182, 46);
            this.MergeButton.TabIndex = 6;
            this.MergeButton.Text = "Merge|合并";
            this.MergeButton.UseVisualStyleBackColor = true;
            this.MergeButton.Click += new System.EventHandler(this.MergeButton_Click);
            // 
            // MergePdfName
            // 
            this.MergePdfName.Location = new System.Drawing.Point(243, 134);
            this.MergePdfName.Name = "MergePdfName";
            this.MergePdfName.Size = new System.Drawing.Size(293, 25);
            this.MergePdfName.TabIndex = 7;
            // 
            // Merge_InputDectory_Text
            // 
            this.Merge_InputDectory_Text.AutoSize = true;
            this.Merge_InputDectory_Text.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Merge_InputDectory_Text.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Merge_InputDectory_Text.Location = new System.Drawing.Point(391, 24);
            this.Merge_InputDectory_Text.Name = "Merge_InputDectory_Text";
            this.Merge_InputDectory_Text.Size = new System.Drawing.Size(189, 20);
            this.Merge_InputDectory_Text.TabIndex = 8;
            this.Merge_InputDectory_Text.Text = "Merge_InputDectory";
            // 
            // Merge_OutputDectory_Text
            // 
            this.Merge_OutputDectory_Text.AutoSize = true;
            this.Merge_OutputDectory_Text.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Merge_OutputDectory_Text.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Merge_OutputDectory_Text.Location = new System.Drawing.Point(391, 80);
            this.Merge_OutputDectory_Text.Name = "Merge_OutputDectory_Text";
            this.Merge_OutputDectory_Text.Size = new System.Drawing.Size(199, 20);
            this.Merge_OutputDectory_Text.TabIndex = 9;
            this.Merge_OutputDectory_Text.Text = "Merge_OutputDectory";
            // 
            // Tips1
            // 
            this.Tips1.AutoSize = true;
            this.Tips1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tips1.ForeColor = System.Drawing.Color.Red;
            this.Tips1.Location = new System.Drawing.Point(112, 192);
            this.Tips1.Name = "Tips1";
            this.Tips1.Size = new System.Drawing.Size(46, 24);
            this.Tips1.TabIndex = 10;
            this.Tips1.Text = "END";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(24, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "提示：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(24, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "选择分页的PDF:";
            // 
            // Split_IntputPdfPath_Button
            // 
            this.Split_IntputPdfPath_Button.Location = new System.Drawing.Point(199, 249);
            this.Split_IntputPdfPath_Button.Name = "Split_IntputPdfPath_Button";
            this.Split_IntputPdfPath_Button.Size = new System.Drawing.Size(163, 42);
            this.Split_IntputPdfPath_Button.TabIndex = 13;
            this.Split_IntputPdfPath_Button.Text = "ChoosePDF";
            this.Split_IntputPdfPath_Button.UseVisualStyleBackColor = true;
            this.Split_IntputPdfPath_Button.Click += new System.EventHandler(this.Split_IntputPdfPath_Button_Click);
            // 
            // Split_InputPdfPath_Text
            // 
            this.Split_InputPdfPath_Text.AutoSize = true;
            this.Split_InputPdfPath_Text.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Split_InputPdfPath_Text.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Split_InputPdfPath_Text.Location = new System.Drawing.Point(391, 266);
            this.Split_InputPdfPath_Text.Name = "Split_InputPdfPath_Text";
            this.Split_InputPdfPath_Text.Size = new System.Drawing.Size(189, 20);
            this.Split_InputPdfPath_Text.TabIndex = 14;
            this.Split_InputPdfPath_Text.Text = "Split_InputPdfPath";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(24, 316);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 24);
            this.label7.TabIndex = 15;
            this.label7.Text = "导出文件目录:";
            // 
            // Split_OutputPdfDectory_Button
            // 
            this.Split_OutputPdfDectory_Button.Location = new System.Drawing.Point(199, 309);
            this.Split_OutputPdfDectory_Button.Name = "Split_OutputPdfDectory_Button";
            this.Split_OutputPdfDectory_Button.Size = new System.Drawing.Size(163, 42);
            this.Split_OutputPdfDectory_Button.TabIndex = 16;
            this.Split_OutputPdfDectory_Button.Text = "OutDectory";
            this.Split_OutputPdfDectory_Button.UseVisualStyleBackColor = true;
            this.Split_OutputPdfDectory_Button.Click += new System.EventHandler(this.Split_OutputPdfDectory_Button_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(24, 447);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 24);
            this.label8.TabIndex = 18;
            this.label8.Text = "提示：";
            // 
            // Tips2
            // 
            this.Tips2.AutoSize = true;
            this.Tips2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tips2.ForeColor = System.Drawing.Color.Red;
            this.Tips2.Location = new System.Drawing.Point(112, 447);
            this.Tips2.Name = "Tips2";
            this.Tips2.Size = new System.Drawing.Size(46, 24);
            this.Tips2.TabIndex = 17;
            this.Tips2.Text = "END";
            // 
            // SplitButton
            // 
            this.SplitButton.Location = new System.Drawing.Point(233, 438);
            this.SplitButton.Name = "SplitButton";
            this.SplitButton.Size = new System.Drawing.Size(182, 46);
            this.SplitButton.TabIndex = 19;
            this.SplitButton.Text = "Split|分开";
            this.SplitButton.UseVisualStyleBackColor = true;
            this.SplitButton.Click += new System.EventHandler(this.SplitButton_Click);
            // 
            // Split_OutputDectory_Text
            // 
            this.Split_OutputDectory_Text.AutoSize = true;
            this.Split_OutputDectory_Text.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Split_OutputDectory_Text.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Split_OutputDectory_Text.Location = new System.Drawing.Point(391, 319);
            this.Split_OutputDectory_Text.Name = "Split_OutputDectory_Text";
            this.Split_OutputDectory_Text.Size = new System.Drawing.Size(199, 20);
            this.Split_OutputDectory_Text.TabIndex = 20;
            this.Split_OutputDectory_Text.Text = "Split_OutputDectory";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(24, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 24);
            this.label6.TabIndex = 21;
            this.label6.Text = "拆分的份数：";
            // 
            // PdfNum
            // 
            this.PdfNum.Location = new System.Drawing.Point(199, 377);
            this.PdfNum.Name = "PdfNum";
            this.PdfNum.Size = new System.Drawing.Size(132, 25);
            this.PdfNum.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(359, 377);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(238, 24);
            this.label9.TabIndex = 23;
            this.label9.Text = "每个PDF对应的页数：";
            // 
            // PdfPageList
            // 
            this.PdfPageList.Location = new System.Drawing.Point(593, 376);
            this.PdfPageList.Name = "PdfPageList";
            this.PdfPageList.Size = new System.Drawing.Size(192, 25);
            this.PdfPageList.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(514, 417);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(190, 24);
            this.label10.TabIndex = 25;
            this.label10.Text = "样例：2 3 4 5 6";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(21, 524);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(202, 24);
            this.label11.TabIndex = 26;
            this.label11.Text = "复制指定的页码：";
            // 
            // StartPage
            // 
            this.StartPage.Location = new System.Drawing.Point(363, 523);
            this.StartPage.Name = "StartPage";
            this.StartPage.Size = new System.Drawing.Size(83, 25);
            this.StartPage.TabIndex = 27;
            // 
            // EndPage
            // 
            this.EndPage.Location = new System.Drawing.Point(608, 523);
            this.EndPage.Name = "EndPage";
            this.EndPage.Size = new System.Drawing.Size(74, 25);
            this.EndPage.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(229, 525);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 24);
            this.label12.TabIndex = 29;
            this.label12.Text = "开始页码：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(467, 524);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 24);
            this.label13.TabIndex = 30;
            this.label13.Text = "结束页码：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(229, 652);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 24);
            this.label14.TabIndex = 31;
            this.label14.Text = "提示：";
            // 
            // Tips3
            // 
            this.Tips3.AutoSize = true;
            this.Tips3.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tips3.ForeColor = System.Drawing.Color.Red;
            this.Tips3.Location = new System.Drawing.Point(317, 652);
            this.Tips3.Name = "Tips3";
            this.Tips3.Size = new System.Drawing.Size(46, 24);
            this.Tips3.TabIndex = 32;
            this.Tips3.Text = "END";
            // 
            // CopyButton
            // 
            this.CopyButton.Location = new System.Drawing.Point(20, 643);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(182, 46);
            this.CopyButton.TabIndex = 33;
            this.CopyButton.Text = "Copy|复制";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(24, 587);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(226, 24);
            this.label16.TabIndex = 34;
            this.label16.Text = "复制后的文件名称：";
            // 
            // CopyPdfName
            // 
            this.CopyPdfName.Location = new System.Drawing.Point(243, 586);
            this.CopyPdfName.Name = "CopyPdfName";
            this.CopyPdfName.Size = new System.Drawing.Size(293, 25);
            this.CopyPdfName.TabIndex = 35;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 818);
            this.Controls.Add(this.CopyPdfName);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.Tips3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.EndPage);
            this.Controls.Add(this.StartPage);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.PdfPageList);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PdfNum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Split_OutputDectory_Text);
            this.Controls.Add(this.SplitButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Tips2);
            this.Controls.Add(this.Split_OutputPdfDectory_Button);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Split_InputPdfPath_Text);
            this.Controls.Add(this.Split_IntputPdfPath_Button);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Tips1);
            this.Controls.Add(this.Merge_OutputDectory_Text);
            this.Controls.Add(this.Merge_InputDectory_Text);
            this.Controls.Add(this.MergePdfName);
            this.Controls.Add(this.MergeButton);
            this.Controls.Add(this.Merge_OutputDectory_Button);
            this.Controls.Add(this.Merge_InputDectory_Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Merge_InputDectory_Button;
        private System.Windows.Forms.Button Merge_OutputDectory_Button;
        private System.Windows.Forms.Button MergeButton;
        private System.Windows.Forms.TextBox MergePdfName;
        private System.Windows.Forms.Label Merge_InputDectory_Text;
        private System.Windows.Forms.Label Merge_OutputDectory_Text;
        private System.Windows.Forms.FolderBrowserDialog Merge_InputDectory_Dialog;
        private System.Windows.Forms.FolderBrowserDialog Merge_OutputDectory_Dialog;
        private System.Windows.Forms.Label Tips1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Split_IntputPdfPath_Button;
        private System.Windows.Forms.Label Split_InputPdfPath_Text;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Split_OutputPdfDectory_Button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Tips2;
        private System.Windows.Forms.Button SplitButton;
        private System.Windows.Forms.Label Split_OutputDectory_Text;
        private System.Windows.Forms.FolderBrowserDialog Split_OutputPdfDectory_Dialog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PdfNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox PdfPageList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.OpenFileDialog Split_InputPdfPath_Dialog;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox StartPage;
        private System.Windows.Forms.TextBox EndPage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label Tips3;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox CopyPdfName;
    }
}

