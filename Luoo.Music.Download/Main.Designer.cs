namespace Luoo.Music.Download
{
    partial class Main
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_vol = new System.Windows.Forms.TextBox();
            this.btn_AddVolume = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_vols = new System.Windows.Forms.Label();
            this.btn_Download = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_SNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_CurrentIndex = new System.Windows.Forms.Label();
            this.lbl_CurrentText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入要下载哪一期的歌曲：vol.";
            // 
            // txt_vol
            // 
            this.txt_vol.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_vol.Location = new System.Drawing.Point(194, 31);
            this.txt_vol.MaxLength = 4;
            this.txt_vol.Name = "txt_vol";
            this.txt_vol.Size = new System.Drawing.Size(32, 21);
            this.txt_vol.TabIndex = 1;
            this.txt_vol.Text = "001";
            // 
            // btn_AddVolume
            // 
            this.btn_AddVolume.Location = new System.Drawing.Point(259, 29);
            this.btn_AddVolume.Name = "btn_AddVolume";
            this.btn_AddVolume.Size = new System.Drawing.Size(75, 23);
            this.btn_AddVolume.TabIndex = 2;
            this.btn_AddVolume.Text = "添加";
            this.btn_AddVolume.UseVisualStyleBackColor = true;
            this.btn_AddVolume.Click += new System.EventHandler(this.btn_AddVolume_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "要下载的Vol：";
            // 
            // lbl_vols
            // 
            this.lbl_vols.AutoSize = true;
            this.lbl_vols.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_vols.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_vols.Location = new System.Drawing.Point(93, 106);
            this.lbl_vols.Name = "lbl_vols";
            this.lbl_vols.Size = new System.Drawing.Size(0, 12);
            this.lbl_vols.TabIndex = 4;
            // 
            // btn_Download
            // 
            this.btn_Download.Enabled = false;
            this.btn_Download.Location = new System.Drawing.Point(151, 163);
            this.btn_Download.Name = "btn_Download";
            this.btn_Download.Size = new System.Drawing.Size(75, 23);
            this.btn_Download.TabIndex = 5;
            this.btn_Download.Text = "开始下载";
            this.btn_Download.UseVisualStyleBackColor = true;
            this.btn_Download.Click += new System.EventHandler(this.btn_Download_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "哪几首歌（可选）：";
            // 
            // txt_SNumber
            // 
            this.txt_SNumber.Location = new System.Drawing.Point(122, 72);
            this.txt_SNumber.Name = "txt_SNumber";
            this.txt_SNumber.Size = new System.Drawing.Size(115, 21);
            this.txt_SNumber.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "例：1,2,3";
            // 
            // lbl_CurrentIndex
            // 
            this.lbl_CurrentIndex.AutoSize = true;
            this.lbl_CurrentIndex.Location = new System.Drawing.Point(13, 141);
            this.lbl_CurrentIndex.Name = "lbl_CurrentIndex";
            this.lbl_CurrentIndex.Size = new System.Drawing.Size(77, 12);
            this.lbl_CurrentIndex.TabIndex = 9;
            this.lbl_CurrentIndex.Text = "当前下载第：";
            // 
            // lbl_CurrentText
            // 
            this.lbl_CurrentText.AutoSize = true;
            this.lbl_CurrentText.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_CurrentText.ForeColor = System.Drawing.Color.Green;
            this.lbl_CurrentText.Location = new System.Drawing.Point(95, 140);
            this.lbl_CurrentText.Name = "lbl_CurrentText";
            this.lbl_CurrentText.Size = new System.Drawing.Size(0, 12);
            this.lbl_CurrentText.TabIndex = 10;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 211);
            this.Controls.Add(this.lbl_CurrentText);
            this.Controls.Add(this.lbl_CurrentIndex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_SNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Download);
            this.Controls.Add(this.lbl_vols);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_AddVolume);
            this.Controls.Add(this.txt_vol);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(370, 250);
            this.MinimumSize = new System.Drawing.Size(370, 250);
            this.Name = "Main";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "落网音乐下载器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_vol;
        private System.Windows.Forms.Button btn_AddVolume;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_vols;
        private System.Windows.Forms.Button btn_Download;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_SNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_CurrentIndex;
        private System.Windows.Forms.Label lbl_CurrentText;
    }
}

