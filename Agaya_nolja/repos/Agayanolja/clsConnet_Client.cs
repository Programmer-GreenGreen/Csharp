using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Net;
using System.Net.Sockets;

namespace Agayanolja
{
    public class clsConnet_Client
    {
        public static string data = null;

        private Socket listenter = null;
        private Socket handler = null;

        private byte[] bytes = new byte[1024];

        public clsConnet_Client()
        {

        }

        public static string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    return localIP;
                }
            }

            return "127. 0. 0. 1";
        }

        public static string TruncateLeft(string value, int maxLengh)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLengh ? value : value.Substring(0, maxLengh);
        }

        public void Connet()
        {
            //bool bRet = false;

            new Thread(delegate ()
            {
                IPAddress localIPAddress = IPAddress.Parse(LocalIPAddress());
                IPEndPoint localEndPoint = new IPEndPoint(localIPAddress, 12000);

                listenter = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listenter.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

                try
                {
                    new Thread(delegate ()
                    {
                        listenter.Bind(localEndPoint);
                        listenter.Listen(10);

                        while (true)
                        {
                            //Invoke((MethodInvoker)delegate
                            //{
                            //textBox2.Items.Add("Waiting for connections...");
                            //});

                            handler = listenter.Accept();
                            //Invoke((MethodInvoker)delegate
                            //{
                                
                                //listBox1.Items.Add("클라이언트 연결... OK");
                            //});
                        }
                    }).Start();
                }
                catch (SocketException se)
                {
                    //MessageBox.Show("SecketException Error : " + se.ToString());
                    switch (se.SocketErrorCode)
                    {
                        case SocketError.ConnectionAborted:
                        case SocketError.ConnectionReset:
                            handler.Shutdown(SocketShutdown.Both);
                            handler.Close();
                            
                            break;
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Exception Error : " + ex.ToString());
                }
            }).Start();

            //return bRet;
        }

        public void Send(string strMsg)
        {
            //string data = null;

            try
            {
                byte[] msg = Encoding.UTF8.GetBytes(strMsg + "<eof>");
                int bytesSent = handler.Send(msg);

                //int bytesRec = handler.Receive(bytes);
                //
                //if (bytesSent <= 0)
                //{
                //    throw new SocketException();
                //}
                //
                //data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                //Invoke((MethodInvoker)delegate
                //{
                //    listBox1.Items.Add(data);
                //});
            }
            catch (SocketException se)
            {
                //MessageBox.Show("SecketException Error : " + se.ToString());
                handler.Close();
                handler.Dispose();
            }
            catch (NullReferenceException ne)
            {
                //MessageBox.Show("현재 클라이언트와 서버가 연결되지 않았습니다.");
            }
        }
    }
}
