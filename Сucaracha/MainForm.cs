using System.Drawing;
using Сucaracha.Resources;

namespace Сucaracha
{
    public partial class MainForm : Form
    {

        private const int CUCARACHAS_COUNT = 5;
        private const int SPACING = 10;                 // px
        private const float SCALE_FACTOR = 5f;

        private Graphics graphics;
        private List<Cucaracha> cucarachas = new List<Cucaracha>(CUCARACHAS_COUNT);
        public MainForm()
        {

            InitializeComponent();

            graphics = CreateGraphics();

            int height = (int)(Images.Сucaracha.Size.Height / SCALE_FACTOR);
            int width = (int)(Images.Сucaracha.Size.Width / SCALE_FACTOR);


            for (int i = 0; i < CUCARACHAS_COUNT; i++)
            {
                cucarachas.Add(new Cucaracha(timerUpdate, graphics, 0.3f, 0.1f, 0.007f, 1, new Point(10, i * (height + SPACING)), new Size(width, height), label1));
            }

            timerUpdate.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            foreach (var cucaracha in cucarachas)
            {
                cucaracha.Draw(graphics);
            }
        }
    }
}