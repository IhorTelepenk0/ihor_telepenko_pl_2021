using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Geometry
{
    public interface IReflectable
    {
        public void ReflectX();
        public void ReflectY();
    }

    
    public class Point : IReflectable
    {
        private double _x;
        private double _y;

        //public readonly double X ;
        //public readonly double Y ;
        public double X 
        {
            get
            {
                return _x;
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }
        }

        public Point(double x)
        {
            _x = x;
            _y = 0;
        }

        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        void IReflectable.ReflectX()
        {
            _y *= -1;
        }

        void IReflectable.ReflectY()
        {
            _x *= -1;
        }

        protected void ChangeCoordinates(double newX, double newY)
        {
            _x = newX;
            _y = newY;
        }

        public virtual bool IsOnAxis
        {
            get
            {
                if (X == 0 || Y == 0)
                    return true;
                else return false;
            }
        }
    }
}
