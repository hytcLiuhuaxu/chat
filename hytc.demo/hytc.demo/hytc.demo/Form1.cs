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

namespace hytc.demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

            //创建线程 开始线程
            Form1.CheckForIllegalCrossThreadCalls = false;
            Thread mythread = new Thread(new ThreadStart(listen));
            mythread.IsBackground = true;
            mythread.Start();

            //打开程序对方显示登录
            string ip = this.txtIP.Text;
            UdpClient uc = new UdpClient();
            string msg2 = "INROOM|" + this.txtName.Text;
            byte[] bmsg2 = Encoding.Default.GetBytes(msg2);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 9527);
            uc.Send(bmsg2, bmsg2.Length, ipep);
        }
        /// <summary>
        ///进行监听
        /// </summary>
        private void listen()
        {
             UdpClient uc = new UdpClient(9527);
                while (true)
                {
                    IPEndPoint ipep = new IPEndPoint(IPAddress.Any,9527);
                    byte[] bmsg= uc.Receive(ref ipep);
                    string msg = Encoding.Default.GetString(bmsg);
                    string[] smsg = msg.Split('|');
                    if (smsg[0] == "PUBLIC")
                    {
                        this.textBox2.Text +=smsg[2]+":"+smsg[1] + "\r\n";
                    }
                    if (smsg[0] == "INROOM")
                    {
                        this.textBox2.Text += smsg[1] + " 上线了" + "\r\n";
                    }
                    
                }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string ip=this.txtIP.Text;
            UdpClient uc = new UdpClient();
            string msg = "PUBLIC|" + this.txtmsg.Text+"|"+this.txtName.Text;
            byte[] bmsg = Encoding.Default.GetBytes(msg);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip),9527);
            uc.Send(bmsg,bmsg.Length,ipep);
        }
    }
}
