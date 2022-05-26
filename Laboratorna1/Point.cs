using System;


namespace Laboratorna1
{
    class Point
    {
        public double x { get; set; }
        public double y { get; set; }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y; 
        }

        public Point()
        {
            this.x = 0;
            this.y = 0;
        }
        public string GetCord()
        {
            
                return $"({x:f2};{y:f2})";         
        }

    }
}
