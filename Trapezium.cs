using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class Trapezium : IComparable<Trapezium>
    {
        protected Point2D A, B, C, D;
        protected double [] Basis;
        protected double [] Lateral;
        public double Perimeter { get; set; }
        public double Square { get; set; }//ошибся в вычислении площади
        public Trapezium(Point2D A,Point2D B,Point2D C,Point2D D)
        {
            if (TrapeziumExists(A,B,C,D))
            {
                this.A = A;this.B = B;this.C = C;this.D = D;
                Perimeter = Basis[0] + Basis[1] + Lateral[0] + Lateral[1];
                Square = ( (Basis[0]+Basis[1]) / 2 ) * Math.Sqrt( Lateral[0]*Lateral[0] - Math.Pow( ( ( (Basis[0] - Basis[1])*(Basis[0] - Basis[1]) + (Lateral[0] * Lateral[0]) - (Lateral[1] * Lateral[1]) ) / 2 * Math.Abs(Basis[0] - Basis[1]) ),2 ) );
            }
            else throw new Exception($"Cant Create Trapezium on points A({A.Coordinates[0]},{A.Coordinates[1]}) , B({B.Coordinates[0]},{B.Coordinates[1]}) , C({C.Coordinates[0]},{C.Coordinates[1]}) , D({D.Coordinates[0]},{D.Coordinates[1]})");
        }
        private bool TrapeziumExists(Point2D A, Point2D B, Point2D C, Point2D D)
        {
            double a = A.DistanceTo(B);
            double b = B.DistanceTo(C);
            double c = C.DistanceTo(D);
            double d = D.DistanceTo(A);
            if (a < b + c+ d && b < a + c +d && c < b + a +d && d < a + b + c)//проверка существования замкнутого четырехугольника
            {
                double [] ab = new double[2];
                double [] ad = new double[2];
                double [] cb = new double[2];
                double [] cd = new double[2];
                ab = A.GetVector(B);
                ad = A.GetVector(D);
                cb = C.GetVector(B);
                cd = C.GetVector(D);
                if(ab[0] / ad[0] == ab[1] / ad[1] || cb[0] / cd[0] == cb[1] / cd[1])//из одной точки не может выйти два коллинеарных вектора
                {
                    return false;
                }
                if ( ((cd[0] != 0)? ab[0] / cd[0] : ab[1] / cd[1]) == ((cd[1] != 0) ? ab[1] / cd[1] : ab[0] / cd[0]) )//коллинеарность противоположных векторов(параллельность сторон)
                {
                    Basis = new double[2];
                    Basis[0] = a;
                    Basis[1] = c;
                    Lateral = new double[2];
                    Lateral[0] = b;
                    Lateral[1] = d;
                    return true;
                }
                if( ((cb[0] != 0)? ad[0] / cb[0]: ad[1]/cb[1]) == ((cb[1] != 0) ? ad[1] / cb[1] : ad[0] / cb[0]) )
                {
                    Basis = new double[2];
                    Basis[0] = b;
                    Basis[1] = d;
                    Lateral = new double[2];
                    Lateral[0] = a;
                    Lateral[1] = c;
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return "Trapezium: {\n"
                   + A.ToString() + '\n'
                   + B.ToString() + '\n'
                   + C.ToString() + '\n'
                   + D.ToString() + '\n'
                   + "Perimeter: " + Perimeter + '\n'
                   + "Square: " + Square + "}";
        }

        public int CompareTo(Trapezium other)
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
