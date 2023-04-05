using System;
using System.Collections.Generic;

namespace snake
{
    public class Snake
    {
        Program program = new Program();

        private List<Point> body;
        private int length;
        private char direction;
        public int point = 0;

        public Snake(int x, int y, int length, char direction)
        {
            this.body = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                body.Add(new Point(x + i, y));
            }
            this.length = length;
            this.direction = direction;
        }

        public List<Point> Body
        {
            get { return body; }
        }

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public char Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (Point point in body)
            {
                Console.SetCursorPosition(point.x, point.y);
                Console.Write("█");
            }
            Console.ResetColor();
        }

        public void Move()
        {
            // Move the head
            Point head = body[0];
            switch (direction)
            {
                case 'u':
                    body.Insert(0, new Point(head.x, head.y - 1));
                    break;
                case 'd':
                    body.Insert(0, new Point(head.x, head.y + 1));
                    break;
                case 'l':
                    body.Insert(0, new Point(head.x - 1, head.y));
                    break;
                case 'r':
                    body.Insert(0, new Point(head.x + 1, head.y));
                    break;
            }

            // Check for collisions with body
            for (int i = 1; i < body.Count; i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                {
                    Console.Clear();
                    Console.WriteLine("Game over! Do you want to play again? (yes/no)");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "yes")
                    {
                        // Reset game objects and start again
                        body.Clear();
                        length = 3;
                        {
                            
                        }
                        for (int j = 0; j < length; j++)
                        {
                            body.Add(new Point(20 + j, 10));
                        }
                        direction = 'l';
                        point = 0;
                    }
                    else
                    {
                        // Exit the game
                        Environment.Exit(0);
                    }
                }
            }

            // Remove the tail if the snake hasn't grown
            if (body.Count > length)
            {
                body.RemoveAt(body.Count - 1);
            }
        }

        public void Pause()
        {
            Console.WriteLine("Paused. Press Spacebar to resume.");
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar)
            {
            }
        }
    }

    public class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
