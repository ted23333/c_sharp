using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pingmianjihe
{
    class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point(0, 0);
            Point B = new Point(2, 0);
            Point C = new Point(1, 1);
            Point D = new Point(1, -1);
            Circle CI=new Circle(A,B,C,D);
            Console.WriteLine("{0},{1},{2}",CI.X,CI.Y,CI.Radius);
            Cordinate.Xpoint = 0;
            Line L = new Line(1,1,2,2);
         
            Console.WriteLine("{0}", L.ToString());
            Console.ReadKey();
            
        }
    }
}
