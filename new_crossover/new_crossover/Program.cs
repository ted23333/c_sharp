using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace new_crossover
{
    class Circle                    //定义circle类
    {
        public double X;
        public double Y;
        public double Radius;
    }
    class Program
    {
        public static double[] Fun_cross(double x1, double y1, double x2, double y2, double r1, double r2, double dis)    //定义使用余弦定理计算圆交点的函数Fun_cross
        {
            double cos_value = (r1 * r1 - r2 * r2 + dis * dis) / (2 * r1 * dis);                                            //计算两圆心与交点构成三角形的余弦值cos_value
            double sin_eagle = System.Math.Sqrt(1 - cos_value * cos_value);                                               //对应正弦值sin_value
            double tr_x1 = r1 * cos_value;                                                                                  //计算在新的坐标系下的第一个交点横坐标值tr_x1
            double tr_y1 = r1 * sin_eagle;                                                                                    //计算在新的坐标系下第一个交点纵坐标值tr_y1
            double tr_x2 = tr_x1;
            double tr_y2 = -r1 * sin_eagle;
            //同理在新的坐标系下的第二个交点横纵坐标
            double x = x2 - x1;
            double y = y2 - y1;
            double r = System.Math.Sqrt(x * x + y * y);
            double cos_value2 = x / r;
            double sin_value2 = y / r;
            //计算从现有坐标系变换到原坐标系需要旋转的角度
            double x_1 = tr_x1 * cos_value2 - tr_y1 * sin_value2 + x1;
            double y_1 = tr_y1 * cos_value2 + tr_x1 * sin_value2 + y1;
            //第一个交点坐标（x_1,y_1)
            double x_2 = tr_x2 * cos_value2 - tr_y2 * sin_value2 + x1;
            double y_2 = tr_y2 * cos_value2 + tr_x2 * sin_value2 + y1;
            //将现有坐标系下坐标变换为原坐标下的坐标
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
                ans = Fun_cross(C1.X, C1.Y, C2.X, C2.Y, C1.Radius, C2.Radius,d_twocirclepoint);
                Console.WriteLine("交点的坐标是({0},{1})", ans[0], ans[2]);
              //两个圆的交点坐标实际上只有一个或者说两个交点坐标重合
            }
            else if (d_twocirclepoint == (C1.Radius + C2.Radius))
            {
                Console.WriteLine("两圆外切");
                ans = Fun_cross(C1.X, C1.Y, C2.X, C2.Y, C1.Radius, C2.Radius,d_twocirclepoint);
                Console.WriteLine("交点的坐标是({0},{1})", ans[0], ans[2]);
                //同内切
            }
            else
            {
                Console.WriteLine("两圆相交");
                ans = Fun_cross(C1.X, C1.Y, C2.X, C2.Y, C1.Radius, C2.Radius,d_twocirclepoint);//相交则调用Fun_cross函数求焦点，将返回的数组赋值给ans数组
                Console.WriteLine("交点的坐标是({0},{1}),({2},{3})", ans[0], ans[2], ans[1], ans[3]);
            }
        }
    }
}

