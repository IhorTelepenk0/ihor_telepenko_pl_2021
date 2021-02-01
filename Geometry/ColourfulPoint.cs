using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    public enum PointColour
    {
        Red,
        Green,
        Blue 
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

        
    }
}
