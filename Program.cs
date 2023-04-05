using System;

namespace snake
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize game objects
            Field field = new Field(40, 20);
            Snake snake = new Snake(20, 10, 3, 'l');
            Food food = new Food(field.FieldWidth, field.FieldHeight);
            int score = 0;
            
            // Set up difficulty levels
            Dictionary<string, int> difficultyLevels = new Dictionary<string, int>();
            difficultyLevels.Add("Easy", 500);
            difficultyLevels.Add("Medium", 250);
            difficultyLevels.Add("Hard", 100);

            // Get user's chosen difficulty level
            Console.Clear();
            Console.WriteLine("Choose difficulty level (Easy, Medium, Hard):");
            string difficulty = Console.ReadLine();
            int speedMultiplier = difficultyLevels[difficulty];

            // Game loop
            while (true)
            {
                // Draw game objects
                field.Draw();
                snake.Draw();
                food.Draw();

                Console.SetCursorPosition(0, 22);
                Console.WriteLine("Score: " + score);
                Console.WriteLine("Press space to pause.");
                
                
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
                        case ConsoleKey.Spacebar:
                            snake.Pause();
                            break;
                    }
                }


                // Update game objects
                snake.Move();

                // Check for collisions with food
                if (snake.Body[0].x == food.XPosition && snake.Body[0].y == food.YPosition)
                {
                    snake.Length++;
                    score++;
                    food = new Food(field.FieldWidth, field.FieldHeight);
                }

                // Check for collisions with the empty space barrier
                if (snake.Body[0].y == 0 && snake.Body[0].x == field.FieldWidth / 2 + 1)
                {
                    // Move the snake to the bottom border
                    snake.Body[0].y = field.FieldHeight;
                }
                else if (snake.Body[0].y == field.FieldHeight + 1 && snake.Body[0].x == field.FieldWidth / 2 + 1)
                {
                    // Move the snake to the top border
                    snake.Body[0].y = 1;
                }


                // Check for collisions with field edges
                if (snake.Body[0].x == 0 || snake.Body[0].x == field.FieldWidth + 1 ||
                    snake.Body[0].y == 0 || snake.Body[0].y == field.FieldHeight + 1)
                {
                    Console.Clear();
                    Console.WriteLine("Game over! Do you want to play again? (yes/no)");
                    string gameOverInput = Console.ReadLine();

                    if (gameOverInput.ToLower() == "yes")
                    {
                        // Reset game objects and start again
                        field = new Field(40, 20);
                        snake = new Snake(20, 10, 3, 'l');
                        food = new Food(field.FieldWidth, field.FieldHeight);
                        score = 0;
                    }
                    else
                    {
                        // Exit the game
                        return; 
                    }
                }
                // Wait for a short time to control the game speed
                System.Threading.Thread.Sleep(speedMultiplier);
            }
        }
    }
}
