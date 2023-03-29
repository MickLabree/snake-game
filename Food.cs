using System;

namespace snake
{
    public class Food
    {
        private int xPosition;
        private int yPosition;

        public int XPosition 
        {
            get { return xPosition; }
            set { xPosition = value; }
        }

        public int YPosition 
        {
            get { return yPosition; }
            set { yPosition = value; }
        }

        public Food(int fieldWidth, int fieldHeight)
        {
            Random random = new Random();
            xPosition = random.Next(1, fieldWidth - 1);
            yPosition = random.Next(1, fieldHeight - 1);
        }

        public void Draw()
        {
            Console.SetCursorPosition(xPosition, yPosition);
            Console.Write("█");
        }
    }
}

