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
            Point A = new Point(0,1);
            Point B = new Point(0, 0);
            Point C = new Point(1,0);
            Point D = new Point(-1,0);
            Line L = new Line(A,C);
            Line L2 = new Line(D, A);
            Line lineerr = new Line(0, 1, 45);
            Circle C1 = new Circle(0, 0, 1);
            Circle C2 = new Circle(2, 2, 1);
            Circle CI=new Circle(A,B,C,D);
            Calcu.LineandCircle(L, C1);
            Calcu.CircleandCircle(C1, C2);

            
    
    
            Console.ReadKey();
            
        }
    }
}
