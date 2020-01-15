using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class Triangle : IComparable<Triangle>
    {
        private Point2D A, B, C;
        public double Perimeter {get; protected set;}
        public double[] Sides { get; protected set;}
        public double Square { get; protected set; }
        public Triangle (Point2D A,Point2D B,Point2D C)
        {
            if (TriangleExist(A,B,C))
            {
                this.A = A; this.B = B;
                this.C = C;
                double AtoB = A.DistanceTo(B);
                double BtoC = B.DistanceTo(C);
                double CtoA = C.DistanceTo(A);
                Sides = new double[3];
                Sides[0] = AtoB; Sides[1] = BtoC; Sides[2] = CtoA;
                Perimeter = AtoB + BtoC + CtoA;
                Square = Math.Sqrt((Perimeter / 2) * ((Perimeter / 2) - AtoB) * ((Perimeter / 2) - BtoC) * ((Perimeter / 2) - CtoA));
            }
            else throw new Exception($"Cant Create Triangle on points {A.GetHashCode()} , {B.GetHashCode()} , {C.GetHashCode()}");
        }
        private bool TriangleExist(Point2D A,Point2D B,Point2D C)
        {
            double a = A.DistanceTo(B);
            double b = B.DistanceTo(C);
            double c = C.DistanceTo(A);
            if (a <= b + c && b <= a + c && c <= b + a)
            {
                return true;
            }
            return false;
        }

        public int CompareTo(Triangle other)
        {
            if (Square > other.Square)
            {
                return 1;
            }
            else
            {
                if (Square < other.Square)
                {
                    return -1;
                }
                else
                {
                    if (Perimeter == other.Perimeter)
                    {
                        return 0;
                    }
                    else return Perimeter < other.Perimeter ? 1 : -1;
                }
            }
        }
        public override string ToString()
        {
            return "Triangle: {\n"
                   + A.ToString() + '\n'
                   + B.ToString() + '\n'
                   + C.ToString() + '\n'
                   +"Sides : " + Sides[0].ToString() + " " + Sides[1].ToString() + " " + Sides[2].ToString() + '\n'
                   + "Perimeter: " + Perimeter + '\n'
                   + "Square: " + Square + "}";
        }
    }
}
