using System;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Diagnostics;

public class TcpNetworkClientManager
{
    private NetworkStream stream = null;
    private TcpClient tcp;
    public String FaceInformationServerInHoloLensIP;

    public TcpNetworkClientManager(string IP, int port)
    {
        Thread thread = new Thread(() => {
            try
            {
                tcp = new TcpClient(IP, port);
            } catch (Exception ex)
            {
                Debug.WriteLine("Error connect to server: " + ex);
            }
            if (tcp != null && tcp.Connected)
            {
                stream = tcp.GetStream();
                try
                {
                    byte[] bytes = new byte[tcp.ReceiveBufferSize];
                    int i;
                    while (((i = stream.Read(bytes, 0, bytes.Length)) != 0))
                    {
                        //stream.Read(bytes, 0, bytes.Length);
                        string ms = Encoding.UTF8.GetString(bytes, 0, i);
                        Debug.WriteLine("ms:" + ms);
                        if (ms.ToLower() == "exit".ToLower())
                        {
                            break;
                        } else
                        {
                            FaceInformationServerInHoloLensIP = ms;
                        }
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Thead exception: " + ex);
                }
                finally
                {
                    stream.Close();
                    tcp.Close();
                }
            }           
        });
        thread.Start();
    }

    public void SendMessage(string data)
    {
        if (stream != null)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            Debug.WriteLine("SendMessage: " + bytes.ToString());
            Thread sendthread = new Thread(() => {
                stream.Write(bytes, 0, bytes.Length);
                if (data.ToLower() == "exit".ToLower())
                {
                    Close();
                }
            });
            sendthread.Start();
        }
    }

    internal void Close()
    {
        stream.Close();
        tcp.Close();
    }

    public bool IsConnected()
    {
        if (tcp!= null && tcp.Connected)
        {
            return true;
        } else
        {
            return false;
        }
    }
}