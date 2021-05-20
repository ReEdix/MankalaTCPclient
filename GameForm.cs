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
        List<PictureBox> pictureBoxList;
        List<Image> imageList;
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
                foreach (Label l in labelList)
                {
                    l.Enabled = false;
                }

                statusLabel.Text = "TURA PRZECIWNIKA";
            }
            else
            {
                for (int i = 7; i < 14; i++)
                {
                    labelList[i].Enabled = false;
                }
                statusLabel.Text = "TWOJA TURA";
            }

            pictureBoxList = new List<PictureBox>();
            pictureBoxList.Add(fieldImageBox0);
            pictureBoxList.Add(fieldImageBox1);
            pictureBoxList.Add(fieldImageBox2);
            pictureBoxList.Add(fieldImageBox3);
            pictureBoxList.Add(fieldImageBox4);
            pictureBoxList.Add(fieldImageBox5);
            pictureBoxList.Add(fieldImageBox6); 
            pictureBoxList.Add(fieldImageBox7);
            pictureBoxList.Add(fieldImageBox8);
            pictureBoxList.Add(fieldImageBox9);
            pictureBoxList.Add(fieldImageBox10);
            pictureBoxList.Add(fieldImageBox11);
            pictureBoxList.Add(fieldImageBox12);
            pictureBoxList.Add(fieldImageBox13);

            foreach (PictureBox p in pictureBoxList)
            {
                p.Location = pictureBox1.PointToClient(p.Parent.PointToScreen(p.Location));
                p.Parent = pictureBox1;
                p.BackColor = Color.Transparent;
            }

            imageList = new List<Image>();

            imageList.Add(TCPclient.Properties.Resources._00);
            imageList.Add(TCPclient.Properties.Resources._01);
            imageList.Add(TCPclient.Properties.Resources._02);
            imageList.Add(TCPclient.Properties.Resources._03);
            imageList.Add(TCPclient.Properties.Resources._04);
            imageList.Add(TCPclient.Properties.Resources._05);
            imageList.Add(TCPclient.Properties.Resources._06);
            imageList.Add(TCPclient.Properties.Resources._07);
            imageList.Add(TCPclient.Properties.Resources._08);


            setPictures();
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
                            if (Int32.Parse(labelList[13 - 1 - ((labelIndex + labelIndexValue) % 7)].Text) != 0)
                            {
                                labelList[(labelIndex + labelIndexValue) % 14].Text = "0";

                                labelList[6].Text = (Int32.Parse(labelList[6].Text) + 1 + Int32.Parse(labelList[13 - 1 - ((labelIndex + labelIndexValue) % 7)].Text)).ToString();
                                labelList[Math.Abs(13 - 1 - ((labelIndex + labelIndexValue) % 7))].Text = "0";

                                break;
                            }
                        }
                        else
                        {
                            if (Int32.Parse(labelList[6 - 1 - ((labelIndex + labelIndexValue) % 7)].Text) != 0)
                            {
                                labelList[(labelIndex + labelIndexValue) % 14].Text = "0";

                                labelList[13].Text = (Int32.Parse(labelList[13].Text) + 1 + Int32.Parse(labelList[6 - 1 - ((labelIndex + labelIndexValue) % 7)].Text)).ToString();
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

            if (playerColor.Equals("WHITE"))
            {
                for (int i = 0; i < 7; i++)
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
            setPictures();
        }


        private void yourMove(int labelIndex)
        {
            if (labelList[labelIndex].Text == "0")
            {
                return;
            }
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
                            if (Int32.Parse(labelList[13 - 1 - ((labelIndex + labelIndexValue) % 7)].Text) != 0)
                            {
                                labelList[(labelIndex + labelIndexValue) % 14].Text = "0";

                                labelList[6].Text = (Int32.Parse(labelList[6].Text) + 1 + Int32.Parse(labelList[13 - 1 - ((labelIndex + labelIndexValue) % 7)].Text)).ToString();
                                labelList[Math.Abs(13 - 1 - ((labelIndex + labelIndexValue) % 7))].Text = "0";

                                break;
                            }
                        }
                        else
                        {
                            if (Int32.Parse(labelList[6 - 1 - ((labelIndex + labelIndexValue) % 7)].Text) != 0)
                            {
                                labelList[(labelIndex + labelIndexValue) % 14].Text = "0";

                                labelList[13].Text = (Int32.Parse(labelList[13].Text) + 1 + Int32.Parse(labelList[6 - 1 - ((labelIndex + labelIndexValue) % 7)].Text)).ToString();
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
                    if (playerColor.Equals("WHITE"))
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
            setPictures();
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


        private void setAllBlack()
        {
            foreach (Label l in labelList)
            {
                l.ForeColor = Color.Black;
            }
        }
        private void setAllEnabled()
        {
            foreach (Label l in labelList)
            {
                l.Enabled = true;
            }
        }
        private void setDisabledBlack()
        {
            foreach (Label l in labelList)
            {
                if (l.Name.Substring(0, 5) == "black")
                {
                    l.Enabled = false;
                }
            }
        }
        private void setDisabledWhite()
        {
            foreach (Label l in labelList)
            {
                if (l.Name.Substring(0, 5) == "white")
                {
                    l.Enabled = false;
                }
            }
        }
        

        private void setColorWhite(int labelIndex, int labelTextNumber)
        {
            setAllEnabled();
            int maxValue = labelIndex + labelTextNumber;
            for (int i = labelIndex+1; i <= maxValue; i++)
            {
                if (i % 14 == 13)
                {
                    labelList[i].ForeColor = Color.Black;
                    maxValue++;
                }
                else
                {
                    labelList[i%14].ForeColor = System.Drawing.ColorTranslator.FromHtml("#00CF91");
                }
            }
        }
        private void setColorBlack(int labelIndex, int labelTextNumber)
        {
            setAllEnabled();
            int maxValue = labelIndex + labelTextNumber;
            for (int i = labelIndex + 1; i <= maxValue; i++)
            {
                if (i % 14 == 6)
                {
                    labelList[i].ForeColor = Color.Black;
                    maxValue++;
                }
                else
                {
                    labelList[i % 14].ForeColor = System.Drawing.ColorTranslator.FromHtml("#00CF91");
                }
            }
        }
        private void whiteLabel0_Enter(object sender, EventArgs e)
        {
            //text on label | number of label
            int textNumber = Int32.Parse(whiteLabel0.Text);  // change
            int labelNumber = 0;                             // change
            setColorWhite(labelNumber, textNumber);
        }
        private void whiteLabel1_Enter(object sender, EventArgs e)
        {
            int textNumber = Int32.Parse(whiteLabel1.Text);  
            int labelNumber = 1;                             
            setColorWhite(labelNumber, textNumber);
        }
        private void whiteLabel2_Enter(object sender, EventArgs e)
        {
            int textNumber = Int32.Parse(whiteLabel2.Text);
            int labelNumber = 2;
            setColorWhite(labelNumber, textNumber);
        }
        private void whiteLabel3_Enter(object sender, EventArgs e)
        {
            int textNumber = Int32.Parse(whiteLabel3.Text);
            int labelNumber = 3;
            setColorWhite(labelNumber, textNumber);
        }
        private void whiteLabel4_Enter(object sender, EventArgs e)
        {
            int textNumber = Int32.Parse(whiteLabel4.Text);
            int labelNumber = 4;
            setColorWhite(labelNumber, textNumber);
        }
        private void whiteLabel5_Enter(object sender, EventArgs e)
        {
            int labelNumber = 5;                            
            int textNumber = Int32.Parse(whiteLabel5.Text);  
            setColorWhite(labelNumber,textNumber);
        }
        private void whiteLabel0_Leave(object sender, EventArgs e)
        {
            setAllBlack();
        }
        private void whiteLabel1_Leave(object sender, EventArgs e)
        {
            setAllBlack();
            setDisabledBlack();
        }
        private void whiteLabel2_Leave(object sender, EventArgs e)
        {
            setAllBlack();
            setDisabledBlack();
        }
        private void whiteLabel3_Leave(object sender, EventArgs e)
        {
            setAllBlack();
            setDisabledBlack();
        }
        private void whiteLabel4_Leave(object sender, EventArgs e)
        {
            setAllBlack();
            setDisabledBlack();
        }
        private void whiteLabel5_Leave(object sender, EventArgs e)
        {
            setAllBlack();
            setDisabledBlack();
        }
        private void blackLabel0_Enter(object sender, EventArgs e)
        {
            int labelNumber = 7;
            int textNumber = Int32.Parse(blackLabel0.Text);
            setColorBlack(labelNumber, textNumber);
        }
        private void blackLabel1_Enter(object sender, EventArgs e)
        {
            int labelNumber = 8;
            int textNumber = Int32.Parse(blackLabel1.Text);
            setColorBlack(labelNumber, textNumber);
        }
        private void blackLabel2_Enter(object sender, EventArgs e)
        {
            int labelNumber = 9;
            int textNumber = Int32.Parse(blackLabel2.Text);
            setColorBlack(labelNumber, textNumber);
        }
        private void blackLabel3_Enter(object sender, EventArgs e)
        {
            int labelNumber = 10;
            int textNumber = Int32.Parse(blackLabel3.Text);
            setColorBlack(labelNumber, textNumber);
        }
        private void blackLabel4_Enter(object sender, EventArgs e)
        {
            int labelNumber = 11;
            int textNumber = Int32.Parse(blackLabel4.Text);
            setColorBlack(labelNumber, textNumber);
        }
        private void blackLabel5_Enter(object sender, EventArgs e)
        {
            int labelNumber = 12;
            int textNumber = Int32.Parse(blackLabel5.Text);
            setColorBlack(labelNumber, textNumber);
        }
        private void blackLabel0_Leave(object sender, EventArgs e)
        {
            setAllBlack();
            setDisabledWhite();
        }
        private void blackLabel1_Leave(object sender, EventArgs e)
        {
            setAllBlack();
            setDisabledWhite();
        }
        private void blackLabel2_Leave(object sender, EventArgs e)
        {
            setAllBlack();
            setDisabledWhite();
        }
        private void blackLabel3_Leave(object sender, EventArgs e)
        {
            setAllBlack();
            setDisabledWhite();
        }
        private void blackLabel4_Leave(object sender, EventArgs e)
        {
            setAllBlack();
            setDisabledWhite();
        }
        private void blackLabel5_Leave(object sender, EventArgs e)
        {
            setAllBlack();
            setDisabledWhite();
        }

       

        private void setPictures()
        {
            int index = 0;
            foreach (PictureBox p in pictureBoxList)
            {
                if (Int32.Parse(labelList[index].Text) < 8)
                {
                    p.Image = imageList[Int32.Parse(labelList[index].Text)];
                }
                else
                {
                    p.Image = imageList[8]; 
                }
                index++;
            }
        }
    }
}
