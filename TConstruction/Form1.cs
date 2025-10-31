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
     "Left", // или "Right"
     DateTime.Now,
     currentTrain.wagonCount
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
    "Right", // или "Right"
    DateTime.Now,
    currentTrain.wagonCount
));

                }
            }
        }




        private void StartTrainMovement(PictureBox trainBox)
        {
            var train = (SpeedTrain)trainBox.Tag;
            var timer = new Timer { Interval = 50 };

            timer.Tick += (s, e) =>
            {
                trainBox.Top -= 2;

                if (trainBox.Top <= panel2.Top)
                {
                    timer.Stop();

                    // Решаем направление
                    if (controller.IsLeftOpen())
                    {
                        StartDirectionalMove(trainBox, train, "Left");
                    }
                    else if (controller.IsRightOpen())
                    {
                        StartDirectionalMove(trainBox, train, "Right");
                    }
                    else
                    {
                        MessageBox.Show("Обе ветки закрыты, поезд ждёт!");
                    }
                }
            };

            timer.Start();
        }

        private void StartDirectionalMove(PictureBox trainBox, SpeedTrain train, string direction)
        {
            var timer = new Timer { Interval = 50 };

            timer.Tick += (s, e) =>
            {
                if (direction == "Left")
                    trainBox.Left -= 2;
                else
                    trainBox.Left += 2;

                bool reached =
                    direction == "Left" && trainBox.Left <= panel6.Left ||
                    direction == "Right" && trainBox.Left >= panel1.Right;

                if (reached)
                {
                    timer.Stop();
                    Logger.Log(new JsonModelLog(train.id, train.name, direction, DateTime.Now, train.wagonCount));
                }
            };

            timer.Start();
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
            int id = rnd.Next(1000, 9999);
            string[] names = { "Orion", "Falcon", "Comet", "Vega", "Nova", "Titan", "Echo", "Zephyr" };
            string name = names[rnd.Next(names.Length)];

            return new SpeedTrain
            {
                id = id,
                name = name,
                speed = 120,
               wagonCount = rnd.Next(1,4) // пока фиксировано, можно сделать rnd.Next(1, 4)
            };
        }



        private async void button1_Click(object sender, EventArgs e)
        {
            var train = GenerateRandomTrain();
            await controller.HandleTrainAsync(train);

            var trainBox = CreateTrainVisual(train);
            StartTrainMovement(trainBox);

            Logger.Log(new JsonModelLog(train.id, train.name, "Spawned", DateTime.Now, train.wagonCount));

            await Task.Delay(train.wagonCount * 1000);
        }

        private PictureBox CreateTrainVisual(SpeedTrain train)
        {
            var pb = new PictureBox
            {
                Width = 20,
                Height = 20,
                BackColor = Color.Red,
                Location = new Point(
                    panel2.Left - 10,
                    panel2.Bottom - 20
                ),
                Tag = train // сохраняем поезд внутри визуального элемента
            };

            this.Controls.Add(pb);
            return pb;
        }



    }
}
