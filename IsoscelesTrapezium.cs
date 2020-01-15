using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class IsoscelesTrapezium : Trapezium
    {
        public IsoscelesTrapezium(Point2D A, Point2D B, Point2D C, Point2D D) : base(A, B, C, D)
        {
            if (Lateral[0] != Lateral[1])
            {
                throw new Exception($"Cant create isosceles trapezium on points A({A.Coordinates[0]},{A.Coordinates[1]}) , B({B.Coordinates[0]},{B.Coordinates[1]}) , C({C.Coordinates[0]},{C.Coordinates[1]}) , D({D.Coordinates[0]},{D.Coordinates[1]})");
            }
        }
        public override string ToString()
        {
            return "Isosceles Trapezium: {\n"
                   + A.ToString() + '\n'
                   + B.ToString() + '\n'
                   + C.ToString() + '\n'
                   + D.ToString() + '\n'
                   + "Sides : " + Basis[0].ToString() + "  " + Basis[1].ToString() + "  " + Lateral[0].ToString() + "  " + Lateral[1].ToString() + "  " + '\n'
                   + "Perimeter: " + Perimeter + '\n'
                   + "Square: " + Square + "}";
        }
    }
}
