using Snake.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Snakes : Form
    {
        private List<GameObject> MrSnake = new List<GameObject>();
        private C_Circle Food = new C_Circle(0, 0);
        private C_Settings _settings;

        public Snakes()
        {
            InitializeComponent();

            _settings = new C_Settings();

            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            this.Focus();

            game_timer.Interval = 1000 / _settings.Speed;
            game_timer.Tick += UpdateScreen;
            game_timer.Start();

            StartGame();
        }

        private void StartGame()
        {
            lblGameOver.Visible = false;

            _settings.Reset();

            MrSnake.Clear();
            C_Circle head = new C_Circle(15, 5);
            MrSnake.Add(head);

            lblScore.Text = _settings.Score.ToString();
            GenerateFood();
        }

        private void GenerateFood()
        {
            int maxXPos = pbCanvas.Size.Width / _settings.Width;
            int maxYPos = pbCanvas.Size.Height / _settings.Height;

            Random random = new Random();
            Food.X = random.Next(0, maxXPos);
            Food.Y = random.Next(0, maxYPos);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            C_Input.KeyDown(e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            C_Input.KeyUp(e.KeyCode);
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            if (_settings.GameOver)
            {
                if (C_Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                if (C_Input.KeyPressed(Keys.Right) && _settings.Direction != Direction.Left)
                {
                    _settings.Direction = Direction.Right;
                }
                if (C_Input.KeyPressed(Keys.Left) && _settings.Direction != Direction.Right)
                {
                    _settings.Direction = Direction.Left;
                }
                if (C_Input.KeyPressed(Keys.Down) && _settings.Direction != Direction.Up)
                {
                    _settings.Direction = Direction.Down;
                }
                if (C_Input.KeyPressed(Keys.Up) && _settings.Direction != Direction.Down)
                {
                    _settings.Direction = Direction.Up;
                }

                if (C_Input.KeyPressed(Keys.R))
                {
                    MrSnakeDie();
                }

                MovePlayer();
            }

            pbCanvas.Invalidate();
        }

        private void MovePlayer()
        {
            for (int i = MrSnake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (_settings.Direction)
                    {
                        case Direction.Left:
                            MrSnake[i].X--;
                            break;
                        case Direction.Right:
                            MrSnake[i].X++;
                            break;
                        case Direction.Down:
                            MrSnake[i].Y++;
                            break;
                        case Direction.Up:
                            MrSnake[i].Y--;
                            break;
                    }
                    for (int j = 1; j < MrSnake.Count; j++)
                    {
                        if (MrSnake[i].X == MrSnake[j].X && MrSnake[i].Y == MrSnake[j].Y)
                        {
                            MrSnakeDie();
                        }
                    }

                    if (MrSnake[0].X == Food.X && MrSnake[0].Y == Food.Y)
                    {
                        MrSnakeEat();
                    }
                }
                else
                {
                    MrSnake[i].X = MrSnake[i - 1].X;
                    MrSnake[i].Y = MrSnake[i - 1].Y;
                }

                int MaxXPos = pbCanvas.Size.Width / _settings.Width;
                int MaxYPos = pbCanvas.Size.Height / _settings.Height;

                if (MrSnake[0].X < 0)
                    MrSnake[0].X = MaxXPos - 1;
                if (MrSnake[0].X >= MaxXPos)
                    MrSnake[0].X = 0;
                if (MrSnake[0].Y < 0)
                    MrSnake[0].Y = MaxYPos - 1;
                if (MrSnake[0].Y >= MaxYPos)
                    MrSnake[0].Y = 0;
            }
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (!_settings.GameOver)
            {
                Brush MrSnakeColour;
                for (int i = 0; i < MrSnake.Count; i++)
                {
                    if (i == 0)
                    {
                        MrSnakeColour = Brushes.Green;
                    }
                    else
                    {
                        MrSnakeColour = Brushes.LightGreen;
                    }

                    g.FillEllipse(MrSnakeColour,
                        new Rectangle(MrSnake[i].X * _settings.Width, MrSnake[i].Y * _settings.Height,
                            _settings.Width, _settings.Height));
                }
                g.FillEllipse(Brushes.Pink,
                    new Rectangle(Food.X * _settings.Width, Food.Y * _settings.Height,
                        _settings.Width, _settings.Height));
            }

            else
            {
                string gameOver = $"Конец игры\nВаш счёт: {_settings.Score}\nНажмите Enter";
                lblGameOver.Text = gameOver;
                lblGameOver.Visible = true;
            }
        }



        private void MrSnakeEat()
        {
            C_Circle food = new C_Circle(0, 0);
            food.X = MrSnake[MrSnake.Count - 1].X;
            food.Y = MrSnake[MrSnake.Count - 1].Y;

            MrSnake.Add(food);


            _settings.Score += _settings.Points;
            lblScore.Text=_settings.Score.ToString();

            GenerateFood();
        }

        private void MrSnakeDie()
        {
            _settings.GameOver = true;
        }
    }
}
