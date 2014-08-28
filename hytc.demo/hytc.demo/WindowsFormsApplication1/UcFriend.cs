using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class UcFriend : UserControl
    {
        public event EventHandler myDBClick;
        private frmMain frm;

        public frmMain Frm
        {
            get { return frm; }
            set { frm = value; }
        }

        private Friend curFriend;

        public Friend CurFriend
        {
            get { return curFriend; }
            set { 
                curFriend = value;
                this.lblNickName.Text = value.NickName;
                this.lblShuoShuo.Text = value.ShuoShuo;
                this.picHeadImage.Image = this.frm.ilHeadimages.Images[value.HeadImageIndex];
            }
        }
        public UcFriend()
        {
            InitializeComponent();
        }

        private void UcFriend_Load(object sender, EventArgs e)
        {

        }

        private void picHeadImage_DoubleClick(object sender, EventArgs e)
        {
            this.myDBClick(this,e);

        }

        private void lblShuoShuo_DoubleClick(object sender, EventArgs e)
        {
            this.myDBClick(this, e);
        }
    }
}
