﻿namespace watermarkdemo
{
    partial class 水印工具
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Mtext = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.open = new System.Windows.Forms.Button();
            this.prebtn = new System.Windows.Forms.Button();
            this.nextbtn = new System.Windows.Forms.Button();
            this.previewbtn = new System.Windows.Forms.Button();
            this.watermarkbtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.yjrxm = new System.Windows.Forms.Label();
            this.xmText = new System.Windows.Forms.TextBox();
            this.yjrzjh = new System.Windows.Forms.Label();
            this.zjhText = new System.Windows.Forms.TextBox();
            this.yjsj = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Bulkimport = new System.Windows.Forms.Button();
            this.batchexport = new System.Windows.Forms.Button();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog3 = new System.Windows.Forms.FolderBrowserDialog();
            this.WatermarkLoaction = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "提示信息：";
            // 
            // Mtext
            // 
            this.Mtext.AutoSize = true;
            this.Mtext.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Mtext.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Mtext.Location = new System.Drawing.Point(133, 19);
            this.Mtext.Name = "Mtext";
            this.Mtext.Size = new System.Drawing.Size(26, 18);
            this.Mtext.TabIndex = 1;
            this.Mtext.Text = "  ";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox.Location = new System.Drawing.Point(21, 51);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(421, 529);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(21, 597);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 23);
            this.open.TabIndex = 3;
            this.open.Text = "打开";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // prebtn
            // 
            this.prebtn.Location = new System.Drawing.Point(102, 597);
            this.prebtn.Name = "prebtn";
            this.prebtn.Size = new System.Drawing.Size(75, 23);
            this.prebtn.TabIndex = 4;
            this.prebtn.Text = "上一页";
            this.prebtn.UseVisualStyleBackColor = true;
            this.prebtn.Click += new System.EventHandler(this.prebtn_Click);
            // 
            // nextbtn
            // 
            this.nextbtn.Location = new System.Drawing.Point(183, 597);
            this.nextbtn.Name = "nextbtn";
            this.nextbtn.Size = new System.Drawing.Size(75, 23);
            this.nextbtn.TabIndex = 5;
            this.nextbtn.Text = "下一页";
            this.nextbtn.UseVisualStyleBackColor = true;
            this.nextbtn.Click += new System.EventHandler(this.nextbtn_Click);
            // 
            // previewbtn
            // 
            this.previewbtn.Location = new System.Drawing.Point(264, 597);
            this.previewbtn.Name = "previewbtn";
            this.previewbtn.Size = new System.Drawing.Size(75, 23);
            this.previewbtn.TabIndex = 6;
            this.previewbtn.Text = "预览";
            this.previewbtn.UseVisualStyleBackColor = true;
            this.previewbtn.Click += new System.EventHandler(this.previewbtn_Click);
            // 
            // watermarkbtn
            // 
            this.watermarkbtn.Location = new System.Drawing.Point(345, 597);
            this.watermarkbtn.Name = "watermarkbtn";
            this.watermarkbtn.Size = new System.Drawing.Size(97, 23);
            this.watermarkbtn.TabIndex = 7;
            this.watermarkbtn.Text = "一键加水印";
            this.watermarkbtn.UseVisualStyleBackColor = true;
            this.watermarkbtn.Click += new System.EventHandler(this.watermarkbtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(474, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "水印信息";
            // 
            // yjrxm
            // 
            this.yjrxm.AutoSize = true;
            this.yjrxm.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yjrxm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.yjrxm.Location = new System.Drawing.Point(473, 75);
            this.yjrxm.Name = "yjrxm";
            this.yjrxm.Size = new System.Drawing.Size(142, 24);
            this.yjrxm.TabIndex = 9;
            this.yjrxm.Text = "阅卷人姓名:";
            // 
            // xmText
            // 
            this.xmText.Location = new System.Drawing.Point(477, 113);
            this.xmText.Name = "xmText";
            this.xmText.Size = new System.Drawing.Size(200, 30);
            this.xmText.TabIndex = 10;
            // 
            // yjrzjh
            // 
            this.yjrzjh.AutoSize = true;
            this.yjrzjh.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yjrzjh.Location = new System.Drawing.Point(473, 163);
            this.yjrzjh.Name = "yjrzjh";
            this.yjrzjh.Size = new System.Drawing.Size(178, 24);
            this.yjrzjh.TabIndex = 11;
            this.yjrzjh.Text = "阅卷人证件号：";
            // 
            // zjhText
            // 
            this.zjhText.Location = new System.Drawing.Point(477, 197);
            this.zjhText.Name = "zjhText";
            this.zjhText.Size = new System.Drawing.Size(200, 30);
            this.zjhText.TabIndex = 12;
            // 
            // yjsj
            // 
            this.yjsj.AutoSize = true;
            this.yjsj.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yjsj.Location = new System.Drawing.Point(473, 243);
            this.yjsj.Name = "yjsj";
            this.yjsj.Size = new System.Drawing.Size(118, 24);
            this.yjsj.TabIndex = 13;
            this.yjsj.Text = "阅卷时间:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(473, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "水印位置：";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker.Location = new System.Drawing.Point(477, 281);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 30);
            this.dateTimePicker.TabIndex = 16;
            // 
            // Bulkimport
            // 
            this.Bulkimport.Location = new System.Drawing.Point(448, 597);
            this.Bulkimport.Name = "Bulkimport";
            this.Bulkimport.Size = new System.Drawing.Size(88, 23);
            this.Bulkimport.TabIndex = 17;
            this.Bulkimport.Text = "批量导入";
            this.Bulkimport.UseVisualStyleBackColor = true;
            this.Bulkimport.Click += new System.EventHandler(this.Bulkimport_Click);
            // 
            // batchexport
            // 
            this.batchexport.Location = new System.Drawing.Point(542, 597);
            this.batchexport.Name = "batchexport";
            this.batchexport.Size = new System.Drawing.Size(92, 23);
            this.batchexport.TabIndex = 18;
            this.batchexport.Text = "批量导出";
            this.batchexport.UseVisualStyleBackColor = true;
            this.batchexport.Click += new System.EventHandler(this.Batchexport_Click);
            // 
            // WatermarkLoaction
            // 
            this.WatermarkLoaction.FormattingEnabled = true;
            this.WatermarkLoaction.Items.AddRange(new object[] {
            "左上角",
            "右上角",
            "左下角",
            "右下角"});
            this.WatermarkLoaction.Location = new System.Drawing.Point(477, 363);
            this.WatermarkLoaction.Name = "WatermarkLoaction";
            this.WatermarkLoaction.Size = new System.Drawing.Size(121, 28);
            this.WatermarkLoaction.TabIndex = 19;
            this.WatermarkLoaction.SelectedIndexChanged += new System.EventHandler(this.WatermarkLoaction_SelectedIndexChanged);
            // 
            // 水印工具
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(692, 634);
            this.Controls.Add(this.WatermarkLoaction);
            this.Controls.Add(this.batchexport);
            this.Controls.Add(this.Bulkimport);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.yjsj);
            this.Controls.Add(this.zjhText);
            this.Controls.Add(this.yjrzjh);
            this.Controls.Add(this.xmText);
            this.Controls.Add(this.yjrxm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.watermarkbtn);
            this.Controls.Add(this.previewbtn);
            this.Controls.Add(this.nextbtn);
            this.Controls.Add(this.prebtn);
            this.Controls.Add(this.open);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.Mtext);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "水印工具";
            this.Text = "watermark";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Mtext;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button prebtn;
        private System.Windows.Forms.Button nextbtn;
        private System.Windows.Forms.Button previewbtn;
        private System.Windows.Forms.Button watermarkbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label yjrxm;
        private System.Windows.Forms.TextBox xmText;
        private System.Windows.Forms.Label yjrzjh;
        private System.Windows.Forms.TextBox zjhText;
        private System.Windows.Forms.Label yjsj;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button Bulkimport;
        private System.Windows.Forms.Button batchexport;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog3;
        private System.Windows.Forms.ComboBox WatermarkLoaction;
    }
}
