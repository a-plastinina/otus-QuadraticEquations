public class QuadraticEquation
{
    private static readonly double _accuracy = double.Epsilon;

    static double getDescriminant(double a, double b, double c)
    {
        return b*b - 4*a*c;
    }
    public static double[] Solve(double a, double b, double c)
    {
        doubleVerify(a);
        doubleVerify(b);
        doubleVerify(c);
        
        if (doubleEqualZero(a)) throw new ArgumentOutOfRangeException("a не может быть равен 0");

        var d = getDescriminant(a,b,c);
        
        // d < 0
        if (doubleIsNegative(d)) return new double[] {};

        // d == 0
        if (doubleEqualZero(d)) return new double[] { (-1 * b) / (2 * a) };

        // d > 0
        var x1 = (-1 * b + Math.Sqrt(d)) / (2 * a);
        return new double[] { x1, -1*x1 };
    }

    static void doubleVerify(double value)
    {
        if (double.IsNaN(value)) throw new ArgumentOutOfRangeException("value is NaN");
        if (double.IsInfinity(value)) throw new ArgumentOutOfRangeException("value is infinity");
    }

    static bool doubleEqualZero(double value)
    {
        return Math.Abs(value) <= _accuracy;
    }
    static bool doubleIsNegative(double value)
    {
        return double.IsNegative(value);
    }
}