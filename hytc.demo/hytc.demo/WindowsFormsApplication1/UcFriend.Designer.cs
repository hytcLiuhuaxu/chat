namespace WindowsFormsApplication1
{
    partial class UcFriend
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcFriend));
            this.picHeadImage = new System.Windows.Forms.PictureBox();
            this.lblNickName = new System.Windows.Forms.Label();
            this.lblShuoShuo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picHeadImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picHeadImage
            // 
            this.picHeadImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.picHeadImage.Image = ((System.Drawing.Image)(resources.GetObject("picHeadImage.Image")));
            this.picHeadImage.Location = new System.Drawing.Point(4, 4);
            this.picHeadImage.Name = "picHeadImage";
            this.picHeadImage.Size = new System.Drawing.Size(60, 60);
            this.picHeadImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHeadImage.TabIndex = 0;
            this.picHeadImage.TabStop = false;
            this.picHeadImage.DoubleClick += new System.EventHandler(this.picHeadImage_DoubleClick);
            // 
            // lblNickName
            // 
            this.lblNickName.AutoSize = true;
            this.lblNickName.Location = new System.Drawing.Point(70, 4);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(41, 12);
            this.lblNickName.TabIndex = 1;
            this.lblNickName.Text = "label1";
            // 
            // lblShuoShuo
            // 
            this.lblShuoShuo.AutoSize = true;
            this.lblShuoShuo.Location = new System.Drawing.Point(70, 39);
            this.lblShuoShuo.Name = "lblShuoShuo";
            this.lblShuoShuo.Size = new System.Drawing.Size(41, 12);
            this.lblShuoShuo.TabIndex = 1;
            this.lblShuoShuo.Text = "label1";
            this.lblShuoShuo.DoubleClick += new System.EventHandler(this.lblShuoShuo_DoubleClick);
            // 
            // UcFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblShuoShuo);
            this.Controls.Add(this.lblNickName);
            this.Controls.Add(this.picHeadImage);
            this.Name = "UcFriend";
            this.Size = new System.Drawing.Size(180, 70);
            this.Load += new System.EventHandler(this.UcFriend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHeadImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picHeadImage;
        private System.Windows.Forms.Label lblNickName;
        private System.Windows.Forms.Label lblShuoShuo;
    }
}
