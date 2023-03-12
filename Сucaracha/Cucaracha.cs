using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сucaracha.Resources;

namespace Сucaracha
{
    public class Cucaracha
    {
        // Winforms Components
        private System.Windows.Forms.Timer timer;

        // Position
        private long timeMS;                            // millisec
        private float x;
        private const int MS_IN_SEC = 1000;
        private float dx;                               // px/sec^2
        private float maxVel;                           // px/sec
        private float minVel;                           // px/sec
        private float velFrequency;                     // hz - реально хз
        private float velPhase;
        private const float SHIFT_FREQUENCY = 0.25f;    // hz
        private const float SHIFT_AMPLITUDE = 6;        // px

        Label label;

        // Visuals for animation
        private Point position;
        private Size size;
        private Graphics graphics;
        private float xUpperShift = 0, xLowerShift = 0;
        private Point[] destPoints = new Point[3];                 // {Upper L, Upper R, Lower L}

        public Cucaracha(System.Windows.Forms.Timer timer, Graphics graphics, float maxVel, float minVel, float velFrequency, float velPhase, Point position, Size size, Label label)
        {

            this.timer = timer;
            timer.Tick += (_, _) => Update();

            this.graphics = graphics;

            this.maxVel = maxVel;
            this.minVel = minVel;
            this.velFrequency = velFrequency;
            this.velPhase = velPhase;

            this.position = position;
            this.size = size;

            this.label = label;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(Images.Сucaracha, destPoints);
        }

        private void Update()
        {
            timeMS += timer.Interval;

            dx = Velocity(timeMS, velFrequency, velPhase, minVel, maxVel);
            x += dx * timer.Interval;
            position.X = (int)x;

            //
            label.Text += $"{dx}\n";
            //

            xLowerShift = Shift(timeMS, SHIFT_FREQUENCY, SHIFT_AMPLITUDE);
            xUpperShift = -xLowerShift;

            destPoints[0] = new Point(position.X + (int)xUpperShift, position.Y); ;
            destPoints[1] = new Point(position.X + (int)(size.Width + xUpperShift), position.Y);
            destPoints[2] = new Point(position.X + (int)xLowerShift, position.Y + size.Height);


        }

        private float Velocity(long timeMS, float frequency, float phase, float minVel, float maxVel)
        {
            if (minVel > maxVel) throw new ArgumentException("minVel must have greater value than maxVel");
            return (maxVel - minVel) * (MathF.Sin(timeMS * frequency / (MathF.PI /* * MS_IN_SEC*/) + phase) + 1) / 2 + minVel;
        }

        private float Shift(long timeMS, float frequency, float amplitude) => MathF.Sin(timeMS * frequency / (MathF.PI /* * MS_IN_SEC*/)) * amplitude;
    }
}
