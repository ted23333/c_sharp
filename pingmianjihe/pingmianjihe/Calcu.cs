using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
namespace pingmianjihe
{
    public static class Calcu
    {
        public static void PointandPoint(Point A, Point B)                   //点与点计算
        {
            double PtoPDistance = Math.Sqrt((B.X - A.X) * (B.X - A.X) + (B.Y - A.Y) * (B.Y - A.Y));
            //两点距离
            Line Twopoint = new Line(A, B);
            //两点连线的直线
            double MidX = (A.X + B.X) / 2;
            double MidY = (A.Y + B.Y) / 2;
            double MidAngle = Twopoint.AccessAngle + 90;
            Line TwoPointperpendicularbisector = new Line(MidX, MidY, MidAngle);
            //垂直平分线TwoPointperpendicularbisector
        }

        public static void PointandLine(Point A, Line L)                        //点与线计算
        {
            Cordinate.MoveDist_X = L.Xpoint;
            Cordinate.MoveDist_Y = L.Ypoint;
            double dis_pointtoline = Math.Sqrt((L.Xpoint - A.X) * (L.Xpoint - A.X) + (L.Ypoint - A.Y) * (L.Ypoint - A.Y));
            double pointtolineangle = new Line(A.X, A.Y, L.Xpoint, L.Ypoint).AccessAngle;
            Cordinate.RevolveAngle = L.AccessAngle - pointtolineangle;
            //静态类坐标系,利用旋转平移求出对称点与点到直线距离   revolveangle是坐标系需要旋转的角度
            double distance = dis_pointtoline * Math.Sin(Math.PI / 180 * Math.Abs(Cordinate.RevolveAngle));
            //通过坐标系旋转变换实现求距离
            double MirrorX;
            double MirrorY;
            //定义关于直线对称的点Mirror
            if (distance > 0)
            {
                double anglemove = 90 + L.AccessAngle;
                double vector = A.Y - (Math.Tan(Math.PI / 180 * L.AccessAngle) * (A.X - L.Xpoint) + L.Ypoint);
                if (vector > 0 && L.AccessAngle > 0)
                {
                    MirrorX = A.X + 2 * distance * Math.Abs(Math.Cos(Math.PI / 180 * anglemove));
                    MirrorY = A.Y - 2 * distance * Math.Sin(Math.PI / 180 * anglemove);
                }
                else if (vector > 0 && L.AccessAngle < 0)
                {
                    MirrorX = A.X - 2 * distance * Math.Abs(Math.Cos(Math.PI / 180 * anglemove));
                    MirrorY = A.Y - 2 * distance * Math.Sin(Math.PI / 180 * anglemove);
                }
                else if (vector < 0 && L.AccessAngle > 0)
                {
                    MirrorX = A.X - 2 * distance * Math.Abs(Math.Cos(Math.PI / 180 * anglemove));
                    MirrorY = A.Y + 2 * distance * Math.Sin(Math.PI / 180 * anglemove);
                }
                else if (vector < 0 && L.AccessAngle < 0)
                {
                    MirrorX = A.X + 2 * distance * Math.Abs(Math.Cos(Math.PI / 180 * anglemove));
                    MirrorY = A.Y + 2 * distance * Math.Sin(Math.PI / 180 * anglemove);
                }
                else
                {
                    MirrorX = 0;
                    MirrorY = 0;
                    //此处为异常
                }
                //通过平移旋转坐标变换求出关于直线对称的点
            }
        }

        public static void PointandCircle(Point A, Circle C)
        {
            double PtoCDistance = Math.Sqrt((C.X - A.X) * (C.X - A.X) + (C.Y - A.Y) * (C.Y - A.Y));
            //点和圆心两个点的距离
            if (PtoCDistance > C.Radius)
            {

            }
            else if (PtoCDistance == C.Radius)
            {

            }
            else
            {

            }
        }               //点与圆计算

