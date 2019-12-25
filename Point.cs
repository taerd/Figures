using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    abstract class Point : IEquatable<Point>
    {
        public double [] Coordinates { get; protected set; }
        public int GetDimention()
        {
            return Coordinates.Length;
        }
        public double DistanceTo(Point other)
        {
            if (GetDimention() != other.GetDimention()) throw new Exception($"{this.GetHashCode()} has different dimention with {other.GetHashCode()}");
            else
            {
                double result = 0;
                for(int i = 0; i < GetDimention(); i++)
                {
                    result += (other.Coordinates[i] - this.Coordinates[i]) * (other.Coordinates[i] - this.Coordinates[i]);
                }
                return Math.Sqrt(result);
            }
        }
        public double [] GetVector(Point other)
        {
            if (this.GetDimention() != other.GetDimention()) throw new Exception($"{this.GetHashCode()} has different dimention with {other.GetHashCode()}");
            else
            {
                double [] result = new double[this.GetDimention()];
                for (int i = 0; i < this.GetDimention(); i++)
                {
                    result[i] = other.Coordinates[i] - this.Coordinates[i];
                }
                return result;
            }
        }
        public bool Equals(Point other)
        {
            if (other == null || GetDimention() != other.GetDimention()) return false;
            else
            {
                for(int i = 0; i < GetDimention(); i++)
                {
                    if (this.Coordinates[i] != other.Coordinates[i]) return false;
                }
                return true;
            }
        }
        public override string ToString()
        {
            return "Point[" + GetHashCode() + "]:{" + string.Join(",", Coordinates) + "}";
        }
    }
    class Point2D : Point
    {
        public Point2D(double x,double y)
        {
            Coordinates = new double[2];
            Coordinates[0] = x;
            Coordinates[1] = y;
        }
    }
}
