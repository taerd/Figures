using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class Rhombus : IComparable<Rhombus>
    {
        protected Point2D A, B, C, D;
        public double Perimeter { get; private set; }
        public double Side { get; private set; }
        public double Square { get; private set; }
        public Rhombus(Point2D A, Point2D B, Point2D C, Point2D D)
        {
            if (RhombusExists(A, B, C, D))
            {
                this.A = A;this.B = B;this.C = C;this.D = D;
                Side = A.DistanceTo(B);
                Perimeter = 4 * Side;
                Square = 0.5 * A.DistanceTo(C) * B.DistanceTo(D);
            }
            else throw new Exception($"Cant create rhombus on points A({A.Coordinates[0]},{A.Coordinates[1]}) , B({B.Coordinates[0]},{B.Coordinates[1]}) , C({C.Coordinates[0]},{C.Coordinates[1]}) , D({D.Coordinates[0]},{D.Coordinates[1]})");
        }
        public bool RhombusExists(Point2D A, Point2D B, Point2D C, Point2D D)
        {
            double a = A.DistanceTo(B);
            double b = B.DistanceTo(C);
            double c = C.DistanceTo(D);
            double d = D.DistanceTo(A);
            if (a==b && c==d && a==d)//проверка существования ромба
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "Rhombus: {\n"
                   + A.ToString() + '\n'
                   + B.ToString() + '\n'
                   + C.ToString() + '\n'
                   + D.ToString() + '\n'
                   + "Side : " + Side.ToString() + '\n'
                   + "Perimeter: " + Perimeter + '\n'
                   + "Square: " + Square + "}";
        }

        public int CompareTo(Rhombus other)
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
    }
}
