using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 8488);
            TcpClient clientSocket;
            int counter = 0;
            serverSocket.Start();//start listener
            Console.WriteLine(" >> " + "Server Started");
            counter = 0;

            while (true)
            {
                counter += 1;
                clientSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine(" >> " + "Client No:" + Convert.ToString(counter) + " started!");
                handleClinet client = new handleClinet();
                client.startClient(clientSocket, Convert.ToString(counter));
            }

            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine(" >> " + "exit");
            Console.ReadLine();
        }
    }

    //Class to handle each client request separatly
    public class handleClinet
    {
        private TcpClient clientSocket;
        private string Client_nb;
        public static List<TcpClient> tcpClientsList = new List<TcpClient>();

        public void startClient(TcpClient inClientSocket, string clineNo)

        {
            tcpClientsList.Add(inClientSocket);
            clientSocket = inClientSocket;
            Client_nb = clineNo;
            Thread ctThread = new Thread(doChat);//create thread
            ctThread.Start();
        }

        public  void BroadCast(string msg, TcpClient excludeClient, string clineNo)
        {
            foreach (TcpClient client in tcpClientsList)
            {
                    StreamWriter sWriter = new StreamWriter(client.GetStream());
                    sWriter.WriteLine(" >> " + "Client No:" + clineNo + msg);
                    sWriter.Flush();
            }
        }

        private void doChat()
        {
         ;
            byte[] bytesFrom = new byte[10025];//empty array of by
                                               //tes
            string dtfromC = null;
           
            
            

            while (true)
            {
                try
                {
                  
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                   
                    dtfromC = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dtfromC = dtfromC.Substring(0, dtfromC.IndexOf("$"));
                    BroadCast(dtfromC, clientSocket, Client_nb);
                   
                    Console.WriteLine(" >> " + "From client-" + Client_nb + dtfromC);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" >> " + ex.ToString());
                }
            }
        }
    }
}
