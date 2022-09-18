Console.WriteLine($"{double.IsNegative(-1*double.Epsilon/2)}, {-1*double.Epsilon/2}");
Console.WriteLine($"{double.IsNegative(double.Epsilon/2)}, {double.Epsilon/2}\n");

var fact = QuadraticEquation.Solve(0.27, 2e-162, double.Epsilon);
Console.WriteLine($"{fact[0]}");
