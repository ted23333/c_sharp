using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pingmianjihe
{
    class Line : Point                     //继承point类
    {
        private double [] basepoint;
        private double angle;       //规范化的basepoint 与angle
        private double dis_x;     //x轴截距
        private double dis_y;     //y轴截距
        public double Xpoint {
            get
            {
                return dis_x;               //only readable
            }
        }
        public double Ypoint {
            get 
            {
                return dis_y;                   //only readable
        } 
        }
        private double[] Normalize(double dis_x, double dis_y,double angle)      //标准化函数Normalize
        {  
        double []re=new double[2];
        if (angle == 0)
            re = new double[] { 0, dis_y };
        else if (angle == 90)
            re = new double[] { dis_x, 0 };
       else if (Math.Abs(dis_x) >= Math.Abs(dis_y))
        {
            re = new double[] { 0, dis_y };
        }
        else
            re = new double[] { dis_x, 0 };
        return re;
        }

        public Line()
            : base()
        {

        }
        public Line(Point A, double Angle)                           //给定一个点及角度
            : base(A.X, A.Y)                                                                                                                                                                                                                                         //给定任意点及任意角度
        {
            if (Angle <= 90 && Angle > -90)
                this.angle = Angle;
            else if (Angle > 90)
                this.angle = Angle - Convert.ToInt32(Angle) + Convert.ToInt32(Angle) % 180 - 180 * ((Convert.ToInt32(Angle) % 180) > 90 ? 1 : 0);                                                                               //转化成合理角度
            else
                this.angle = Angle - Convert.ToInt32(Angle) + Convert.ToInt32(Angle) % 180 + 180 * ((Convert.ToInt32(Angle) % 180) < -90 ? 1 : 0);
            //对给定的非标准角度规范化
            if (this.angle != 90)
            {
                this.dis_x = -A.X / Math.Tan(Math.PI / (180 / angle)) + A.X;
                this.dis_y = -A.X * Math.Tan(Math.PI / (180 / angle)) + A.Y;
            }
            else
            {
                this.dis_x = A.X;
                this.dis_y = 0;
            }
            basepoint = Normalize(dis_x, dis_y,angle);
        }

        public Line(double x1, double y1, double x2, double y2)         //给定两点横纵坐标
            : base(x1, y1)                                                                                                                                                                                                                                                    //给定任意两点
        {
            if (x1 == x2)
                this.angle = 90;
            else
            {
                this.angle = Math.Atan((y2 - y1) / (x2 - x1)) / Math.PI * 180;
            }
            if (angle != 90)
            {
                this.dis_x = -y1 / Math.Tan(Math.PI / (180 / angle)) + x1;
                this.dis_y = -x1 * Math.Tan(Math.PI / (180 / angle)) + y1;
            }
            else
            {
                this.dis_x = x1;
                this.dis_y = 0;
            }
            basepoint = Normalize(dis_x, dis_y,angle);
        }

        public Line(Point A, Point B)
            : base(A.X, A.Y)                                                                            //给定两个点
        {
            if (A.X == B.X)
                this.angle = 90;
            else 
            {
                this.angle = Math.Atan((B.Y - A.Y) / (B.X - A.X))/Math.PI*180;    //规范化angle
            }
            if (angle != 90)
            {
                this.dis_x = -A.Y / Math.Tan(Math.PI / (180 / angle)) + A.X;
                this.dis_y = -A.X * Math.Tan(Math.PI / (180 / angle)) + A.Y;
            }
            else
            {
                this.dis_x = A.X;
                this.dis_y = 0;
            }
            basepoint = Normalize(dis_x, dis_y,angle);       //规范化basepoint
        }

        public Line(params Point[] po)                                                                         //多个点最小二乘法
        {
            double total_x = 0, total_y = 0, sq_x = 0, total_xy = 0;   //分别为x之和，y之和，x的平方之和，xy乘积之和
            for (int i = 0; i < po.Length; i++)
            {
                total_x += po[i].X;
                total_y += po[i].Y;
                total_xy += (po[i].X * po[i].Y);
                sq_x += (po[i].X * po[i].X);
            }                                                            //计算以上定义的和
            this.X = total_x / po.Length;
            this.Y = total_y / po.Length;               
            double regression_k = (total_xy - po.Length * this.X * this.Y) / (sq_x - po.Length * this.X * this.X);
            this.angle = Math.Atan(regression_k)/Math.PI*180;
            basepoint = Normalize(dis_x, dis_y,angle);                                    //规范化
        }

        public override string ToString()                                                                                            //重写tostring()方法
        {
            return string.Format("({0},{1}),{2}",Math.Round(basepoint[0],5),Math.Round(basepoint[1],5),Math.Round( angle,5));//保留小数点后五位
        }
        
    }
}

