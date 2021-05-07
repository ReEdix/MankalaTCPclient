using SimpleTcp;
using System;
using System.Text;
using System.Windows.Forms;

namespace TCPclient
{
    public partial class MainForm : Form
    {
        public SimpleTcpClient client;
        GameForm gameForm;
        public MainForm()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient("127.0.0.1:8001");
            client.Events.Connected += Events_Connected;
            client.Events.DataReceived += Events_DataReceived;
            client.Connect();
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate {
                serverText.Text = Encoding.UTF8.GetString(e.Data);
                });

            switch(Encoding.UTF8.GetString(e.Data).Split(':')[0])
            {
                case Messages.Server.Start:                   
                    this.Invoke((MethodInvoker)delegate {
                        this.Hide();
                        gameForm = new GameForm(Encoding.UTF8.GetString(e.Data).Split(':')[1], this);
                        gameForm.Show();
                    });
                    break;
                case Messages.Client.Move:
                    this.Invoke((MethodInvoker)delegate {
                        gameForm.statusLabel.Text = "TWOJA TURA";
                        gameForm.enemyMoveFromServer(Int32.Parse(Encoding.UTF8.GetString(e.Data).Split(':')[1]));                                 
                    });
                    break;
                case Messages.Server.Cancel:
                    break;
            }
        }

        private void Events_Connected(object sender, ClientConnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate {
                serverText.Text = "Połączono z serverem";
            });
        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            client.Send(Messages.Client.Join);
        }

        private void hostButton_Click(object sender, EventArgs e)
        {
            client.Send(Messages.Client.Host);
        }
    }
}
