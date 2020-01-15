using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class Quad : Rhombus
    {
        public Quad(Point2D A, Point2D B, Point2D C,Point2D D) : base(A,B,C,D)
        {
            double[] AtoB = new double[2];
            double[] AtoD = new double[2];
            AtoB = A.GetVector(B);
            AtoD = A.GetVector(D);
            if( ( AtoB[0]*AtoD[0] + AtoB[1]*AtoD[1] )  != 0)//числитель формуле угла между векторами =0 => угол =90
            {
                throw new Exception($"Cant create quad on points A({A.Coordinates[0]},{A.Coordinates[1]}) , B({B.Coordinates[0]},{B.Coordinates[1]}) , C({C.Coordinates[0]},{C.Coordinates[1]}) , D({D.Coordinates[0]},{D.Coordinates[1]})");
            }
        }
        public override string ToString()
        {
            return "Quad: {\n"
                   + A.ToString() + '\n'
                   + B.ToString() + '\n'
                   + C.ToString() + '\n'
                   + D.ToString() + '\n'
                   + "Side : " + Side.ToString() + '\n'
                   + "Perimeter: " + Perimeter + '\n'
                   + "Square: " + Square + "}";
        }
    }
}
