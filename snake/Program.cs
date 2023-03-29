using System;

namespace snake
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize game objects
            Field field = new Field(40, 20);
            Snake snake = new Snake(20, 10, 9, 'l');
            Food food = new Food(field.FieldWidth, field.FieldHeight);
            int points = snake.Length;

            // Game loop
            while (true)
            {
                // Draw game objects
                field.Draw();
                snake.Draw();
                food.Draw();

                Console.SetCursorPosition(0, 22);

                Console.Write("Points: " + points);
                
                
                // Handle user input
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            snake.Direction = 'u';
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Direction = 'd';
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.Direction = 'l';
                            break;
                        case ConsoleKey.RightArrow:
                            snake.Direction = 'r';
                            break;
                    }
                }


                // Update game objects
                snake.Move();

                // Check for collisions with food
                if (snake.Body[0].x == food.XPosition && snake.Body[0].y == food.YPosition)
                {
                    snake.Length++;
                    points++;
                    food = new Food(field.FieldWidth, field.FieldHeight);
                }

                // Check for collisions with field edges
                if (snake.Body[0].x == 0 || snake.Body[0].x == field.FieldWidth + 1 ||
                    snake.Body[0].y == 0 || snake.Body[0].y == field.FieldHeight + 1)
                {
                    Console.Clear();
                    Console.WriteLine("Game over! Do you want to play again? (yes/no)");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "yes")
                    {
                        // Reset game objects and start again
                        field = new Field(40, 20);
                        snake = new Snake(20, 10, 3, 'l');
                        food = new Food(field.FieldWidth, field.FieldHeight);
                        points = 0;
                    }
                    else
                    {
                        // Exit the game
                        return;
                    }
                }
                // Wait for a short time to control the game speed
                System.Threading.Thread.Sleep(250);
            }
        }
    }
}
