using System;

class Point
{
    public double X { get; private set; }
    public double Y { get; private set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double Distance(Point other)
    {
        return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

class Quadrilateral
{
    public Point A { get; private set; }
    public Point B { get; private set; }
    public Point C { get; private set; }
    public Point D { get; private set; }

    public Quadrilateral(Point a, Point b, Point c, Point d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }

    public double Perimeter =>
        A.Distance(B) +
        B.Distance(C) +
        C.Distance(D) +
        D.Distance(A);

    public override string ToString()
    {
        return $"A={A}, B={B}, C={C}, D={D}, Perimeter={Perimeter:F3}";
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введіть кількість чотирикутників n: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Помилка: потрібно додатнє ціле число.");
            return;
        }

        Quadrilateral[] items = new Quadrilateral[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nВведіть координати для чотирикутника №{i + 1}:");

            Point a = ReadPoint("A");
            Point b = ReadPoint("B");
            Point c = ReadPoint("C");
            Point d = ReadPoint("D");

            items[i] = new Quadrilateral(a, b, c, d);
        }

        // Пошук максимального периметра
        int maxIndex = 0;
        double maxP = items[0].Perimeter;

        for (int i = 1; i < n; i++)
        {
            if (items[i].Perimeter > maxP)
            {
                maxP = items[i].Perimeter;
                maxIndex = i;
            }
        }

        Console.WriteLine("\nЧотирикутник з найбільшим периметром:");
        Console.WriteLine(items[maxIndex]);
    }

    static Point ReadPoint(string name)
    {
        double x = ReadDouble($"  {name}.X = ");
        double y = ReadDouble($"  {name}.Y = ");
        return new Point(x, y);
    }

    static double ReadDouble(string label)
    {
        while (true)
        {
            Console.Write(label);
            if (double.TryParse(Console.ReadLine(), out double value))
                return value;

            Console.WriteLine("  Помилка: введіть число!");
        }
    }
}
