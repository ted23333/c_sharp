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
            Cordinate.RevolveAngle = L.AccessAngle-pointtolineangle;
            //静态类坐标系,利用旋转平移求出对称点与点到直线距离   revolveangle是坐标系需要旋转的角度
            double distance = dis_pointtoline * Math.Sin(Math.PI/180*Math.Abs(Cordinate.RevolveAngle));
            //通过坐标系旋转变换实现求距离
            double MirrorX;
            double MirrorY;  
            //定义关于直线对称的点Mirror
            if (distance > 0)
            { 
                double anglemove=90+L.AccessAngle;
                double vector = A.Y-(Math.Tan(Math.PI / 180 * L.AccessAngle) * (A.X - L.Xpoint) + L.Ypoint);
                if (vector>0 && L.AccessAngle > 0)
                {
                    MirrorX = A.X + 2 * distance * Math.Abs(Math.Cos(Math.PI / 180 * anglemove));
                    MirrorY = A.Y - 2 * distance * Math.Sin(Math.PI / 180 * anglemove);
                }
                else if (vector>0 && L.AccessAngle < 0)
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
                } 
                //通过平移旋转坐标变换求出关于直线对称的点
            }
        }

        public static void PointandCircle(Point A, Circle C)
        {
            double PtoCDistance = Math.Sqrt((C.X - A.X) * (C.X - A.X) + (C.Y - A.Y) * (C.Y - A.Y));
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

        public static void LineandLine(Line L1,Line L2)                          //线与线计算
        { 
            double IncludedAngle;
            //两条直线的夹角
            if (L1.AccessAngle >= 0 && L2.AccessAngle>=0||L1.AccessAngle<0&&L1.AccessAngle<0)
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
            double MidX=0;
            double MidY=0;
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
            Point A=new Point(C.X,C.Y);
            PointandLine(A, L);
        }

        public static void CircleandCircle(Circle C1,Circle C2)
        {
            //
            //求两个圆的交点                                          此处应该抽象出函数
            //
            double dis=Math.Sqrt((C1.X - C2.X) * (C1.X - C2.X) + (C1.Y - C2.Y) * (C1.Y - C2.Y));
            //两个圆心之间的距离
             double cos_value = (C1. Radius* C1.Radius - C2.Radius * C2.Radius + dis * dis) / (2 * C1.Radius * dis);    
             //计算两圆心与交点构成三角形的余弦值cos_value
            double sin_eagle = Math.Sqrt(1 - cos_value * cos_value);                                                  
            //对应正弦值sin_value
            double tr_x1 = C1.Radius * cos_value;                                                                                  
            //计算在新的坐标系下的第一个交点横坐标值tr_x1
            double tr_y1 = C1.Radius * sin_eagle;                                                                                   
            //计算在新的坐标系下第一个交点纵坐标值tr_y1
            double tr_x2 = tr_x1;
            double tr_y2 = -C1.Radius * sin_eagle;
            //同理在新的坐标系下的第二个交点横纵坐标
            double x = C2.X - C1.X;
            double y =C2.Y - C1.Y;
            double r = System.Math.Sqrt(x * x + y * y);
            double cos_value2 = x / r;
            double sin_value2 = y / r;
            //计算从现有坐标系变换到原坐标系需要旋转的角度
            double x_1 = tr_x1 * cos_value2 - tr_y1 * sin_value2 + C1.X;
            double y_1 = tr_y1 * cos_value2 + tr_x1 * sin_value2 + C1.Y;
            //第一个交点坐标（x_1,y_1)
            double x_2 = tr_x2 * cos_value2 - tr_y2 * sin_value2 + C1.X;
            double y_2 = tr_y2 * cos_value2 + tr_x2 * sin_value2 + C1.Y;
            // 第二个交点坐标，也就是将现有坐标系下坐标变换为原坐标下的坐标
            //
            //求两个圆的对称轴直线
            //
            Line CirandCirLine = new Line(C1.X, C1.Y, C2.X, C2.Y);
            //过两个圆圆心的对称轴
            if (C1.Radius == C2.Radius)
            {
                Line PoandPoLine = new Line(1/2*(C1.X+C2.X),1/2*(C1.Y+C1.Y),(CirandCirLine.AccessAngle+90));
                //如果两个圆半径相同，两个圆的圆心连线垂直平分线也是他的对称轴
            }
        }          //圆与圆计算
    }
}

