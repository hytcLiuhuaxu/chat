 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Operation
    {
        public delegate void delAddFriend(Friend friend);
        private frmMain _frm;

        public Operation(frmMain frm)
        {
            _frm=frm;
        }
        public static IPAddress getMyIP() 
        {
           IPAddress[] ips= Dns.GetHostByName(Dns.GetHostName()).AddressList;
            foreach(IPAddress ip in ips)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    return ip;
                }
            }
            return null;
        }
        public void listen()
        {
            UdpClient uc = new UdpClient(9527);
            while (true)
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 0);
                byte[] bmsg = uc.Receive(ref ipep);
                string msg = Encoding.Default.GetString(bmsg);
                string[] sp = msg.Split('|');
                if (sp.Length > 4)
                {
                    continue;
                }

                string spl = sp[0];
                switch (spl)
                {
                    case "LOGIN":
                       
                        if (getMyIP().ToString() == ipep.Address.ToString())
                        {
                            continue;
                        }
                        
                        Friend friend = new Friend();
                        string ci=sp[2];
                        int a = 0;
                        if( int.TryParse(ci,out a) ==false)
                        {
                            continue;
                        }
                        int curIndex = Convert.ToInt32(sp[2]);
                        if (curIndex < 0 || curIndex >= _frm.ilHeadimages.Images.Count)
                        {
                            curIndex = 0;
                        }
                        friend.HeadImageIndex = curIndex;
                        friend.NickName = sp[1];
                        friend.ShuoShuo = sp[3];
                        friend.IP = ipep.Address;
                        object[] pars = new object[1];
                        pars[0] = friend;
                        _frm.Invoke(new delAddFriend(_frm.addUcf), pars);

                        //回发 ALSOON|昵称|头像|说说
                        UdpClient ucAlso = new UdpClient();
                        string alsomsg = "ALSOON|" + _frm.txtName + "|12|小毛驴";
                        byte[] balsomsg = Encoding.Default.GetBytes(alsomsg);
                        IPEndPoint ipep2 = new IPEndPoint(friend.IP, 9527);
                        ucAlso.Send(balsomsg, balsomsg.Length, ipep2);

                        break;
                    case "ALSOON":

                       
                        Friend friend2 = new Friend();
                        int curIndex2 = Convert.ToInt32(sp[2]);
                        if (curIndex2 < 0 || curIndex2 >= _frm.ilHeadimages.Images.Count)
                        {
                            curIndex = 0;
                        }
                        friend2.HeadImageIndex = curIndex2;
                        friend2.NickName = sp[1];
                        friend2.ShuoShuo = sp[3];
                        friend2.IP = ipep.Address;
                        object[] pars2 = new object[1];
                        pars2[0] = friend2;
                        _frm.Invoke(new delAddFriend(_frm.addUcf), pars2);



                        break;

                    case "LOGOUT":
                        Panel pnlist = _frm.getPanel();
                        int deleIndex = 0;
                        foreach (UcFriend ltucf in pnlist.Controls)
                        {
                            if(ltucf.CurFriend.IP.ToString()==ipep.Address.ToString())
                            {
                                pnlist.Controls.Remove(ltucf);
                                break;
                            }
                            deleIndex++;

                           
                        }
                        for (int i = deleIndex; i < pnlist.Controls.Count; i++)
                        {
                            pnlist.Controls[i].Top = i * pnlist.Controls[0].Height;
                        }
                        break;
                    default: break;


                }

            }
        }
    }
}
