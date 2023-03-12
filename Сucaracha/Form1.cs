using Сucaracha.Resources;

namespace Сucaracha
{
    public partial class Form1 : Form
    {

        private const int CUCARACHAS_COUNT = 1;
        private const int SPACING = 10;                 // px
        private const float SCALE_FACTOR = 5f;

        private List<Cucaracha> cucarachas = new List<Cucaracha>(CUCARACHAS_COUNT);
        public Form1()
        {

            InitializeComponent();

            int height = (int)(Images.Сucaracha.Size.Height / SCALE_FACTOR);
            int width = (int)(Images.Сucaracha.Size.Width / SCALE_FACTOR);

            Graphics gr = CreateGraphics();

            for (int i = 0; i < CUCARACHAS_COUNT; i++)
            {
                cucarachas.Add(new Cucaracha(timerUpdate, gr, 0.3f, 0.1f, 0.007f, 1, new Point(10, i * (height + SPACING)), new Size(width, height), label1));
            }

            timerUpdate.Start();
        }
    }
}