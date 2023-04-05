using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snake
{
    public class Field
    {
        public int FieldWidth;
        public int FieldHeight;

        public Field(int width, int height)
        {
            this.FieldWidth = width;
            this.FieldHeight = height;
        }

        public void DrawCreative()
        {
            Console.Clear(); // clear the console before drawing

            // draw the top border
            for (int i = 0; i < FieldWidth + 2; i++)
            {
                if (i == FieldWidth / 2 + 1) // check if in the middle
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("█");
                }
            }
            Console.WriteLine();

            // draw the sides
            for (int i = 0; i < FieldHeight; i++)
            {
                Console.Write("█");
                for (int j = 0; j < FieldWidth; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("█");
            }

            // draw the bottom border
            for (int i = 0; i < FieldWidth + 2; i++)
            {
                if (i == FieldWidth / 2 + 1) // check if in the middle
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("█");
                }
            }
            Console.WriteLine();
        }

        public void Draw()
        {
            Console.Clear(); // clear the console before drawing

            // draw the top border
            for (int i = 0; i < FieldWidth + 2; i++)
            {
                Console.Write("█");
            }
            Console.WriteLine();

            // draw the sides
            for (int i = 0; i < FieldHeight; i++)
            {
                Console.Write("█");
                for (int j = 0; j < FieldWidth; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("█");
            }

            // draw the bottom border
            for (int i = 0; i < FieldWidth + 2; i++)
            {
                Console.Write("█");
            }
            Console.WriteLine();
        }
    }
}