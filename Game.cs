using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_ConsolePong
{
    internal class Game
    {
        int width;
        int height;

        Paddle player1;
        Paddle player2;
        Ball ball;

        public void StartGame()
        {
            // Setup konsol-fönstret
            width = Console.WindowWidth;
            height = Console.WindowHeight;
            Console.CursorVisible = false;

            player1 = new Paddle(3, height / 2, 7);
            player2 = new Paddle(width - 4, height /2, 7);
            ball = new Ball(width / 2, height / 2, 1, 1);
        }

        public bool Run()
        {
            //Töm hela skärmen i början av varje uppdatering.
            Console.Clear();

            ball.Move();
            ball.CheckCollisions(player1, player2, height, width);
            ball.Draw();

            if (Input.IsPressed(ConsoleKey.UpArrow))
            {
                //Flytta spelare 1 uppåt
                player2.Move(-1);
            }
            if (Input.IsPressed(ConsoleKey.DownArrow))
            {
                //Flytta spelare 1 nedåt
                player2.Move(1);
            }

            if (Input.IsPressed(ConsoleKey.W))
            {
                //Flytta spelare 2 uppåt
                player1.Move(-1);
            }
            if (Input.IsPressed(ConsoleKey.S))
            {
                //Flytta spelare 2 nedåt
                player1.Move(1);
            }

            player1.Draw();
            player2.Draw();

            //Skriver ut poängen
            Console.SetCursorPosition(width / 2 - 4, 0);
            Console.Write($"{player1.points} - {player2.points}");

            //När spelare får 5 poäng avslutas spelet
            if (player1.points >= 5 || player2.points >= 5) return false;

            //Return true om spelet ska fortsätta
            return true;

        }
    }
}
