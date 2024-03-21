using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading;
using System.Text;
namespace TCIPCommunication
{
    public partial class Form1 : Form
    {
        TcpClient clientSocket = new TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readdata = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clientSocket.Connect(textBox1.Text, Int32.Parse(textBox2.Text));
            Thread ctThread = new Thread(getMessage);
            ctThread.Start();
            progressBar1.Value = 100;
        }
        private void getMessage()
        {
            string returndata;
            while (true)
            {
                serverStream = clientSocket.GetStream();
                var buffsize = clientSocket.ReceiveBufferSize;
                byte[] instream = new byte[buffsize];
                serverStream.Read(instream, 0, buffsize);
                returndata = System.Text.Encoding.ASCII.GetString(instream);
                readdata = returndata;
                msg();
            }
        }
        private void msg()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(msg));
            }
            else
            {
                //textBox4.Text = readdata;
                textBox4.AppendText(readdata + Environment.NewLine);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] outstream = Encoding.ASCII.GetBytes(textBox3.Text);
            serverStream.Write(outstream, 0, outstream.Length);
            serverStream.Flush();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clientSocket.Close();
            progressBar1.Value = 0;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}