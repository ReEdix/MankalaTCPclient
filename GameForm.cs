using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPclient
{
    public partial class GameForm : Form
    {
        List<Label> labelList;
        string playerColor;
        MainForm mainForm;
        public GameForm(string playerColor, MainForm mainForm)
        {
            InitializeComponent();
            this.playerColor = playerColor;
            labelList = new List<Label>();
            this.mainForm = mainForm;

            labelList.Add(whiteLabel0);
            labelList.Add(whiteLabel1);
            labelList.Add(whiteLabel2);
            labelList.Add(whiteLabel3);
            labelList.Add(whiteLabel4);
            labelList.Add(whiteLabel5);
            labelList.Add(whiteLabel6);

            labelList.Add(blackLabel0);
            labelList.Add(blackLabel1);
            labelList.Add(blackLabel2);
            labelList.Add(blackLabel3);
            labelList.Add(blackLabel4);
            labelList.Add(blackLabel5);
            labelList.Add(blackLabel6);

            
            foreach (Label l in labelList)
            {
                l.Location = pictureBox1.PointToClient(l.Parent.PointToScreen(l.Location));
                l.Parent = pictureBox1;
                l.BackColor = Color.Transparent;
            }

            if (playerColor.Equals("BLACK"))
            {
                foreach(Label l in labelList)
                {                 
                    l.Enabled = false;
                }

                statusLabel.Text = "TURA PRZECIWNIKA";
            }
            else
            {
                for(int i=7; i<14; i++)
                {
                    labelList[i].Enabled = false;
                }
                statusLabel.Text = "TWOJA TURA";
            }     
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            mainForm.client.Send(Messages.Client.Exit);
        }

        public void enemyMoveFromServer(int labelIndex)
        {
            int iMaxValue = Int32.Parse(labelList[labelIndex].Text);
            int labelIndexValue = Int32.Parse(labelList[labelIndex].Text);
            for (int i = 1; i <= iMaxValue; i++)
            {
                //###CAPTURE###
                if (Int32.Parse(labelList[(labelIndex + labelIndexValue) % 14].Text) == 0
                    && ((labelIndex + labelIndexValue) % 14) != 6
                    && ((labelIndex + labelIndexValue) % 14) != 13
                    && i == iMaxValue)
                {
                    if (playerColor.Equals("BLACK") && ((labelIndex + labelIndexValue) % 14) > 6)
                    {

                    }
                    else if (playerColor.Equals("WHITE") && ((labelIndex + labelIndexValue) % 14) < 6)
                    {

                    }
                    else
                    {
                        if (playerColor.Equals("BLACK"))
                        {
                            if (Int32.Parse(labelList[13 - 1 - ((labelIndex + labelIndexValue)%7)].Text) != 0)
                            {
                                labelList[(labelIndex + labelIndexValue) % 14].Text = "0";

                                labelList[6].Text = (Int32.Parse(labelList[6].Text) + 1 + Int32.Parse(labelList[13 - 1 - ((labelIndex + labelIndexValue)%7)].Text)).ToString();
                                labelList[Math.Abs(13 - 1 - ((labelIndex + labelIndexValue) % 7))].Text = "0";

                                break;
                            }
                        }
                        else
                        {
                            if (Int32.Parse(labelList[6 - 1 - ((labelIndex + labelIndexValue)%7)].Text) != 0)
                            {
                                labelList[(labelIndex + labelIndexValue) % 14].Text = "0";

                                labelList[13].Text = (Int32.Parse(labelList[13].Text) + 1 + Int32.Parse(labelList[6 - 1 - ((labelIndex + labelIndexValue)%7)].Text)).ToString();
                                labelList[Math.Abs(6 - 1 - ((labelIndex + labelIndexValue) % 7))].Text = "0";

                                break;
                            }
                        }
                    }
                }
                //###CAPTURE###

                if (((labelIndex + i) % 14) != 6 && ((labelIndex + i) % 14) != 13)
                {
                    labelList[(labelIndex + i) % 14].Text = (Int32.Parse(labelList[(labelIndex + i) % 14].Text) + 1).ToString();
                }
                else if (((labelIndex + i) % 14) == 6)
                {
                    if (playerColor.Equals("BLACK"))
                    {
                        labelList[(labelIndex + i) % 14].Text = (Int32.Parse(labelList[(labelIndex + i) % 14].Text) + 1).ToString();
                    }
                    else
                    {
                        iMaxValue++;
                    }
                }
                else if (((labelIndex + i) % 14) == 13)
                {
                    if (playerColor.Equals("WHITE"))
                    {
                        labelList[(labelIndex + i) % 14].Text = (Int32.Parse(labelList[(labelIndex + i) % 14].Text) + 1).ToString();
                    }
                    else
                    {
                        iMaxValue++;
                    }
                }
            }

            //###EXTRA MOVE###
            if ((labelIndex + Int32.Parse(labelList[labelIndex].Text)) % 14 == 6 || (labelIndex + Int32.Parse(labelList[labelIndex].Text)) % 14 == 13)
            {
                statusLabel.Text = "TURA PRZECIWNIKA";
                labelList[labelIndex].Text = "0";
                return;
            }
            //###EXTRA MOVE###

            labelList[labelIndex].Text = "0";

            if(playerColor.Equals("WHITE"))
            {
                for(int i = 0; i<7; i++)
                {
                    labelList[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 7; i < 13; i++)
                {
                    labelList[i].Enabled = true;
                }
            }
        }


        private void yourMove(int labelIndex)
        {
            int iMaxValue = Int32.Parse(labelList[labelIndex].Text);
            int labelIndexValue = Int32.Parse(labelList[labelIndex].Text);
            for (int i = 1; i <= iMaxValue; i++)
            {
                //###CAPTURE###
                if (Int32.Parse(labelList[(labelIndex + labelIndexValue) % 14].Text) == 0
                    && ((labelIndex + labelIndexValue) % 14) != 6
                    && ((labelIndex + labelIndexValue) % 14) != 13
                    && i == iMaxValue)
                {
                    if (playerColor.Equals("WHITE") && ((labelIndex + labelIndexValue) % 14) > 6)
                    {

                    }
                    else if (playerColor.Equals("BLACK") && ((labelIndex + labelIndexValue) % 14) < 6)
                    {

                    }
                    else
                    {
                        if (playerColor.Equals("WHITE"))
                        {
                            if (Int32.Parse(labelList[13 - 1 - ((labelIndex + labelIndexValue)%7)].Text) != 0)
                            {
                                labelList[(labelIndex + labelIndexValue) % 14].Text = "0";

                                labelList[6].Text = (Int32.Parse(labelList[6].Text) + 1 + Int32.Parse(labelList[13 - 1 - ((labelIndex + labelIndexValue)%7)].Text)).ToString();
                                labelList[Math.Abs(13 - 1 - ((labelIndex + labelIndexValue) % 7))].Text = "0";

                                break;
                            }
                        }
                        else
                        {
                            if (Int32.Parse(labelList[6 - 1 - ((labelIndex + labelIndexValue)%7)].Text) != 0)
                            {
                                labelList[(labelIndex + labelIndexValue) % 14].Text = "0";

                                labelList[13].Text = (Int32.Parse(labelList[13].Text) + 1 + Int32.Parse(labelList[6 - 1 - ((labelIndex + labelIndexValue)%7)].Text)).ToString();
                                labelList[Math.Abs(6 - 1 - ((labelIndex + labelIndexValue) % 7))].Text = "0";

                                break;
                            }
                        }
                    }               
                }
                //###CAPTURE###

                if(((labelIndex + i) % 14) !=6 && ((labelIndex + i) % 14) != 13)
                {
                    labelList[(labelIndex + i) % 14].Text = (Int32.Parse(labelList[(labelIndex + i) % 14].Text) + 1).ToString();
                }
                else if(((labelIndex + i) % 14) == 6)
                {
                    if(playerColor.Equals("WHITE"))
                    {
                        labelList[(labelIndex + i) % 14].Text = (Int32.Parse(labelList[(labelIndex + i) % 14].Text) + 1).ToString();
                    }
                    else
                    {
                        iMaxValue++;
                    }
                }
                else if(((labelIndex + i) % 14) == 13)
                {
                    if (playerColor.Equals("BLACK"))
                    {
                        labelList[(labelIndex + i) % 14].Text = (Int32.Parse(labelList[(labelIndex + i) % 14].Text) + 1).ToString();
                    }
                    else
                    {
                        iMaxValue++;
                    }
                }
            }

            
            if ((labelIndex + labelIndexValue) % 14 == 6 || (labelIndex + labelIndexValue) % 14 == 13)//###EXTRA MOVE###
            {
                mainForm.client.Send(Messages.Client.Move + $":{labelIndex}");
            }
            else
            {
                for (int i = 0; i < 14; i++)
                {
                    labelList[i].Enabled = false;
                }
                statusLabel.Text = "TURA PRZECIWNIKA";
                mainForm.client.Send(Messages.Client.Move + $":{labelIndex}");
            }
            labelList[labelIndex].Text = "0";
        }


        private void whiteLabel0_Click(object sender, EventArgs e)
        {
            yourMove(0);
        }
        private void whiteLabel1_Click(object sender, EventArgs e)
        {
            yourMove(1);
        }

        private void whiteLabel2_Click(object sender, EventArgs e)
        {
            yourMove(2);
        }

        private void whiteLabel3_Click(object sender, EventArgs e)
        {
            yourMove(3);
        }

        private void whiteLabel4_Click(object sender, EventArgs e)
        {
            yourMove(4);
        }

        private void whiteLabel5_Click(object sender, EventArgs e)
        {
            yourMove(5);
        }

        private void blackLabel0_Click(object sender, EventArgs e)
        {
            yourMove(7);
        }

        private void blackLabel1_Click(object sender, EventArgs e)
        {
            yourMove(8);
        }

        private void blackLabel2_Click(object sender, EventArgs e)
        {
            yourMove(9);
        }

        private void blackLabel3_Click(object sender, EventArgs e)
        {
            yourMove(10);
        }

        private void blackLabel4_Click(object sender, EventArgs e)
        {
            yourMove(11);
        }

        private void blackLabel5_Click(object sender, EventArgs e)
        {
            yourMove(12);
        }
    }
}
