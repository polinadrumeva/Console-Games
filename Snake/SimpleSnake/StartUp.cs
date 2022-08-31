namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.Enums;
    using SimpleSnake.GameObjects;
    using Utilities;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            DifficultyLevel diffLevel = PromptDifficultyLevel();

            Wall wall = new Wall(60, 20);
            DisplayDifficulty(wall, diffLevel);
            Snake snake = new Snake(wall);

            IEngine engine = new Engine(wall, snake, diffLevel);
            engine.Run();
        }

        private static DifficultyLevel PromptDifficultyLevel()
        {
            Console.WriteLine("Choose difficulty: ");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");

            Console.Write("Your choice: ");
            bool validInt = int.TryParse(Console.ReadLine(), out int diffLevelInt);
            if (!validInt)
            {
                Console.WriteLine("Invalid choice!");
                Console.WriteLine("Try again!");
                Main();
            }

            if (diffLevelInt < 1 || diffLevelInt > 3)
            {
                Console.WriteLine("Invalid choice!");
                Console.WriteLine("Try again!");
                Main();
            }

            DifficultyLevel diffLevel = (DifficultyLevel)diffLevelInt;

            Console.Clear();
            return diffLevel;
        }

        private static void DisplayDifficulty(Wall wall, DifficultyLevel level)
        {
            Console.SetCursorPosition(wall.LeftX + 2, 1);
            Console.Write($"Difficulty level: {level.ToString()}");
        }
    }
}