        public static void LineandLine(Line L1, Line L2)                          //线与线计算
        {
            double IncludedAngle;
            //两条直线的夹角
            if (L1.AccessAngle >= 0 && L2.AccessAngle >= 0 || L1.AccessAngle < 0 && L1.AccessAngle < 0)
            {
                IncludedAngle = Math.Abs(L1.AccessAngle - L2.AccessAngle);
            }
            else if (L1.AccessAngle >= 0 && L2.AccessAngle < 0)
            {
                IncludedAngle = 180 + L2.AccessAngle - L1.AccessAngle;
            }
            else
            {
                IncludedAngle = 180 + L1.AccessAngle - L2.AccessAngle;
            }
            //将两条直线平移到过原点的位置，计算两条直线的夹角
            double MidX = 0;
            double MidY = 0;
            if (L1.AccessAngle == L2.AccessAngle)
                Console.WriteLine("no IncludedAngle");
            //异常
            //如果两条直线斜率相同，则他们重合或者没有交点
            else
            {
                double MoveX = L1.Ypoint - Math.Tan(Math.PI / 180 * L1.AccessAngle) * L1.Xpoint - L2.Ypoint + Math.Tan(Math.PI / 180 * L2.AccessAngle) * L2.Xpoint;
                //计算
                double MoveY = (L1.Ypoint - Math.Tan(Math.PI / 180 * L1.AccessAngle) * L1.Xpoint) * Math.Tan(Math.PI / 180 * L2.AccessAngle)
                    - (L2.Ypoint - Math.Tan(Math.PI / 180 * L2.AccessAngle) * L2.Xpoint) * Math.Tan(Math.PI / 180 * L1.AccessAngle);
                double MoveAngle = -Math.Tan(Math.PI / 180 * L1.AccessAngle) + Math.Tan(Math.PI / 180 * L2.AccessAngle);
                MidX = MoveX / MoveAngle;
                MidY = MoveY / MoveAngle;
                //利用旋转平移求得两条直线交点，因为两条直线斜率不同，因此MoveAngle必定不为零，即不会出现除以0的情况
            }
            double MidLineAngle = L1.AccessAngle > L2.AccessAngle ? (L2.AccessAngle + 1 / 2 * IncludedAngle) :
                (L1.AccessAngle + 1 / 2 * IncludedAngle);
            //计算角平分线的角度angle
            Line MidCrossLine = new Line(MidX, MidY, MidLineAngle);
        }

        public static void LineandCircle(Line L, Circle C)                       //线与圆计算
        {
            Point A = new Point(C.X, C.Y);
            PointandLine(A, L);
            //求圆心到直线的距离


        }

