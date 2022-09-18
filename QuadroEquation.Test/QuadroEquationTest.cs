namespace QuadroEquation.Test;

[TestClass]
public class QuadroEquationTest1
{
    [TestMethod]
    public void Test3_SolveNone()
    {
         // x^2+1 = 0 корней нет (возвращается пустой массив)
        var expected = new double[] {};
        var fact = QuadraticEquation.Solve(1.0, 0, 1.0);
        Assert.IsTrue(fact.Length == 0, "нет корней");
    }

    [TestMethod]
    public void Test5_SolveTwo()
    {
        //x^2-1 = 0 есть два корня кратности 1 (x1=1, x2=-1)
        var expected = new double[] {1.0, -1.0};
        var fact = QuadraticEquation.Solve(1.0, 0, -1.0);
        Assert.IsTrue(fact.Length == 2, "должно быть два корня");
        Assert.IsTrue(fact.Contains(expected[0]), "х1  != 1");
        Assert.IsTrue(fact.Contains(expected[1]), "x2 != -1");
    }

    [TestMethod]
    public void Test7_SolveOne()
    {
        //x^2+2x+1 = 0 есть один корень кратности 2 (x1= x2 = -1).
        var expected = new double[] {-1.0};
        var fact = QuadraticEquation.Solve(1.0, 2.0, 1.0);
        Assert.IsTrue(fact.Length == 1, $"должен быть один корень: fact.Length = {fact.Length}");
        Assert.IsTrue(fact.Contains(expected[0]), "х1  != -1");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test9_SolveZeroArg()
    {
        //a=0
        var fact = QuadraticEquation.Solve(0, 2.0, 1.0);
        Assert.Fail("a == 0");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test9_SolveZeroArg1()
    {
        //a=0
        const double a = double.Epsilon;
        var fact = QuadraticEquation.Solve(a, 2.0, 1.0);
        Assert.Fail($"a = {a:r} == 0");
    }


    [TestMethod]
    public void Test11_Solve()
    {
        //дискриминант был отличный от нуля, но меньше заданного эпсилон. Эти коэффициенты должны заменить коэффициенты в тесте из п. 7
        //x^2+2x+1 = 0 есть один корень кратности 2 (x1= x2 = -1).
        var expected = new double[] {-1.0};
        var fact = QuadraticEquation.Solve(0.27, 2e-162, double.Epsilon);
        Assert.IsTrue(fact.Length == 1, $"должен быть один корень: fact.Length = {fact.Length}");
    }

    [TestMethod]
    public void Test13_SolveInvalidArgs()
    {
        double a, b, c;
        a = b = c = 1;

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => QuadraticEquation.Solve(double.NaN,b,c));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => QuadraticEquation.Solve(a,double.NaN,c));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => QuadraticEquation.Solve(a,b,double.NaN));

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => QuadraticEquation.Solve(double.NegativeInfinity,b,c));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => QuadraticEquation.Solve(a,double.NegativeInfinity,c));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => QuadraticEquation.Solve(a,b,double.NegativeInfinity));

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => QuadraticEquation.Solve(double.PositiveInfinity,b,c));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => QuadraticEquation.Solve(a,double.PositiveInfinity,c));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => QuadraticEquation.Solve(a,b,double.PositiveInfinity));
    }
}