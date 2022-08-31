using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';

        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
        }

        private void SetHorizontalLine(int topY)
        {
            for (int i = 0; i < this.LeftX; i++)
            {
                this.Draw(i, topY, wallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int i = 0; i < this.TopY; i++)
            {
                this.Draw(leftX, i, wallSymbol);
            }
        }

        private void SetsWallBordes()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(this.TopY);
            SetVerticalLine(0);
            SetVerticalLine(this.LeftX - 1);
        }

        public bool IsPointOfWall(Point snake)
        {
            return snake.TopY == 0 || snake.LeftX == 0 || snake.LeftX == this.LeftX - 1 || snake.TopY == this.TopY;
        }
    }
}
