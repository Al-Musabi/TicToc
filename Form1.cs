using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        byte Rounds = 0;
        enum enPlayer: byte
        {
            Player1,Player2
        }

        enPlayer PlyerTurn = enPlayer.Player1;
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen White_Pen = new Pen(Color.White);

            White_Pen.Width = 10;
            White_Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            White_Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(White_Pen, 456, 60, 456, 410);
            e.Graphics.DrawLine(White_Pen, 335, 180, 670, 180);
            e.Graphics.DrawLine(White_Pen, 570, 60, 570, 410);
            e.Graphics.DrawLine(White_Pen, 335, 306, 670, 306);
        }
        void DisabledAllPicBox()
        {
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;
            pictureBox5.Enabled = false;
            pictureBox6.Enabled = false;
            pictureBox7.Enabled = false;
            pictureBox8.Enabled = false;
            pictureBox9.Enabled = false;
        }

        void ResetPicBoxes(PictureBox PicBox)
        {
            PicBox.Image = Tic_Tac_Toe.Properties.Resources.question_mark_96;
            PicBox.Enabled = true;
            PicBox.Tag = "?";
            PicBox.BackColor = PictureBox.DefaultForeColor;
            
        }


        void ResetAll()
        {
            Rounds = 0;


            lalPlayer.Text = "Player 1";
            PlyerTurn = enPlayer.Player1;
            lalWinner.Text = "In Progress";

            ResetPicBoxes(pictureBox1);
            ResetPicBoxes(pictureBox2);
            ResetPicBoxes(pictureBox3);
            ResetPicBoxes(pictureBox4);
            ResetPicBoxes(pictureBox5);
            ResetPicBoxes(pictureBox6);
            ResetPicBoxes(pictureBox7);
            ResetPicBoxes(pictureBox8);
            ResetPicBoxes(pictureBox9);




        }

        void ChangeThePicture(PictureBox PB)
        {
            if (CheckIfthisUsed(PB))
            {
                MessageBox.Show("There is Wrong", "Warinng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            WhoIsThePlayer(PB);
        }
        void WhoIsThePlayer(PictureBox PB)
        {
            
            switch (PlyerTurn)
            {
                case enPlayer.Player1:

                    Rounds++;
                    PB.Image= Tic_Tac_Toe.Properties.Resources.X;
                    PB.Tag = "x";

                    if (Rounds > 2)
                    {
                        if(CheckIfThereWinner())
                        {
                            lalPlayer.Text = "Game Over";
                            lalWinner.Text = "Player 1";
                            MessageBox.Show("Player 1 is The Winner", "Congraouation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DisabledAllPicBox();
                            return;
                        }


                    }
                    PlyerTurn = enPlayer.Player2;
                    lalPlayer.Text = "Player 2";

                    if(Rounds == 5)
                    {
                        lalPlayer.Text = "Game Over";
                        lalWinner.Text = "Draw";
                        MessageBox.Show("No Winner ", "Drawing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisabledAllPicBox();
                        return;
                    }

                    break;

                case enPlayer.Player2:


                    PB.Image = Tic_Tac_Toe.Properties.Resources.O;
                    PB.Tag = "o";

                    if (Rounds > 2)
                    {
                        if (CheckIfThereWinner())
                        {
                            lalPlayer.Text = "Game Over";
                            lalWinner.Text = "Player 2";
                            MessageBox.Show("Player 2 is The Winner", "Congraouation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DisabledAllPicBox();
                            return;
                        }


                    }
                    PlyerTurn = enPlayer.Player1;
                    lalPlayer.Text = "Player 1";
                    break;
            }
        }

        bool CheckIfthisUsed(PictureBox PB)
        {
            if (PB.Tag.ToString() != "?")
                return true; 
            else
                return false;
        }

        bool CheckTheWinner(PictureBox PB1 , PictureBox PB2,PictureBox PB3)
        {
            if (PB1.Tag.ToString() != "?" && PB1.Tag == PB2.Tag && PB1.Tag == PB3.Tag)
            {
                PB1.BackColor = Color.GreenYellow;
                PB2.BackColor = Color.GreenYellow;
                PB3.BackColor = Color.GreenYellow;
                return true;

            }
            return false;
        }
        bool CheckIfThereWinner()
        {
            if (CheckTheWinner(pictureBox1, pictureBox6, pictureBox9))
            {
                return true;
            }
            if (CheckTheWinner(pictureBox2, pictureBox5, pictureBox8))
            {
                return true;
            }
            if (CheckTheWinner(pictureBox3, pictureBox4, pictureBox7))
            {
                return true;
            }
            if (CheckTheWinner(pictureBox1, pictureBox2, pictureBox3))
            {
                return true;
            }
            if (CheckTheWinner(pictureBox6, pictureBox5, pictureBox4))
            {
                return true;
            }
            if (CheckTheWinner(pictureBox9, pictureBox8, pictureBox7))
            {
                return true;
            }
            if (CheckTheWinner(pictureBox1, pictureBox5, pictureBox7))
            {
                return true ;
            }
            if (CheckTheWinner(pictureBox9, pictureBox5, pictureBox3))
            {
                return true;
            }

            return false;
        }

        
        private void PictureBox_Click(object sender, EventArgs e)
        {
            ChangeThePicture((PictureBox)sender);
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }
    }
}
