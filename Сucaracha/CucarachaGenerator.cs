using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сucaracha
{
    public static class CucarachaGenerator
    {
        private static Random random = new Random();

        public static Cucaracha Generate(System.Windows.Forms.Timer timerUpdate, Graphics graphics, Point position, Size size)
        {
            float maxVel = (float)(random.NextDouble() * (0.35 - 0.15) + 0.15);             // 0.35 - max, 0.15 - min
            float minVel = (float)(random.NextDouble() * (0.14 - 0.05) + 0.05);             // 0.14 - max, 0.05 - min
            float velFrequency = (float)(random.NextDouble() * (0.009 - 0.003) + 0.003);    // 0.009 - max, 0.003 - min
            float velPhase = (float)(random.NextDouble() * 6);
            return new Cucaracha(timerUpdate, graphics, maxVel, minVel, velFrequency, velPhase, position, size/*, label1*/);
        }
    }
}
