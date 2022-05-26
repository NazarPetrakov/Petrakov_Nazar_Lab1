using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace Laboratorna1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> points = new List<Point>();

            Point A1 = new Point(-3, 1);
            Point B1 = new Point(1, 4);
            Point C1 = new Point(3, 1);

            Point A2 = new Point(3, 0);
            Point B2 = new Point(0, 3);
            Point C2 = new Point(0, 0);

            points.Add(A1);
            points.Add(B1);
            points.Add(C1);

            points.Add(A2);
            points.Add(B2);
            points.Add(C2);
            //////////
            Console.WriteLine("Введення у Json файл");
            File.WriteAllText("input.json", string.Empty);

            for (int i = 0; i < points.Count; i++)
            {
                File.AppendAllText("input.json", JsonConvert.SerializeObject(points[i]));
                Console.WriteLine(JsonConvert.SerializeObject(points[i]));
            }
            /////////
            points.Clear(); 
            JsonTextReader reader = new JsonTextReader(new StreamReader("input.json"));
            reader.SupportMultipleContent = true;
            
            while (true)
            {
                if (!reader.Read())
                {
                    break;
                }

                JsonSerializer serializer = new JsonSerializer();
                Point temp_point = serializer.Deserialize<Point>(reader);
                
                points.Add(temp_point);
               
            }
            Console.WriteLine("Вивiд з Json файлу, (x,y)");
            for (int i = 0; i < points.Count; i++)
            {
                Console.WriteLine("(" + points[i].x + " " + points[i].y + ")");
            }

            ///////////




            Triangle triangle1 = new Triangle(points[0], points[1], points[2]);
            Triangle triangle2 = new Triangle(points[3], points[4], points[5]);

            char result;
            string grad;
            char point;
            Point P = new Point();

            Console.WriteLine("Вивести трикутник 1?(+/-)");
            result = Console.ReadLine()[0];
            if (result != '+')
            {
                System.Environment.Exit(1);
            }
                Console.WriteLine($"Трикутник 1 {triangle1.GetCord()}");
                Console.WriteLine("Периметр = {0:N3}", triangle1.Perimetr());
                Console.WriteLine("Площа = {0:N3}", triangle1.Square());
                Console.WriteLine("Радiус описаного кола = {0:N3}", triangle1.OutR());
                Console.WriteLine("Радiус вписаного кола = {0:N3}", triangle1.InR());
                Console.WriteLine("Тип трикутника: {0}, {1}", triangle1.TypeOfTriangle(), triangle1.TypeOfAngle());
                Console.WriteLine("Довжина медiани з вершини A: {0:N3}", triangle1.Mediana(), triangle1.Mediana());
                Console.WriteLine("Довжина висоти з вершини C: {0:N3}", triangle1.Height());
                Console.WriteLine("Довжина бiсектриси з вершини A: {0:N3}", triangle1.Bisek());
            
            Console.WriteLine("Повернути трикутник трикутник 1?(+/-)");
            result = Console.ReadLine()[0];
            if (result != '+')
            {
                System.Environment.Exit(1);
            }

            Console.Write("Введiть градус: ");
            grad = (Console.ReadLine());
            for (int i = 0; i < grad.Length; i++)
            {
                if (Char.IsDigit(grad[i]) == false)
                {
                    Console.WriteLine("Неправильно введений градус, повторiть ще раз");
                    Console.Read();
                    System.Environment.Exit(1);
                }
            } 
            
            Console.Write("Введiть точку, навколо якої буде здiйснюватись поворот(A, B, C, O(центр описаного кола)): ");
            point = Console.ReadLine()[0];
            switch (point)
            {
                case 'A' :
                    P = A1;
                    break;
                case 'B':
                    P = B1;
                    break;
                case 'C':
                    P = C1;
                    break;
                case 'O':
                    P = triangle1.Center();
                    break;
                default:
                    Console.WriteLine("Неправильно введена точка, повторiть ще раз");
                    Console.Read();
                    System.Environment.Exit(1);
                    break;

            }

            int g1 = Convert.ToInt32(grad);
            Console.WriteLine("Трикутник, пiсля повороту: " + triangle1.Rotate(g1, P).GetCord());

            //////////////////////////////////////
            
            Console.WriteLine("Вивести трикутник 2?(+/-)");

            result = Console.ReadLine()[0];
            if (result != '+')
            {
                System.Environment.Exit(1);
            }

            Console.WriteLine($"Трикутник 2 {triangle2.GetCord()}");
            Console.WriteLine("Периметр = {0:N3}", triangle2.Perimetr());
            Console.WriteLine("Площа = {0:N3}", triangle2.Square());
            Console.WriteLine("Радiус описаного кола = {0:N3}", triangle2.OutR());
            Console.WriteLine("Радiус вписаного кола = {0:N3}", triangle2.InR());
            Console.WriteLine("Тип трикутника: {0}, {1}", triangle2.TypeOfTriangle(), triangle2.TypeOfAngle());
            Console.WriteLine("Довжина медiани з вершини A: {0:N3}", triangle2.Mediana(), triangle2.Mediana());
            Console.WriteLine("Довжина висоти з вершини C: {0:N3}", triangle2.Height());
            Console.WriteLine("Довжина бiсектриси з вершини A: {0:N3}", triangle2.Bisek());

            Console.WriteLine("Повернути трикутник трикутник 2?(+/-)");
            result = Console.ReadLine()[0];
            if (result != '+')
            {
                System.Environment.Exit(1);
            }

            Console.Write("Введiть градус: ");
            grad = (Console.ReadLine());
            for (int i = 0; i < grad.Length; i++)
            {
                if (Char.IsDigit(grad[i]) == false)
                {
                    Console.WriteLine("Неправильно введений градус, повторiть ще раз");
                    Console.Read();
                    System.Environment.Exit(1);
                }
            }

            Console.Write("Введiть точку, навколо якої буде здiйснюватись поворот(A, B, C, O(центр описаного кола)): ");
            point = Console.ReadLine()[0];
            switch (point)
            {
                case 'A':
                    P = A2;
                    break;
                case 'B':
                    P = B2;
                    break;
                case 'C':
                    P = C2;
                    break;
                case 'O':
                    P = triangle2.Center();
                    break;
                default:
                    Console.WriteLine("Неправильно введена точка, повторiть ще раз");
                    Console.Read();
                    System.Environment.Exit(1);
                    break;

            }

            int g2 = Convert.ToInt32(grad);
            Console.WriteLine("Трикутник, пiсля повороту: " + triangle2.Rotate(g2, P).GetCord());

            if (Triangle.Equality(triangle1, triangle2) == true)
            {
                Console.WriteLine("\nТрикутники 1 i 2 рiвнi");
            }
            else
            {
                Console.WriteLine("\nТрикутники 1 i 2 не рiвнi");
            }

            
            Console.Read();
        }
    }
}


