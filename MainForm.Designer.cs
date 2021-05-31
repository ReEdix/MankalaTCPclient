
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
            this.hostButton.Enabled = false;
            this.hostButton.Location = new System.Drawing.Point(16, 16);
            this.hostButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hostButton.Name = "hostButton";
            this.hostButton.Size = new System.Drawing.Size(100, 28);
            this.hostButton.TabIndex = 0;
            this.hostButton.Text = "Hostuj";
            this.hostButton.UseVisualStyleBackColor = true;
            this.hostButton.Click += new System.EventHandler(this.hostButton_Click);
            // 
            // joinButton
            // 
            this.joinButton.Enabled = false;
            this.joinButton.Location = new System.Drawing.Point(16, 52);
            this.joinButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(100, 28);
            this.joinButton.TabIndex = 2;
            this.joinButton.Text = "Dołącz";
            this.joinButton.UseVisualStyleBackColor = true;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // listBoxMatches
            // 
            this.listBoxMatches.FormattingEnabled = true;
            this.listBoxMatches.ItemHeight = 16;
            this.listBoxMatches.Location = new System.Drawing.Point(139, 16);
            this.listBoxMatches.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxMatches.Name = "listBoxMatches";
            this.listBoxMatches.Size = new System.Drawing.Size(288, 308);
            this.listBoxMatches.TabIndex = 3;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(16, 272);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(100, 28);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Zaloguj";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Enabled = false;
            this.buttonRefresh.Location = new System.Drawing.Point(17, 89);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(100, 28);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Odśwież";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(16, 192);
            this.textBoxLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(100, 22);
            this.textBoxLogin.TabIndex = 6;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(16, 240);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(99, 22);
            this.textBoxPassword.TabIndex = 7;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(16, 167);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(38, 20);
            this.labelLogin.TabIndex = 8;
            this.labelLogin.Text = "Login";
            this.labelLogin.UseCompatibleTextRendering = true;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(16, 220);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(44, 17);
            this.labelPassword.TabIndex = 9;
            this.labelPassword.Text = "Hasło";
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(17, 309);
            this.buttonRegister.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(100, 28);
            this.buttonRegister.TabIndex = 10;
            this.buttonRegister.Text = "Zarejestruj";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(444, 345);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Form1";
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

