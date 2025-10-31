using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TConstruction.Controllers;
using TConstruction.Models;

namespace TConstruction
{
    public partial class Form1 : Form
    {
        private readonly ControllSorted controller;

        public Form1()
        {
            InitializeComponent();
            controller = new ControllSorted();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MoveLeft(object sender, EventArgs e)
        {
            pictureBox1.Left -= 2;
            if (pictureBox1.Left <= panel6.Left)
                timer1.Stop();
        }

        private void MoveRight(object sender, EventArgs e)
        {
            pictureBox1.Left += 2;
            if (pictureBox1.Left >= panel1.Right)
                timer1.Stop();
        }


        private void timer1_Tick(object sender, EventArgs e)//timer
        {
            timer1.Stop();

            if (controller.IsLeftOpen())
            {
                timer1.Tick -= timer1_Tick;
                timer1.Tick += MoveLeft;
                timer1.Start();
            }
            else if (controller.IsRightOpen())
            {
                timer1.Tick -= timer1_Tick;
                timer1.Tick += MoveRight;
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Обе ветки закрыты, поезд ждёт!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)//train
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)//hotizontal
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)//left
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)//right
        {

        }

        private async void button1_Click(object sender, EventArgs e)// спавн поезда 
        {
            var train = new SpeedTrain {id = 52, name = "train1", speed = 120 };

            await controller.HandleTrainAsync(train);

            pictureBox1.Location = new Point(panel6.Left, panel2.Bottom - pictureBox1.Height);
            timer1.Start();
        }
    }
}
