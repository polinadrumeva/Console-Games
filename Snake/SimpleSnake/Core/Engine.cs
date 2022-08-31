using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;


namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {
        private readonly GameObjects.Point[] pointsOfDirection;
        private readonly Snake snake;
        private readonly Wall wall;

        private Direction direction;
        private double sleepTime;
        private readonly DifficultyLevel diffLevel;

        private Engine()
        {
            this.sleepTime = 100;
            this.pointsOfDirection = new GameObjects.Point[4];
        }

        public Engine(Wall wall, Snake snake, DifficultyLevel diffLevel)
            : this()
        {
            this.wall = wall;
            this.snake = snake;
            this.diffLevel = diffLevel;
        }

        public void Run()
        {
            this.InitializeDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.GetNextDirection();
                }

                bool canMove = this.snake
                    .CanMove(this.pointsOfDirection[(int)this.direction]);
                if (!canMove)
                {
                    this.AskUserForRestart();
                }

                double sleepDecrement = this.GetSleepTimeDecrement();
                this.sleepTime -= sleepDecrement;
                Thread.Sleep((int)this.sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 1; 
            int topY = 3; 

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");

            string input = Console.ReadLine();
            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                this.StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game over!");
            Environment.Exit(0);
        }

        private void InitializeDirections()
        {
            this.pointsOfDirection[0] = new GameObjects.Point(1, 0);
            this.pointsOfDirection[1] = new GameObjects.Point(-1, 0);
            this.pointsOfDirection[2] = new GameObjects.Point(0, 1);
            this.pointsOfDirection[3] = new GameObjects.Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (this.direction != Direction.Right)
                {
                    this.direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (this.direction != Direction.Left)
                {
                    this.direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (this.direction != Direction.Down)
                {
                    this.direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (this.direction != Direction.Up)
                {
                    this.direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }

        private double GetSleepTimeDecrement()
        {
            double sleepDecrement = 0;
            if (this.diffLevel == DifficultyLevel.Easy)
            {
                sleepDecrement = 0.01;
            }
            else if (this.diffLevel == DifficultyLevel.Medium)
            {
                sleepDecrement = 0.05;
            }
            else
            {
                sleepDecrement = 0.1;
            }

            return sleepDecrement;
        }
    }
}

