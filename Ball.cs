using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_ConsolePong
{
    internal class Ball
    {
        int x, y;
        int xVelocity, yVelocity;

        public Ball(int x, int y, int xVelocity, int yVelocity)
        {
            this.x = x;
            this.y = y;
            this.xVelocity = xVelocity;
            this.yVelocity = yVelocity;
        }

        public void Move()
        {
            x += xVelocity;
            y += yVelocity;
        }

        public void Draw()
        {
            if (x >= 0 && x < Console.WindowWidth && y >= 0 && y < Console.WindowHeight)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("O");
            }
        }

        public void CheckCollisions(Paddle p1, Paddle p2, int height, int width)
        {
            //Om bollen nuddar "taket" byt riktning så den studsar
            if (y <= 0 || y >= height - 1) yVelocity = -yVelocity;

            //Om bollen nuddar spelare 1, byt riktning
            if (x == p1.x + 1 && y >= p1.y && y <= p1.y + p1.size) xVelocity = -xVelocity;

            //Om bollen nuddar spelare 2, byt riktning
            if (x == p2.x - 1 && y >= p2.y && y <= p2.y + p2.size) xVelocity = -xVelocity;

            //Om bollen missar spelare två, resetta
            if(x <= 0)
            {
                x = width / 2;
                y = height / 2;
                xVelocity = -xVelocity;
            }

            if(x >= width - 1)
            {
                x = width / 2;
                y = height / 2;
                xVelocity = -xVelocity;
            }
        }
    }
}
