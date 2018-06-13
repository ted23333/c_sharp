using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pingmianjihe
{
    class Point       //定义点类
    {
        private double x, y;
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
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public Point()
        {

        }
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return string.Format("{0},{1}",this.x,this.y);
        }
    }
}
