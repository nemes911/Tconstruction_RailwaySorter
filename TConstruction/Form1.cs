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
using TConstruction.Utils;

namespace TConstruction
{
    public partial class Form1 : Form
    {
        private readonly ControllSorted controller;

        private static readonly Random rnd = new Random();

        private SpeedTrain currentTrain;

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
            {
                timer1.Stop();

                if (currentTrain != null)
                {
                    Logger.Log(new JsonModelLog(
                    currentTrain.id,
                    currentTrain.name,
                    "Left",
                    DateTime.Now

                ));
                }
            }
        }

        private void MoveRight(object sender, EventArgs e)
        {
            pictureBox1.Left += 2;
            if (pictureBox1.Left >= panel1.Right)
            {
                timer1.Stop();
                if (currentTrain != null)
                {
                    Logger.Log(new JsonModelLog(
                    currentTrain.id,
                    currentTrain.name,
                    "Right",
                    DateTime.Now

                ));
                }
            }
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
        private SpeedTrain GenerateRandomTrain()
        {
            int id = rnd.Next(1000, 9999); // случайный ID от 1000 до 9999

            string[] names = { "Orion", "Falcon", "Comet", "Vega", "Nova", "Titan", "Echo", "Zephyr" };
            string name = names[rnd.Next(names.Length)];

            return new SpeedTrain
            {
                id = id,
                name = name,
                speed = 120
            };
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            currentTrain = GenerateRandomTrain();

            await controller.HandleTrainAsync(currentTrain);

            pictureBox1.Location = new Point(
                panel2.Left - pictureBox1.Width / 2,
                panel2.Bottom - pictureBox1.Height
            );

            Logger.Log(new JsonModelLog(currentTrain.id, currentTrain.name, "Spawned", DateTime.Now));

            // Сброс подписок
            timer1.Stop();
            timer1.Tick -= MoveLeft;
            timer1.Tick -= MoveRight;
            timer1.Tick -= timer1_Tick;
            timer1.Tick += timer1_Tick;

            timer1.Start();
        }

    }
}
