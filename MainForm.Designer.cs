
namespace TCPclient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hostButton = new System.Windows.Forms.Button();
            this.joinButton = new System.Windows.Forms.Button();
            this.listBoxMatches = new System.Windows.Forms.ListBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hostButton
            // 
            this.hostButton.BackColor = System.Drawing.SystemColors.Window;
            this.hostButton.Enabled = false;
            this.hostButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hostButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hostButton.Image = global::TCPclient.Properties.Resources.game_background;
            this.hostButton.Location = new System.Drawing.Point(12, 13);
            this.hostButton.Name = "hostButton";
            this.hostButton.Size = new System.Drawing.Size(75, 23);
            this.hostButton.TabIndex = 0;
            this.hostButton.Text = "Hostuj";
            this.hostButton.UseVisualStyleBackColor = false;
            this.hostButton.Click += new System.EventHandler(this.hostButton_Click);
            // 
            // joinButton
            // 
            this.joinButton.Enabled = false;
            this.joinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.joinButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.joinButton.Image = global::TCPclient.Properties.Resources.game_background;
            this.joinButton.Location = new System.Drawing.Point(12, 42);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(75, 23);
            this.joinButton.TabIndex = 2;
            this.joinButton.Text = "Dołącz";
            this.joinButton.UseVisualStyleBackColor = true;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // listBoxMatches
            // 
            this.listBoxMatches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.listBoxMatches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxMatches.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.listBoxMatches.FormattingEnabled = true;
            this.listBoxMatches.Location = new System.Drawing.Point(104, 13);
            this.listBoxMatches.Name = "listBoxMatches";
            this.listBoxMatches.Size = new System.Drawing.Size(217, 249);
            this.listBoxMatches.TabIndex = 3;
            this.listBoxMatches.SelectedIndexChanged += new System.EventHandler(this.listBoxMatches_SelectedIndexChanged);
            // 
            // connectButton
            // 
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Image = global::TCPclient.Properties.Resources.game_background;
            this.connectButton.Location = new System.Drawing.Point(12, 221);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Zaloguj";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Enabled = false;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Image = global::TCPclient.Properties.Resources.game_background;
            this.buttonRefresh.Location = new System.Drawing.Point(13, 72);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Odśwież";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(12, 156);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(76, 20);
            this.textBoxLogin.TabIndex = 6;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(12, 195);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(75, 20);
            this.textBoxPassword.TabIndex = 7;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.BackColor = System.Drawing.Color.Transparent;
            this.labelLogin.Location = new System.Drawing.Point(12, 136);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(32, 17);
            this.labelLogin.TabIndex = 8;
            this.labelLogin.Text = "Login";
            this.labelLogin.UseCompatibleTextRendering = true;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Location = new System.Drawing.Point(12, 179);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(36, 13);
            this.labelPassword.TabIndex = 9;
            this.labelPassword.Text = "Hasło";
            // 
            // buttonRegister
            // 
            this.buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegister.Image = global::TCPclient.Properties.Resources.game_background;
            this.buttonRegister.Location = new System.Drawing.Point(13, 251);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(75, 23);
            this.buttonRegister.TabIndex = 10;
            this.buttonRegister.Text = "Zarejestruj";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::TCPclient.Properties.Resources.game_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(333, 280);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.listBoxMatches);
            this.Controls.Add(this.joinButton);
            this.Controls.Add(this.hostButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button hostButton;
        private System.Windows.Forms.Button joinButton;
        private System.Windows.Forms.ListBox listBoxMatches;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button buttonRegister;
    }
}

