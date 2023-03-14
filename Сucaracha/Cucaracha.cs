using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сucaracha.Resources;

namespace Сucaracha
{
    public class Cucaracha : IDrawable
    {

        // Плохие решения
        private bool isStarted;


        // Position
        private long timeMS;                            // millisec
        private float x;
        private float dx;                               // px/sec^2
        private float maxVel;                           // px/sec
        private float minVel;                           // px/sec
        private float velFrequency;                     // hz - реально хз
        private float velPhase;
        private const float SHIFT_FREQUENCY = 0.25f;    // hz
        private const float SHIFT_AMPLITUDE = 6;        // px

        //Label label;

        // Visuals for animation
        private const float SCALE_FACTOR = 5;
        private Point position;
        private Size size;
        private float xUpperShift = 0, xLowerShift = 0;
        private Point[] destPoints = new Point[3];                 // {Upper L, Upper R, Lower L}


        public Point Position { get { return position; } }
        public Size Size { get { return size; } }

        public Cucaracha(float maxVel, float minVel, float velFrequency, float velPhase, Point position)
        {
            this.maxVel = maxVel;
            this.minVel = minVel;
            this.velFrequency = velFrequency;
            this.velPhase = velPhase;

            int height = (int)(Images.Сucaracha.Size.Height / SCALE_FACTOR);
            int width = (int)(Images.Сucaracha.Size.Width / SCALE_FACTOR);
            this.size = new Size(width, height);
            this.position = position;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(Images.Сucaracha, destPoints);
        }

        public void StartMoving(System.Windows.Forms.Timer timer)
        {
            if (isStarted) throw new Exception("Cucaracha is already moving");
            isStarted = true;
            timer.Tick += (sender, _) => Update((sender as System.Windows.Forms.Timer).Interval);
        }

        public void StopMoving(System.Windows.Forms.Timer timer)
        {
            isStarted = false;
            timer.Tick -= (sender, _) => Update((sender as System.Windows.Forms.Timer).Interval);
        }

        private void Update(int timerInterval)
        {
            timeMS += timerInterval;

            dx = Velocity(timeMS, velFrequency, velPhase, minVel, maxVel);
            x += dx * timerInterval;
            position.X = (int)x;

            xLowerShift = Shift(timeMS, SHIFT_FREQUENCY, SHIFT_AMPLITUDE);
            xUpperShift = -xLowerShift;

            destPoints[0] = new Point(Position.X + (int)xUpperShift, Position.Y); ;
            destPoints[1] = new Point(Position.X + (int)(size.Width + xUpperShift), Position.Y);
            destPoints[2] = new Point(Position.X + (int)xLowerShift, Position.Y + size.Height);
        }

        private float Velocity(long timeMS, float frequency, float phase, float minVel, float maxVel)
        {
            if (minVel > maxVel) throw new ArgumentException("minVel must have greater value than maxVel");
            return (maxVel - minVel) * (MathF.Sin(timeMS * frequency / (MathF.PI) + phase) + 1) / 2 + minVel;
        }

        private float Shift(long timeMS, float frequency, float amplitude) => MathF.Sin(timeMS * frequency / (MathF.PI)) * amplitude;
    }
}
