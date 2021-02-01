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
        //private double _x;
        //private double _y;

        //public readonly double X ;
        //public readonly double Y ;
        public double X
        {
            get
            {
                return X;
            }

            private set
            {
                X = value;
            }
        }

        public double Y
        {
            get
            {
                return Y;
            }

            private set
            {
                Y = value;
            }
        }

        public Point(double x)
        {
            X = x;
            Y = 0;
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        void IReflectable.ReflectX()
        {
            Y *= -1;
        }

        void IReflectable.ReflectY()
        {
            X *= -1;
        }

        protected void ChangeCoordinates(double newX, double newY)
        {
            X = newX;
            Y = newY;
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
