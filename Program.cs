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
            Point2D A = new Point2D(1, 1);
            Point2D B = new Point2D(2, 3);
            Point2D C = new Point2D(4, 3);
            Point2D D = new Point2D(5, 1);
            try
            {
                Trapezium ABCD = new Trapezium(A, B, C, D);
                Console.WriteLine(ABCD.ToString());
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }
            Console.ReadKey();
        }
    }
}
