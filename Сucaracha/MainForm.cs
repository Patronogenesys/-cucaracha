using System.Drawing;
using Сucaracha.Resources;

namespace Сucaracha
{
    public partial class MainForm : Form
    {

        private const float SCALE_FACTOR = 5;
        private const int CUCARACHAS_COUNT = 5;
        private const int SPACING = 10;                 // px

        private (string? s, Font font, Brush brush, RectangleF layoutRectangle) k = ("Winner", new Font(FontFamily.GenericSansSerif, 12), new SolidBrush(Color.White), new Rectangle(0,0,0,0));
        private (Brush brush, Rectangle rect) z = (new SolidBrush(Color.DarkRed), new Rectangle(0,0,0, 0));

        private FinishLine finishLine = new FinishLine(new Point(1000, 0));

        private List<IDrawable> drawables = new List<IDrawable>(CUCARACHAS_COUNT + 1);
        public MainForm()
        {
            InitializeComponent();

            int height = (int)(Images.Сucaracha.Size.Height / SCALE_FACTOR);

            for (int i = 0; i < CUCARACHAS_COUNT; i++)
            {
                drawables.Add(CucarachaGenerator.Generate(new Point(10, i * (height + SPACING))));
            }
            drawables.Add(finishLine);
        }

        private void Update(object sender, EventArgs e)
        {
            Refresh();
        }

        private void GameOver(Cucaracha cucaracha)
        {
            timerUpdate.Stop();
            foreach (var drawable in drawables)
            {
                switch (drawable)
                {
                    case Cucaracha c:
                        c.StopMoving(timerUpdate);
                        break;
                }
            }
            z = (new SolidBrush(Color.DarkRed), new Rectangle(cucaracha.Position, new Size(100, 100)));
            k = ("Winner", new Font(FontFamily.GenericSansSerif, 12), new SolidBrush(Color.White), new Rectangle(cucaracha.Position.X + 15, cucaracha.Position.Y + 35, 100, 100));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timerUpdate.Start();
            foreach (var drawable in drawables)
            {
                switch (drawable)
                {
                    case Cucaracha cucaracha:
                        cucaracha.StartMoving(timerUpdate);
                        break;
                }
            }
            btnStart.Hide();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (var drawable in drawables)
            {
                drawable.Draw(e.Graphics);
                if (drawable is Cucaracha cucaracha && finishLine.IsCollidingWith(cucaracha))
                    GameOver(cucaracha);
            }
            e.Graphics.FillEllipse(z.brush, z.rect);
            e.Graphics.DrawString(k.s, k.font, k.brush, k.layoutRectangle);
        }
    }
}