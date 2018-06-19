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
            Calcu.LineandLine(L, L2);
            Circle CI=new Circle(A,B,C,D);
   
            Calcu.PointandLine(B,L);
            
    
    
            Console.ReadKey();
            
        }
    }
}
