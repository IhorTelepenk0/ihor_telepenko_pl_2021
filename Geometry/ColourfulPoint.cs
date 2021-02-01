using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Geometry
{
    public enum PointColour : int
    {
        Red = 0,
        Green = 1,
        Blue = 2 
    }

    public class ColourfulPoint : Point
    {
        public PointColour Colour { get; set; }


        public ColourfulPoint(double x, PointColour col) : base(x)
        {
            Colour = col;
        }

        public ColourfulPoint(double x, double y, PointColour col) : base(x, y)
        {
            Colour = col;
        }

        public void ChangeColour(PointColour col)
        {
            Colour = col;
        }

        public void NextColour()
        {
            Colour = (PointColour)((Convert.ToInt32(Colour) + 1) % 3);
        }

        public override string ToString()
        {
            return string.Format($"({X}, {Y})");
        }

        public void Add(ColourfulPoint newPoint)
        {
            base.ChangeCoordinates(newPoint.X, newPoint.Y);
        }

        public static Point Add(Point firstPoint, Point secPoint)
        {
            double newX = firstPoint.X + secPoint.X;
            double newY = firstPoint.Y + secPoint.Y;
            Point newAddedPoint = new Point(newX, newY);

            return newAddedPoint;
        }

        public override bool IsOnAxis
        {
            get
            {
                if ((X == 0 || Y == 0) && Colour == PointColour.Blue)
                    return true;
                else return false;
            } 

        }
    }
}
