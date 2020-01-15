using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            Point2D A = new Point2D(0, 0);
            Point2D B = new Point2D(0, 3);
            Point2D C = new Point2D(3, 3);
            Point2D D = new Point2D(3, 0);
            try
            {
                IsoscelesTrapezium ABCD = new IsoscelesTrapezium(A, B, C, D);
                Console.WriteLine(ABCD.ToString());
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }
            Console.WriteLine();
            try
            {
                Rhombus r = new Rhombus(A, B, C, D);
                Console.WriteLine(r.ToString());
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            Console.WriteLine();
            try
            {
                Quad q = new Quad(A, B, C, D);
                Console.WriteLine(q.ToString());
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            Console.ReadKey();

        }
    }
}
