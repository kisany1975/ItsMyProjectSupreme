using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NeonCube_Undermove
{
    public partial class Form1 : Form
    {
        // Сила притяжения. Чем она больше 
        // тем быстрее падает игрок
        const int gravity = 1;

        // Здесь хранится изображение
        Bitmap bmp;
        // Ручка. Определяет толщину и стиль линий
        Pen pen;
        // Генерирует положение труб
        Random rnd = new Random();
        // Определяет шрифт, которым написана 
        // надпись в правом верхнем углу
        Font f = new Font("Matura MT Script Capitals",
            18F,
            FontStyle.Bold,
            GraphicsUnit.Point,
            ((byte)(0)));

        // Описание игрока
        Rectangle player;
        int playerVelocity = 0;
        int score = -1;

        // Описание нижней трубы
        Rectangle tube1;
        int tubeVelocity = -3;

        // Описание верхней трубы
        Rectangle tube2;
        // Расстояние между трубами
        int space = 200;

        Rectangle tube3;
        Rectangle tube4;


        Rectangle tube5;
        Rectangle tube6;

        public Form1()
        {
            InitializeComponent();
            // Создаем картинку, в которой генерируются кадры игры
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            // Определяем цвет контуров
            pen = new Pen(Brushes.Aqua);
            // Размещаем игрока и задаем ему размеры
            player = new Rectangle(100,200,30,30);
            // Размещаем нижнюю трубу и задаем её размеры
            tube1 = new Rectangle(500,300,100,500);
            // Размещаем верхнюю трубу относительно 
            // нижней трубы и задаем ей размеры
            tube2 = new Rectangle(tube1.X, tube1.Y - tube1.Height - space,100,500);

            tube3 = new Rectangle(750, 350, 100, 500);
            tube4 = new Rectangle(tube3.X, tube3.Y - tube3.Height - space, 100, 500);

            tube5 = new Rectangle(1000, 250, 100, 500);
            tube6 = new Rectangle(tube5.X, tube5.Y - tube5.Height - space, 100, 500);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            drawTimer_Tick(sender, e);
        }

        // Таймер отрисовки и игровой логики
        private void timer1_Tick(object sender, EventArgs e)
        {
           

            // Перемещаем игрока и трубы в
            // памяти компьютера
            PlayerLogic();
            

          
        }

        private void PlayerLogic()
        {
            // Увеличиваем количество очков
            score++;

            // Увеличиваем скорость падения игрока. 
            // Чем больше gravity тем быстрее падает игрок.
            playerVelocity += gravity;

            // Увеличиваем положение игрока на величину скорости.
            player.Y += playerVelocity;

            // Если игрок касается своей нижней частью
            // нижней части игрового поля (pictureBox1),
            // то пермещаем его вверх и сбрасываем скорость.
            // Инче если игрок своей верхней частью выходит
            // за верхние пределы, то мы сбрасываем его скорость 
            // и перемещаем его к верхней границе
            if (player.Y + player.Height >= pictureBox1.Height)
            {
                score = 0;
                player.Y = 0;
                playerVelocity = 0;
            }
            else if (player.Y < 0)
            {
                player.Y = 0;
                playerVelocity = 0;
            }
        }

        private void TubeLogic()
        {
            // Двигаем трубы
            // Перемещаем нижнюю трубу по оси X
            // Положение X верхней трубы приравниваем 
            // к положению X нижней трубы 
            tube1.X += tubeVelocity;
            tube2.X = tube1.X;

            // Пермещаем трубу в правый край 
            // если она ушла за левый край формы
            if(tube1.Right <= 0)
            {
                tube1.X = 600;
                tube1.Y = rnd.Next(180, 470);
                tube2.Y = tube1.Y - space - tube2.Height;
            }

            // Проверяем столкновение игрока и 
            // нижней трубы
            if(player.Right >= tube1.Left &&
               player.Bottom >= tube1.Top &&
               player.Left <= tube1.Right)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }

            // Проверяем столкновение игрока 
            // и верхней трубы
            if (player.Right >= tube2.Left &&
                player.Top <= tube2.Bottom &&
                player.Left <= tube2.Right)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }

            // Двигаем трубы
            // Перемещаем нижнюю трубу по оси X
            // Положение X верхней трубы приравниваем 
            // к положению X нижней трубы 
            tube3.X += tubeVelocity;
            tube4.X = tube3.X;

            // Пермещаем трубу в правый край 
            // если она ушла за левый край формы
            if (tube3.Right <= 0)
            {
                tube3.X = 600;
                tube3.Y = rnd.Next(180, 470);
                tube4.Y = tube3.Y - space - tube4.Height;
            }

            // Проверяем столкновение игрока и 
            // нижней трубы
            if (player.Right >= tube3.Left &&
               player.Bottom >= tube3.Top &&
               player.Left <= tube3.Right)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }

            // Проверяем столкновение игрока 
            // и верхней трубы
            if (player.Right >= tube4.Left &&
                player.Top <= tube4.Bottom &&
                player.Left <= tube4.Right)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }

            // Двигаем трубы
            // Перемещаем нижнюю трубу по оси X
            // Положение X верхней трубы приравниваем 
            // к положению X нижней трубы 
            tube5.X += tubeVelocity;
            tube6.X = tube5.X;

            // Пермещаем трубу в правый край 
            // если она ушла за левый край формы
            if (tube5.Right <= 0)
            {
                tube5.X = 600;
                tube5.Y = rnd.Next(180, 470);
                tube6.Y = tube5.Y - space - tube6.Height;
            }

            // Проверяем столкновение игрока и 
            // нижней трубы
            if (player.Right >= tube5.Left &&
               player.Bottom >= tube5.Top &&
               player.Left <= tube5.Right)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }

            // Проверяем столкновение игрока 
            // и верхней трубы
            if (player.Right >= tube6.Left &&
                player.Top <= tube6.Bottom &&
                player.Left <= tube6.Right)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                playerTimer.Start();
                playerVelocity -= 20;
            }
            else if(e.KeyCode == Keys.Escape)
            {
                playerTimer.Enabled = !playerTimer.Enabled;
                button1.Visible = true;
                button1.Enabled = true;
                button2.Visible = true;
                button2.Enabled = true;
                button3.Visible = true;
                button3.Enabled = true;
                button4.Visible = true;
                button4.Enabled = true;
            }
            else if(e.KeyCode == Keys.L)
            {
                playerTimer.Stop();
                new Leaderboard(score).Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button1.Enabled = false;
            button2.Visible = false;
            button2.Enabled = false;
            button3.Visible = false;
            button3.Enabled = false;
            button4.Visible = false;
            button4.Enabled = false;
            playerTimer.Start();
            tubeTimer.Start();
            drawTimer.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Leaderboard(score).Show();
        }

        private void tubeTimer_Tick(object sender, EventArgs e)
        {
            TubeLogic();
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(bmp);
            // Очищаем экран
            g.Clear(Color.Black);

            pen.Width = 5;

            // Отрисовываем изменения которые сделали 
            // в памяти компьютера
            g.FillRectangle(Brushes.Blue, tube1);
            g.FillRectangle(Brushes.Blue, tube2);
            g.FillRectangle(Brushes.Blue, tube3);
            g.FillRectangle(Brushes.Blue, tube4);
            g.FillRectangle(Brushes.Blue, tube5);
            g.FillRectangle(Brushes.Blue, tube6);
            g.FillRectangle(Brushes.White, player);
            g.DrawRectangle(pen, player);
            g.DrawRectangle(pen, tube1);
            g.DrawRectangle(pen, tube2);
            g.DrawRectangle(pen, tube3);
            g.DrawRectangle(pen, tube4);
            g.DrawRectangle(pen, tube5);
            g.DrawRectangle(pen, tube6);

            g.DrawString(score.ToString(), f, Brushes.White, 420, 20);

            pictureBox1.Image = bmp;
            g.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new SettingsForm().Show();
        }

        private void settingsUpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                string[] settings;
                settings = File.ReadAllLines("settigs");
                if (settings.Length > 0)
                {
                    playerTimer.Interval = Convert.ToInt32(settings[0]);
                    tubeTimer.Interval = Convert.ToInt32(settings[1]);
                }
            }
            catch 
            {

                
            }
        }
    }
}
