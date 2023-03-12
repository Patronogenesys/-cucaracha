using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сucaracha.Resources;

namespace Сucaracha
{
    internal class FinishLine : IDrawable
    {
        private const float SCALE_FACTOR = 5;

        private Point position;
        private Size size;

        public FinishLine(Point position)
        {
            int height = (int)(Images.FinishLine.Size.Height / SCALE_FACTOR);
            int width = (int)(Images.FinishLine.Size.Width / SCALE_FACTOR);
            this.size = new Size(width, height);
            this.position = position;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(Images.FinishLine, position.X, position.Y, size.Width, size.Height);
        }

        public bool IsCollidingWith(Cucaracha cucaracha) =>
            cucaracha.Position.X + cucaracha.Size.Width >= this.position.X;
    }
}
