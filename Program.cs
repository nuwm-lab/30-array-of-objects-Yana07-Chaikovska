using System;

class Quadrilateral
{
    public (double X, double Y) A { get; private set; }
    public (double X, double Y) B { get; private set; }
    public (double X, double Y) C { get; private set; }
    public (double X, double Y) D { get; private set; }

    public Quadrilateral((double X, double Y) a,
                         (double X, double Y) b,
                         (double X, double Y) c,
                         (double X, double Y) d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }

    private double Distance((double X, double Y) p1, (double X, double Y) p2)
    {
        return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
    }

    public double GetPerimeter()
    {
        return Distance(A, B) +
               Distance(B, C) +
               Distance(C, D) +
               Distance(D, A);
    }

    public override string ToString()
    {
        return $"A({A.X}, {A.Y}), B({B.X}, {B.Y}), C({C.X}, {C.Y}), D({D.X}, {D.Y})";
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введіть кількість чотирикутників n: ");
        int n = int.Parse(Console.ReadLine());

        Quadrilateral[] quadrilaterals = new Quadrilateral[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nВведіть координати для чотирикутника №{i + 1}");

            var a = ReadPoint("A");
            var b = ReadPoint("B");
            var c = ReadPoint("C");
            var d = ReadPoint("D");

            quadrilaterals[i] = new Quadrilateral(a, b, c, d);
        }

        double maxPerimeter = quadrilaterals[0].GetPerimeter();
        int maxIndex = 0;

        for (int i = 1; i < n; i++)
        {
            double perimeter = quadrilaterals[i].GetPerimeter();
            if (perimeter > maxPerimeter)
            {
                maxPerimeter = perimeter;
                maxIndex = i;
            }
        }

        Console.WriteLine("\nЧотирикутник з найбільшим периметром:");
        Console.WriteLine(quadrilaterals[maxIndex]);
        Console.WriteLine($"Периметр = {maxPerimeter:F2}");
    }

    static (double X, double Y) ReadPoint(string name)
    {
        Console.Write($"  {name}.X = ");
        double x = double.Parse(Console.ReadLine());

        Console.Write($"  {name}.Y = ");
        double y = double.Parse(Console.ReadLine());

        return (x, y);
    }
}
