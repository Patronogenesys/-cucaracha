using System.Drawing;
using Сucaracha.Resources;

namespace Сucaracha
{
    public partial class MainForm : Form
    {

        private const float SCALE_FACTOR = 5;
        private const int CUCARACHAS_COUNT = 5;
        private const int SPACING = 10;                 // px
        
        private FinishLine finishLine = new FinishLine(new Point(1000, 0));

        private Graphics graphics;
        private List<IDrawable> drawables = new List<IDrawable>(CUCARACHAS_COUNT + 1);
        public MainForm()
        {

            InitializeComponent();

            graphics = CreateGraphics();
            
            
            int height = (int)(Images.Сucaracha.Size.Height / SCALE_FACTOR);


            for (int i = 0; i < CUCARACHAS_COUNT; i++)
            {
                drawables.Add(CucarachaGenerator.Generate(timerUpdate, graphics, new Point(10, i * (height + SPACING))));
            }
            drawables.Add(finishLine);
            timerUpdate.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            foreach (var drawable in drawables)
            {
                drawable.Draw(graphics);
                if (drawable is Cucaracha && finishLine.IsCollidingWith(drawable as Cucaracha))
                    GameOver(drawable as Cucaracha);

            }

            
        }

        private void GameOver(Cucaracha cucaracha)
        {
            timerUpdate.Stop();
        }
    }
}