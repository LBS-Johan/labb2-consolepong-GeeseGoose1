using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_ConsolePong
{
    internal class Paddle
    {
        int x;
        int y;
        int size;

        public Paddle(int x, int y, int size)
        {
            this.x = x;
            this.y = y;
            this.size = size;
        }

        public void Move(int yAmount)
        {
            // y ökar med yAmount, checka om y är midnre ön noll setts den till noll, annars om y + size e större än fönstret sätt y till fönsterstorlek minus size
            y += yAmount;

            if (y < 0) y = 0;

            else if (y + size > Console.WindowHeight) y = Console.WindowHeight - size; 
        }

        public void Draw()
        {
            for(int i = 0; i<size; i++ )
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write("|");
            }
        }

    }
}
