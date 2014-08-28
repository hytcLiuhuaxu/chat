using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class frmMain : Form
    {
        
        public delegate void delAddFriend(Friend friend);
        public string txtName;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
           
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           IPAddress myip= Operation.getMyIP();
           if (myip == null)
           {
               MessageBox.Show("sorry");
               Application.Exit();
           }
           //开始侦听
            frmMain.CheckForIllegalCrossThreadCalls = false;
            Operation ope = new Operation(this);

            Thread th = new Thread(new ThreadStart(ope.listen));
            th.IsBackground = true;
            th.Start();

            Thread.Sleep(100);
           //开始广播
            UdpClient uc = new UdpClient();
            txtName = this.txtNickName.Text;
            string msg = "LOGIN|" + this.txtNickName.Text + "|12|小毛驴";
            byte[] bmsg = Encoding.Default.GetBytes(msg);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527);
            uc.Send(bmsg, bmsg.Length, ipep);
        }
        public void addUcf(Friend f)
        {
            UcFriend ucf = new UcFriend();
            ucf.DoubleClick += new EventHandler(ucf_DoubleClick);
            ucf.Frm=this;
            ucf.CurFriend = f;
            ucf.Top = this.pnfriendlist.Controls.Count * ucf.Height;

            ucf.myDBClick += ucf_myDBClick;
            this.pnfriendlist.Controls.Add(ucf);
        }
        void ucf_myDBClick(object sender, EventArgs e)
        {
            UcFriend ucf = (UcFriend)sender;
            FrmTalk frmtalk = new FrmTalk();
            frmtalk.Show();

        }

        void ucf_DoubleClick(object sender, EventArgs e)
        {
            UcFriend ucf = (UcFriend)sender;
            FrmTalk frmtalk =new FrmTalk();
            frmtalk.Show();
            
        }
        public Panel getPanel()
        {
            return this.pnfriendlist;
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            UdpClient uc = new UdpClient();
            string msg = "LOGOUT";
            byte[] bmsg = Encoding.Default.GetBytes(msg);
            uc.Send(bmsg, bmsg.Length, new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527));

        }

        //private void listen()
        //{
        //    UdpClient uc = new UdpClient(9527);
        //    while (true)
        //    {
        //        IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 0);
        //        byte[] bmsg = uc.Receive(ref ipep);
        //        string msg = Encoding.Default.GetString(bmsg);
        //        string[] sp = msg.Split('|');
        //        if (sp.Length != 4)
        //        {
        //            continue;
        //        }

        //        string spl = sp[0];
        //        switch (spl)
        //        {
        //            case "LOGIN":
        //                UcFriend ucf = new UcFriend();
        //                Friend friend = new Friend();
        //                int curIndex = Convert.ToInt32(sp[2]);
        //                if (curIndex < 0 || curIndex >= this.ilHeadimages.Images.Count)
        //                {
        //                    curIndex = 0;
        //                }
        //                friend.HeadImageIndex = curIndex;
        //                friend.NickName = sp[1];
        //                friend.ShuoShuo = sp[3];
        //                friend.IP = ipep.Address;
        //                object[] pars = new object[1];
        //                pars[0] = friend;
        //                this.Invoke(new delAddFriend(this.addUcf), pars);

        //                //回发 ALSOON|昵称|头像|说说
        //                UdpClient ucAlso = new UdpClient();
        //                string alsomsg = "ALSOON|" + this.txtNickName.Text + "|12|小毛驴";
        //                byte[] balsomsg = Encoding.Default.GetBytes(alsomsg);
        //                IPEndPoint ipep2 = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527);
        //                ucAlso.Send(balsomsg, balsomsg.Length, ipep2);

        //                break;
        //            case "ALSOON":

        //                UcFriend ucf2 = new UcFriend();
        //                Friend friend2 = new Friend();
        //                int curIndex2 = Convert.ToInt32(sp[2]);
        //                if (curIndex2 < 0 || curIndex2 >= this.ilHeadimages.Images.Count)
        //                {
        //                    curIndex = 0;
        //                }
        //                friend2.HeadImageIndex = curIndex2;
        //                friend2.NickName = sp[1];
        //                friend2.ShuoShuo = sp[3];
        //                friend2.IP = ipep.Address;
        //                object[] pars2 = new object[1];
        //                pars2[0] = friend2;
        //                this.Invoke(new delAddFriend(this.addUcf), pars2);



        //                break;
        //            default: break;


        //        }

        //    }
        //}
    }
}
