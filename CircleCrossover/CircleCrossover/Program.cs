using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleCrossover
{
    class Circle                    //定义circle类
    {
        public double X;
        public double Y;
        public double Radius;
    }
    class Program
    {
        public static double[] Fun_cross(double x1, double y1, double x2, double y2, double r1, double r2)               //定义求交点函数Fun_cross
        {
            double x_1 = 0, x_2 = 0, y_1 = 0, y_2 = 0, a = 0, b = 0, c = 0;                                   //由于先判断位置关系再调用函数，因此方程必定有解
            if (y1 != y2)
            {
                double A = (x1 * x1 - x2 * x2 + y1 * y1 - y2 * y2 + r2 * r2 - r1 * r1) / (2 * (y1 - y2));
                double B = (x1 - x2) / (y1 - y2);
                a = 1 + B * B;
                b = -2 * (x1 + (A - y1) * B);
                c = x1 * x1 + (A - y1) * (A - y1) - r1 * r1;
                x_1 = (-b + System.Math.Sqrt(b * b - 4 * a * c)) / (2 * a);                                    //求解交点坐标x_1,y_1;x_2,y_2
                x_2 = (-b - System.Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                y_1 = A - B * x_1;
                y_2 = A - B * x_2;
            }
            else                                                                                         //如果y1=y2，那么交点横坐标必定相同
            {
                x_1 = x_2 = (x1 * x1 - x2 * x2 + r2 * r2 - r1 * r1) / (2 * (x1 - x2));
                a = 1;
                b = -2 * y1;
                c = y1 * y1 - r1 * r1 + (x_1 - x1) * (x_1 - x1);
                y_1 = (-b + System.Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                y_2 = (-b - System.Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            }
            double[] answer = { x_1, x_2, y_1, y_2 };                                                       /*定义并返回包含交点坐标的数组answer*/
            return answer;                                                                    
        }
        static void Main(string[] args)
        {
            Circle C1 = new Circle();             //定义C1和C2两个圆
            Circle C2 = new Circle();   
            double[] ans = { 0 };                  //定义函数返回的交点坐标数组
            Console.WriteLine("input the first circle centre's Xcoordinate :");                                             //输入圆的基本信息  
            C1.X = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("input the first circle centre's Ycoordinate:");
            C1.Y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("input the first circle's Radius:");
            C1.Radius = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("input the second circle centre's Xcoordinate:");
            C2.X = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("input the second circle centre's Ycoordinate:");
            C2.Y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("input the second circle's Radius:");
            C2.Radius = Convert.ToDouble(Console.ReadLine());
            double d_twocirclepoint = System.Math.Sqrt((C1.X - C2.X) * (C1.X - C2.X) + (C1.Y - C2.Y) * (C1.Y - C2.Y));    //定义两个圆心之间的距离d_twocirclepoint
            if (d_twocirclepoint > C1.Radius + C2.Radius)                             //判断两个圆之间的位置关系，如果两个圆有交点，则调用Fun_cross（）函数求交点
            { 
                Console.WriteLine("两圆相离");                                
            }
            else if (d_twocirclepoint < System.Math.Abs(C1.Radius - C2.Radius))
            {
                Console.WriteLine("两圆内含");
            }
            else if (d_twocirclepoint == System.Math.Abs(C1.Radius - C2.Radius))
            {
                Console.WriteLine("两圆内切");
                ans = Fun_cross(C1.X, C1.Y, C2.X, C2.Y, C1.Radius, C2.Radius);
                Console.WriteLine("交点的坐标是({0},{1})", ans[0], ans[2]);
            }
            else if (d_twocirclepoint == (C1.Radius + C2.Radius))
            {
                Console.WriteLine("两圆外切");
                ans = Fun_cross(C1.X, C1.Y, C2.X, C2.Y, C1.Radius, C2.Radius);
                Console.WriteLine("交点的坐标是({0},{1})", ans[0], ans[2]);
            }
            else
            {
                Console.WriteLine("两圆相交");
                ans = Fun_cross(C1.X, C1.Y, C2.X, C2.Y, C1.Radius, C2.Radius);
                Console.WriteLine("交点的坐标是({0},{1}),({2},{3})", ans[0], ans[2], ans[1], ans[3]);
            }
        }
    }
}
