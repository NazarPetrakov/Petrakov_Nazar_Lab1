using System;


namespace Laboratorna1
{
    
    class Triangle
    {

        const double EPS = 0.0001;
        Point A ;
        Point B ;
        Point C ;

        public Triangle(Point A, Point B, Point C)
        {
            this.A = A;
            this.B = B;
            this.C = C;

        }
        public string GetCord()
        { 
            return $"A = {A.GetCord()}, B = {B.GetCord()}, C = {C.GetCord()} ";
        }

        private double SideLength(Point A, Point B)
        {
            double result;

            result = Math.Sqrt(Math.Pow(B.x - A.x,2) + Math.Pow(B.y - A.y, 2));

            return result;
        }
        public double Perimetr()
        {
            double result;

            result = SideLength(A,B) + SideLength(A, C) + SideLength(C, B);

            return result;
        }
        public double Square()
        {
            double result;
            double p = Perimetr() / 2;
            double a = SideLength(A, B);
            double b = SideLength(C, B);
            double c = SideLength(A, C);
            result = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            return result;
        }
        public double OutR()
        {
            double result;
            double a = SideLength(A, B);
            double b = SideLength(C, B);
            double c = SideLength(A, C);
            result = (a * b * c) / (4 * Square());

            return result;
        }
        public double InR()
        {
            double result;
            double a = SideLength(A, B);
            double b = SideLength(C, B);
            double c = SideLength(A, C);
            result = 2 * Square() / Perimetr();

            return result;
        }
        public double AlfaAngle()
        {
            double result;
            double a = SideLength(A, B);
            double b = SideLength(C, B);
            double c = SideLength(A, C);
            result = 180 / Math.PI * (Math.Acos((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c)));

            return result;
        }
        public double BetaAngle()
        {
            double result;
            double a = SideLength(A, B);
            double b = SideLength(C, B);
            double c = SideLength(A, C);
            result = 180 / Math.PI * Math.Acos((Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c));

            return result;
        }
        public double GammaAngle()
        {
            double result;
            
            result = 180 - (AlfaAngle() + BetaAngle());

            return result;
        }
        public string TypeOfTriangle()
        {
            double a = SideLength(A, B);
            double b = SideLength(C, B);
            double c = SideLength(A, C);

            if (a == b && b == c)
            {
                return "рiвностороннiй";
            }

            if (a == b || b == c || a == c)
            {
                return "рiвнобедрений";
            }
            
            return "рiзностороннiй";
            
        }
        public string TypeOfAngle()
        {


            if (Math.Abs((AlfaAngle() - 90)) < EPS || Math.Abs((GammaAngle() - 90)) < EPS || Math.Abs((BetaAngle() - 90)) < EPS )
            {
                return "прямокутний";
            }

            if (AlfaAngle() < 90 && GammaAngle() < 90 && BetaAngle() < 90)
            {
                return "гострокутний";
            }

            return "тупокутний";

        }
        public double Mediana()
        {
            double result;

            double a = SideLength(A, B);
            double b = SideLength(C, B);
            double c = SideLength(A, C);

            result = (Math.Sqrt(2*Math.Pow(a,2) + 2 * Math.Pow(b, 2) - Math.Pow(c, 2)))/2;


            return result;
        }
        public static bool Equality(Triangle t1, Triangle t2)
        {
            double[] tarray1 = { t1.SideLength(t1.A, t1.B), t1.SideLength(t1.A, t1.C), t1.SideLength(t1.B, t1.C) };
            double[] tarray2 = { t2.SideLength(t2.A, t2.B), t2.SideLength(t2.A, t2.C), t2.SideLength(t2.B, t2.C) };
            Array.Sort(tarray1);
            Array.Sort(tarray2);
            if(tarray1[0] == tarray2[0] && tarray1[1] == tarray2[1] && tarray1[2] == tarray2[2])
            {
                return true;
            }
            return false;
        }
        public double Height()
        {
            double result;

            double a = SideLength(A, B);
            double b = SideLength(C, B);
            double c = SideLength(A, C);

            result = (2 * Square()) / a;
         
            
            return result;
        }
        public double Bisek()
        {
            double result;

            double a = SideLength(A, B);
            double b = SideLength(C, B);
            

            result = (2 * a * b * Math.Cos(GammaAngle()*Math.PI/360))/(a + b);


            return result;
        }
        public Triangle Rotate(double angle, Point O)
        {
            double x1, x2, y1, y2, x3, y3;

            x1 = Math.Cos(angle * Math.PI / 180) * (A.x - O.x) - Math.Sin(angle * Math.PI / 180) * (A.y - O.y) + O.x;
            y1 = Math.Sin(angle * Math.PI / 180) * (A.x - O.x) + Math.Cos(angle * Math.PI / 180) * (A.y - O.y) + O.y;

            x2 = Math.Cos(angle * Math.PI / 180) * (B.x - O.x) - Math.Sin(angle * Math.PI / 180) * (B.y - O.y) + O.x;
            y2 = Math.Sin(angle * Math.PI / 180) * (B.x - O.x) + Math.Cos(angle * Math.PI / 180) * (B.y - O.y) + O.y;

            x3 = Math.Cos(angle * Math.PI / 180) * (C.x - O.x) - Math.Sin(angle * Math.PI / 180) * (C.y - O.y) + O.x;
            y3 = Math.Sin(angle * Math.PI / 180) * (C.x - O.x) + Math.Cos(angle * Math.PI / 180) * (C.y - O.y) + O.y;
            
            return new Triangle(new Point(x1, y1), new Point(x2, y2), new Point(x3, y3));
        }
        public Point Center()
        {
            double xO, yO;
           
            xO = (A.x * Math.Sin(AlfaAngle() * Math.PI / 90) + B.x * Math.Sin(BetaAngle() * Math.PI / 90) + C.x * Math.Sin(GammaAngle() * Math.PI / 90)) / (Math.Sin(AlfaAngle() * Math.PI / 90) + Math.Sin(BetaAngle() * Math.PI / 90) + Math.Sin(GammaAngle() * Math.PI / 90));
            yO = (A.y * Math.Sin(AlfaAngle() * Math.PI / 90) + B.y * Math.Sin(BetaAngle() * Math.PI / 90) + C.y * Math.Sin(GammaAngle() * Math.PI / 90)) / (Math.Sin(AlfaAngle() * Math.PI / 90) + Math.Sin(BetaAngle() * Math.PI / 90) + Math.Sin(GammaAngle() * Math.PI / 90));
            
            return new Point(xO,yO);
        }

    }

}
