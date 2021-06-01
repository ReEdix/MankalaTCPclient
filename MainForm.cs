using SimpleTcp;
using System;
using System.Text;
using System.Windows.Forms;
using System.Linq;

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
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {

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
                case Messages.Server.Disconnect:
                    MessageBox.Show("Błędny login lub hasło", "Login ERROR");
                    client.Disconnect();
                    loginFormsVisible(true);
                    this.Invoke((MethodInvoker)delegate {
                        this.Text = " ";
                    });                 
                    break;
                case Messages.Server.User:
                    this.Invoke((MethodInvoker)delegate {
                        this.Text += $" W->{ Encoding.UTF8.GetString(e.Data).Split(':')[1]} P->{Encoding.UTF8.GetString(e.Data).Split(':')[2]}";
                    });
                    break;
                case Messages.Server.Registered:
                    MessageBox.Show("Konto zostało stworzone", "Registered");
                    break;
                case Messages.Server.Matches:
                    this.Invoke((MethodInvoker)delegate {

                        String[] matches = Encoding.UTF8.GetString(e.Data).Split(':');
                        listBoxMatches.Items.Clear();

                        for(int i=1; i<matches.Length; i++)
                        {
                            listBoxMatches.Items.Add($"{matches[i]}");
                        }
                    });
                    break;
                case Messages.Server.Logged:
                    MessageBox.Show("Taki gracz jest już zalogowany", "Login ERROR");
                    client.Disconnect();
                    loginFormsVisible(true);
                    this.Invoke((MethodInvoker)delegate {
                        this.Text = " ";
                    });
                    break;
                case Messages.Server.Winner:
                    MessageBox.Show("Wygrał gracz - " + Encoding.UTF8.GetString(e.Data).Split(':')[3], "Koniec Gry");
                    
                    this.gameForm.Invoke((MethodInvoker)delegate
                    {
                        gameForm.Close();
                    });
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Show();
                        this.joinButton.Enabled = true;
                        this.buttonRefresh.Enabled = true;
                        this.client.Send(Messages.Server.Cancel);
                    });
                    client.Send(Messages.Client.SaveGame + ":" + Encoding.UTF8.GetString(e.Data).Split(':')[1] +
                        ":" + Encoding.UTF8.GetString(e.Data).Split(':')[2] +
                        ":" + Encoding.UTF8.GetString(e.Data).Split(':')[3]);
                    break;
                case Messages.Server.Lost:
                    MessageBox.Show("Wygrał gracz - " + Encoding.UTF8.GetString(e.Data).Split(':')[1], "Koniec Gry");
                    this.gameForm.Invoke((MethodInvoker)delegate
                    {
                        if(gameForm != null)
                        {
                            gameForm.Close();
                        }                      
                    });
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Show();
                        this.joinButton.Enabled = true;
                        this.buttonRefresh.Enabled = true;
                        this.client.Send(Messages.Server.Cancel);
                    });
                    break;
            }
        }

        private void Events_Connected(object sender, ClientConnectedEventArgs e)
        {
 
        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            client.Send($"{Messages.Client.Join}:{listBoxMatches.SelectedItem.ToString()}");
        }

        private void hostButton_Click(object sender, EventArgs e)
        {   
            if (buttonRefresh.Enabled)
            {
                client.Send(Messages.Client.Host);
                buttonRefresh.Enabled = false;
                joinButton.Enabled = false;
            }
            else
            {
                client.Send(Messages.Server.Cancel);
                buttonRefresh.Enabled = true;
                joinButton.Enabled = true;
            }

        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if(connectButton.Text.Equals("Wyloguj"))
            {
                client.Disconnect();
                loginFormsVisible(true);
                this.Text = " ";
                return;
            }

            if(textBoxLogin.Text.Contains(":") || textBoxPassword.Text.Contains(":"))
            {
                MessageBox.Show("Login i hasło nie mogą zawierać znaku dwukropka  -> : <-", "Input Error");
                this.Text = " ";
                return;
            }

            client.Connect();
            client.Send($"{Messages.Client.Login}:{textBoxLogin.Text}:{textBoxPassword.Text}");
            this.Text = textBoxLogin.Text;
            loginFormsVisible(false);

        }

        private void loginFormsVisible(bool visible)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (connectButton.Text.Equals("Wyloguj")) 
                {
                    connectButton.Text = "Zaloguj";
                }
                else
                {
                    connectButton.Text = "Wyloguj";
                }
            });
            this.Invoke((MethodInvoker)delegate
            {
                textBoxLogin.Visible = visible;
                textBoxPassword.Visible = visible;
                buttonRegister.Visible = visible;
                labelLogin.Visible = visible;
                labelPassword.Visible = visible;

                buttonRefresh.Enabled = !visible;
                hostButton.Enabled = !visible;
                joinButton.Enabled = !visible;
            });
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            client.Connect();
            client.Send($"{Messages.Client.Register}:{textBoxLogin.Text}:{textBoxPassword.Text}");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            client.Send(Messages.Server.Matches);
        }
    }
}