        public static void CircleandCircle(Circle C1, Circle C2)
        {
            double dis = Math.Sqrt((C1.X - C2.X) * (C1.X - C2.X) + (C1.Y - C2.Y) * (C1.Y - C2.Y));
            //两个圆心之间的距离
            double[] ans = { 0 };                  
            //定义函数返回的交点坐标数组
            if (dis > C1.Radius + C2.Radius)                           
                //判断两个圆之间的位置关系，如果两个圆有交点，则调用Fun_cross（）函数求交点
            {
                Console.WriteLine("两圆相离");
            }
            else if (dis < System.Math.Abs(C1.Radius - C2.Radius))
            {
                Console.WriteLine("两圆内含");
                //
            }
            else if (dis == System.Math.Abs(C1.Radius - C2.Radius))
            {
                Console.WriteLine("两圆内切");
                ans = Fun_cross(C1.X, C1.Y, C2.X, C2.Y, C1.Radius, C2.Radius, dis);
                Console.WriteLine("交点的坐标是({0},{1})", ans[0], ans[2]);
                //两个圆的交点坐标实际上只有一个或者说两个交点坐标重合
            }
            else if (dis == (C1.Radius + C2.Radius))
            {
                Console.WriteLine("两圆外切");
                ans = Fun_cross(C1.X, C1.Y, C2.X, C2.Y, C1.Radius, C2.Radius, dis);
                Console.WriteLine("交点的坐标是({0},{1})", ans[0], ans[2]);
                //同内切
            }
            else
            {
                Console.WriteLine("两圆相交");
                ans = Fun_cross(C1.X, C1.Y, C2.X, C2.Y, C1.Radius, C2.Radius, dis);
                //相交则调用Fun_cross函数求焦点，将返回的数组赋值给ans数组
                Console.WriteLine("交点的坐标是({0},{1}),({2},{3})", ans[0], ans[2], ans[1], ans[3]);
            }
            //
            //求两个圆的对称轴直线
            //
            #region 对称轴
            Line CirandCirLine = new Line(C1.X, C1.Y, C2.X, C2.Y);
            //过两个圆圆心的对称轴
            if (C1.Radius == C2.Radius)
            {
                Line PoandPoLine = new Line(1 / 2 * (C1.X + C2.X), 1 / 2 * (C1.Y + C1.Y), (CirandCirLine.AccessAngle + 90));
                //如果两个圆半径相同，两个圆的圆心连线垂直平分线也是他的对称轴
                // CirandCirLine    PoandPoLine是两个圆的对称轴
            }
            #endregion
            //
            //求两个圆的切线
            //
            //两圆相交有两条公切线，相离有四条公切线
            Line TangentLine1;
            Line TangentLine2;
            //外公切线1，2
            Line TangentLine3;
            Line TangentLine4;
            //内公切线3,4
            Line TangentLine5;
            //过两个相切圆切点的切线5
            double CirandCrossPoint_Distance;
            //大圆的圆心到公切线交点的距离 CirandCrossPoint_Distance
            double CirandCrossPoint_X;
            double CirandCrossPoint_Y;
            double CirandCrossPoint_IncludedAngle;
            //公切线交点坐标
            #region 两个圆外公切线计算
            if (dis > System.Math.Abs(C1.Radius - C2.Radius))
            //两个圆不内含就必定存在两条外公切线
            {
                if (C1.Radius > C2.Radius)
                //两个圆半径不同，最后两条公切线一定交于一点
                {
                    CirandCrossPoint_Distance = C1.Radius * dis / (C1.Radius - C2.Radius);
                    CirandCrossPoint_IncludedAngle = Math.Asin(C1.Radius / CirandCrossPoint_Distance) / Math.PI * 180;
                    //大圆的圆心到公切线交点的距离 CirandCrossPoint_Distance
                    if (C2.X >= C1.X)
                    {
                        CirandCrossPoint_X = C1.X + CirandCrossPoint_Distance * Math.Cos(Math.PI / 180 * CirandCirLine.AccessAngle);
                        CirandCrossPoint_Y = C1.Y + CirandCrossPoint_Distance * Math.Sin(Math.PI / 180 * CirandCirLine.AccessAngle);
                    }
                    else
                    {
                        CirandCrossPoint_X = C1.X - CirandCrossPoint_Distance * Math.Cos(Math.PI / 180 * CirandCirLine.AccessAngle);
                        CirandCrossPoint_Y = C1.Y - CirandCrossPoint_Distance * Math.Sin(Math.PI / 180 * CirandCirLine.AccessAngle);
                    }
                    //根据旋转平移确定交点坐标
                    TangentLine1 = new Line(CirandCrossPoint_X, CirandCrossPoint_Y, CirandCrossPoint_Distance + CirandCrossPoint_IncludedAngle);
                    TangentLine2 = new Line(CirandCrossPoint_X, CirandCrossPoint_Y, CirandCrossPoint_Distance - CirandCrossPoint_IncludedAngle);
                }
                else if (C1.Radius < C2.Radius)
                {
                    CirandCrossPoint_Distance = C2.Radius * dis / (C2.Radius - C1.Radius);
                    CirandCrossPoint_IncludedAngle = Math.Asin(C1.Radius / CirandCrossPoint_Distance) / Math.PI * 180;
                    if (C1.X >= C2.X)
                    {
                        CirandCrossPoint_X = C2.X + CirandCrossPoint_Distance * Math.Cos(Math.PI / 180 * CirandCirLine.AccessAngle);
                        CirandCrossPoint_Y = C2.Y + CirandCrossPoint_Distance * Math.Sin(Math.PI / 180 * CirandCirLine.AccessAngle);
                    }
                    else
                    {
                        CirandCrossPoint_X = C2.X - CirandCrossPoint_Distance * Math.Cos(Math.PI / 180 * CirandCirLine.AccessAngle);
                        CirandCrossPoint_Y = C2.Y - CirandCrossPoint_Distance * Math.Sin(Math.PI / 180 * CirandCirLine.AccessAngle);
                    }
                    //根据旋转平移确定交点坐标，同上
                    TangentLine1 = new Line(CirandCrossPoint_X, CirandCrossPoint_Y, CirandCrossPoint_Distance + CirandCrossPoint_IncludedAngle);
                    TangentLine2 = new Line(CirandCrossPoint_X, CirandCrossPoint_Y, CirandCrossPoint_Distance - CirandCrossPoint_IncludedAngle);
                }
                else
                {
                    TangentLine1 = new Line(C1.X, C1.Y + C1.Radius / Math.Cos(Math.PI / 180 * CirandCirLine.AccessAngle), CirandCirLine.AccessAngle);
                    TangentLine2 = new Line(C1.X, C1.Y - C1.Radius / Math.Cos(Math.PI / 180 * CirandCirLine.AccessAngle), CirandCirLine.AccessAngle);
                    //两个圆如果半径相同那么两条公切线的斜率应该与过两圆心的直线CirandCirLine斜率相同
                }
            }
            //两圆相离有四条公切线
            #endregion

            #region 两个圆的内公切线计算
            if (dis > C1.Radius + C2.Radius)
            {
                if (C1.Radius > C2.Radius)
                //两个圆半径不同，最后两条公切线一定交于一点
                {
                    CirandCrossPoint_Distance = C1.Radius * dis / (C1.Radius + C2.Radius);
                    CirandCrossPoint_IncludedAngle = Math.Asin(C1.Radius / CirandCrossPoint_Distance) / Math.PI * 180;
                    //大圆的圆心到公切线交点的距离 CirandCrossPoint_Distance
                    if (C2.X >= C1.X)
                    {
                        CirandCrossPoint_X = C1.X + CirandCrossPoint_Distance * Math.Cos(Math.PI / 180 * CirandCirLine.AccessAngle);
                        CirandCrossPoint_Y = C1.Y + CirandCrossPoint_Distance * Math.Sin(Math.PI / 180 * CirandCirLine.AccessAngle);
                    }
                    else
                    {
                        CirandCrossPoint_X = C1.X - CirandCrossPoint_Distance * Math.Cos(Math.PI / 180 * CirandCirLine.AccessAngle);
                        CirandCrossPoint_Y = C1.Y - CirandCrossPoint_Distance * Math.Sin(Math.PI / 180 * CirandCirLine.AccessAngle);
                    }
                    //根据旋转平移确定交点坐标
                    TangentLine3 = new Line(CirandCrossPoint_X, CirandCrossPoint_Y, CirandCrossPoint_Distance + CirandCrossPoint_IncludedAngle);
                    TangentLine4 = new Line(CirandCrossPoint_X, CirandCrossPoint_Y, CirandCrossPoint_Distance - CirandCrossPoint_IncludedAngle);
                }
                else if (C1.Radius < C2.Radius)
                {
                    CirandCrossPoint_Distance = C2.Radius * dis / (C2.Radius + C1.Radius);
                    CirandCrossPoint_IncludedAngle = Math.Asin(C2.Radius / CirandCrossPoint_Distance) / Math.PI * 180;
                    if (C1.X >= C2.X)
                    {
                        CirandCrossPoint_X = C2.X + CirandCrossPoint_Distance * Math.Cos(Math.PI / 180 * CirandCirLine.AccessAngle);
                        CirandCrossPoint_Y = C2.Y + CirandCrossPoint_Distance * Math.Sin(Math.PI / 180 * CirandCirLine.AccessAngle);
                    }
                    else
                    {
                        CirandCrossPoint_X = C2.X - CirandCrossPoint_Distance * Math.Cos(Math.PI / 180 * CirandCirLine.AccessAngle);
                        CirandCrossPoint_Y = C2.Y - CirandCrossPoint_Distance * Math.Sin(Math.PI / 180 * CirandCirLine.AccessAngle);
                    }
                    //根据旋转平移确定交点坐标，同上
                    TangentLine3 = new Line(CirandCrossPoint_X, CirandCrossPoint_Y, CirandCrossPoint_Distance + CirandCrossPoint_IncludedAngle);
                    TangentLine4 = new Line(CirandCrossPoint_X, CirandCrossPoint_Y, CirandCrossPoint_Distance - CirandCrossPoint_IncludedAngle);
                }   
            }
            #endregion

            #region 两个相切圆的公切线计算
            if (dis == System.Math.Abs(C1.Radius - C2.Radius) || dis == (C1.Radius + C2.Radius))
            {
                TangentLine5 = new Line(ans[0], ans[2], CirandCirLine.AccessAngle + 90);
            }
            #endregion
        }

        static double[] Fun_cross(double x1, double y1, double x2, double y2, double r1, double r2, double dis)
        //定义使用余弦定理计算圆交点的函数Fun_cross
        {
            double cos_value = (r1 * r1 - r2 * r2 + dis * dis) / (2 * r1 * dis);
            //计算两圆心与交点构成三角形的余弦值cos_value
            double sin_eagle = Math.Sqrt(1 - cos_value * cos_value);
            //对应正弦值sin_value
            double tr_x1 = r1 * cos_value;
            //计算在新的坐标系下的第一个交点横坐标值tr_x1
            double tr_y1 = r1 * sin_eagle;
            //计算在新的坐标系下第一个交点纵坐标值tr_y1
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
            // 第二个交点坐标，也就是将现有坐标系下坐标变换为原坐标下的坐标
            double[] answer = { x_1, x_2, y_1, y_2 };
            /*定义并返回包含交点坐标的数组answer*/
            return answer;
        }
    }
}

