namespace OcrToCatalog
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.selectbutton = new System.Windows.Forms.Button();
            this.ocrbutton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Mtext = new System.Windows.Forms.Label();
            this.prebtn = new System.Windows.Forms.Button();
            this.nextbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox.Location = new System.Drawing.Point(17, 49);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(459, 650);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(516, 47);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(478, 652);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "";
            // 
            // selectbutton
            // 
            this.selectbutton.Location = new System.Drawing.Point(12, 750);
            this.selectbutton.Name = "selectbutton";
            this.selectbutton.Size = new System.Drawing.Size(206, 78);
            this.selectbutton.TabIndex = 2;
            this.selectbutton.Text = "选择图片文件";
            this.selectbutton.UseVisualStyleBackColor = true;
            this.selectbutton.Click += new System.EventHandler(this.selectbutton_Click);
            // 
            // ocrbutton
            // 
            this.ocrbutton.Location = new System.Drawing.Point(666, 750);
            this.ocrbutton.Name = "ocrbutton";
            this.ocrbutton.Size = new System.Drawing.Size(206, 78);
            this.ocrbutton.TabIndex = 3;
            this.ocrbutton.Text = "OCR识别";
            this.ocrbutton.UseVisualStyleBackColor = true;
            this.ocrbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label.Location = new System.Drawing.Point(12, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(134, 27);
            this.label.TabIndex = 4;
            this.label.Text = "提示信息:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(152, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 27);
            this.label1.TabIndex = 5;
            // 
            // Mtext
            // 
            this.Mtext.AutoSize = true;
            this.Mtext.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Mtext.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Mtext.Location = new System.Drawing.Point(152, 12);
            this.Mtext.Name = "Mtext";
            this.Mtext.Size = new System.Drawing.Size(58, 24);
            this.Mtext.TabIndex = 6;
            this.Mtext.Text = "消息";
            // 
            // prebtn
            // 
            this.prebtn.Location = new System.Drawing.Point(239, 750);
            this.prebtn.Name = "prebtn";
            this.prebtn.Size = new System.Drawing.Size(203, 78);
            this.prebtn.TabIndex = 7;
            this.prebtn.Text = "上一页";
            this.prebtn.UseVisualStyleBackColor = true;
            this.prebtn.Click += new System.EventHandler(this.prebtn_Click);
            // 
            // nextbtn
            // 
            this.nextbtn.Location = new System.Drawing.Point(473, 750);
            this.nextbtn.Name = "nextbtn";
            this.nextbtn.Size = new System.Drawing.Size(163, 78);
            this.nextbtn.TabIndex = 8;
            this.nextbtn.Text = "下一页";
            this.nextbtn.UseVisualStyleBackColor = true;
            this.nextbtn.Click += new System.EventHandler(this.nextbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 845);
            this.Controls.Add(this.nextbtn);
            this.Controls.Add(this.prebtn);
            this.Controls.Add(this.Mtext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.ocrbutton);
            this.Controls.Add(this.selectbutton);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button selectbutton;
        private System.Windows.Forms.Button ocrbutton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Mtext;
        private System.Windows.Forms.Button prebtn;
        private System.Windows.Forms.Button nextbtn;
    }
}

