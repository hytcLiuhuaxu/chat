namespace WindowsFormsApplication1
{
    partial class FrmTalk
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtTalkList = new System.Windows.Forms.TextBox();
            this.txtTalk = new System.Windows.Forms.TextBox();
            this.btnsend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtTalkList
            // 
            this.TxtTalkList.Location = new System.Drawing.Point(13, 13);
            this.TxtTalkList.Multiline = true;
            this.TxtTalkList.Name = "TxtTalkList";
            this.TxtTalkList.Size = new System.Drawing.Size(259, 208);
            this.TxtTalkList.TabIndex = 0;
            // 
            // txtTalk
            // 
            this.txtTalk.Location = new System.Drawing.Point(13, 229);
            this.txtTalk.Name = "txtTalk";
            this.txtTalk.Size = new System.Drawing.Size(193, 21);
            this.txtTalk.TabIndex = 1;
            // 
            // btnsend
            // 
            this.btnsend.Location = new System.Drawing.Point(212, 227);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(60, 23);
            this.btnsend.TabIndex = 2;
            this.btnsend.Text = "发送";
            this.btnsend.UseVisualStyleBackColor = true;
            // 
            // FrmTalk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.txtTalk);
            this.Controls.Add(this.TxtTalkList);
            this.Name = "FrmTalk";
            this.Text = "聊天中....";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtTalkList;
        private System.Windows.Forms.TextBox txtTalk;
        private System.Windows.Forms.Button btnsend;
    }
}