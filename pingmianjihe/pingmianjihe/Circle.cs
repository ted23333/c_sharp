using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pingmianjihe
{
     public class Circle                                        //定义圆类
    {
        private double x, y, r;
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value; 
            }
        }
        public double Y { 
            get
            {
                return y;
            } 
            set
            {
                y = value;
            } 
        }
        public double  Radius {
            get
            {
                return r;
            }
            set 
            {
                r = value;
            }
        }
        public Circle(double x, double y, double r)
        {
            this.x = x;
            this.y= y;
            this.r= r;
        }
        public Circle(params Point[] po)            //多个点拟合圆
        {
            if (po.Length < 3)                                //两点无法拟合圆
            {
                Console.WriteLine("无法生成一个圆");
                //异常
            }
            else
            {
                double X1 = 0;                         //最小二乘法拟合圆
                double Y1 = 0;
                double X2 = 0;
                double Y2 = 0;
                double X3 = 0;
                double Y3 = 0;
                double X1Y1 = 0;
                double X1Y2 = 0;
                double X2Y1 = 0;
                for (int i = 0; i < po.Length; i++)
                {
                    X1 = X1 + po[i].X;
                    Y1 = Y1 + po[i].Y;
                    X2 = X2 + po[i].X * po[i].X;
                    Y2 = Y2 + po[i].Y * po[i].Y;
                    X3 = X3 + po[i].X * po[i].X * po[i].X;
                    Y3 = Y3 + po[i].Y * po[i].Y * po[i].Y;
                    X1Y1 = X1Y1 + po[i].X * po[i].Y;
                    X1Y2 = X1Y2 + po[i].X * po[i].Y * po[i].Y;
                    X2Y1 = X2Y1 + po[i].X * po[i].X * po[i].Y;
                }
                double C, D, E, G, H, N;
                double a, b, c;
                N = po.Length;
                C = N * X2 - X1 * X1;
                D = N * X1Y1 - X1 * Y1;
                E = N * X3 + N * X1Y2 - (X2 + Y2) * X1;
                G = N * Y2 - Y1 * Y1;
                H = N * X2Y1 + N * Y3 - (X2 + Y2) * Y1;
                a = (H * D - E * G) / (C * G - D * D);
                b = (H * C - E * D) / (D * D - G * C);
                c = -(a * X1 + b * Y1 + X2 + Y2) / N;
                this.x = a / (-2);
                this.y = b / (-2);
                this.r = Math.Sqrt(a * a + b * b - 4 * c) / 2.0;
            }
        }
    }
}
