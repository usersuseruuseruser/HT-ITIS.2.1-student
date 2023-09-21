using Hw2;
using Tests.RunLogic.Attributes;

namespace Tests.CSharp.Homework2;

public class CalculatorTests
{
    [HomeworkTheory(Homeworks.HomeWork2)]
    [InlineData(15, 5, CalculatorOperation.Plus, 20)]
    [InlineData(15, 5, CalculatorOperation.Minus, 10)]
    [InlineData(15, 5, CalculatorOperation.Multiply, 75)]
    [InlineData(15, 5, CalculatorOperation.Divide, 3)]
    public void TestAllOperations(int value1, int value2, CalculatorOperation operation, int expectedValue)
    {
        //act
        var actual = Calculator.Calculate(value1, operation, value2);

        //assert
        Assert.Equal(expectedValue, actual);
    }

    [Homework(Homeworks.HomeWork2)]
    public void TestInvalidOperation()
    {
        //assert
        Assert.Throws<InvalidOperationException>(() => Calculator.Calculate(0, CalculatorOperation.Undefined, 10));
    }

    [Homework(Homeworks.HomeWork2)]
    public void TestDividingNonZeroByZero()
    {
        //act
        var actual = Calculator.Calculate(10, CalculatorOperation.Divide, 0);

        //assert
        Assert.Equal(double.PositiveInfinity, actual);
    }

    [Homework(Homeworks.HomeWork2)]
    public void TestDividingZeroByNonZero()
    {
        //act
        var actual = Calculator.Calculate(0, CalculatorOperation.Divide, 10);

        //assert
        Assert.Equal(0, actual);
    }

    [Homework(Homeworks.HomeWork2)]
    public void TestDividingZeroByZero()
    {
        //act
        var actual = Calculator.Calculate(0, CalculatorOperation.Divide, 0);

        //assert
        Assert.Equal(double.NaN, actual);
    }
}