
using System;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;using System.ComponentModel;
using System.Linq;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        private System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        private NetworkStream serverStream;


        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // msg("Client Started");
            clientSocket.Connect("127.0.0.1", 8488);
            label1.Text = "Client Socket Program - Server Connected ...";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            serverStream = clientSocket.GetStream();
            string mesg = textBox1.Text;
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(mesg + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();


        }

        private void label1_Click(object sender, EventArgs e)
        {
        }



        private void textBox1_TextChanged(object sender, DoWorkEventArgs e)
        {
           
            textBox1.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            serverStream = clientSocket.GetStream();
            
                byte[] inStream = new byte[10025];
                serverStream.Read(inStream, 0, inStream.Length);

                string returndata = System.Text.Encoding.ASCII.GetString(inStream); // msg("Data from Server : " + returndata);

            

            label2.Text = ("Data :  " + returndata);
            textBox1.Clear();
        }

    }
}
