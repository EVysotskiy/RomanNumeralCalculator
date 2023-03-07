using RomanMathLib;
using RomanMathLib.Exceptions;

namespace TestRomanMathLib;

public class RomanMathLibTest
{
    private ICalculator _calculator;
    
    [SetUp]
    public void Setup()
    {
        _calculator = new RomanCalculator();
    }

    [Test]
    public void Test1()
    {
        var result = _calculator.Evaluate("(MMMDCCXXIV - MMCCXXIX) * II");
        var resultTest = result.Equals("MMCMXC");
        Assert.IsTrue(resultTest,$"(MMMDCCXXIV - MMCCXXIX) * II\nresult:{result}");
    }
    
    [Test]
    public void Test2()
    {
        var result = _calculator.Evaluate("(IV - X) * I");
        var resultTest = result.Equals("-VI");
        Assert.IsTrue(resultTest, $"(IV - X) * I result:{result}");
    }
    
    [Test]
    public void Test3()
    {
        Assert.Throws<UnsupportedNumberException>(() => _calculator.Evaluate("(MMMCMXCIX + MMMCMXCIX) * MMMCMXCIX"));
    }
    
    [Test]
    public void Test4()
    {
        var result = _calculator.Evaluate("IV - IV");
        var resultTest = result.Equals("nulla");
        Assert.IsTrue(resultTest, $"IV - IV result:{result}");
    }
    
    [Test]
    public void Test5()
    {
        var result = _calculator.Evaluate("IV + IV");
        var resultTest = result.Equals("VIII");
        Assert.IsTrue(resultTest, $"IV - IV result:{result}");
    }
    
    [Test]
    public void Test6()
    {
        Assert.Throws<UnsupportedOperationException>(() => _calculator.Evaluate("IV / IV"));
    }
    
    [Test]
    public void Test7()
    {
        var result = _calculator.Evaluate("XIII - XXVIII + (II * III)");
        var resultTest = result.Equals("-IX");
        Assert.IsTrue(resultTest, $"XIII - XXVIII + (II * III) result:{result}");
    }
    
    [Test]
    public void Test8()
    {
        var result = _calculator.Evaluate("-X - I");
        var resultTest = result.Equals("-XI");
        Assert.IsTrue(resultTest, $"-X - I result:{result}");
    }
    
    [Test]
    public void Test9()
    {
        var result = _calculator.Evaluate("X * -I");
        var resultTest = result.Equals("-X");
        Assert.IsTrue(resultTest, $"X * -I result:{result}");
    }
    
    [Test]
    public void Test10()
    {
        var result = _calculator.Evaluate("X * -I - I");
        var resultTest = result.Equals("-XI");
        Assert.IsTrue(resultTest, $"X * -I - I result:{result}");
    }
    
    [Test]
    public void Test11()
    {
        Assert.Throws<UnsupportedOperationException>(() => _calculator.Evaluate("-X^I"));
    }
    
    [Test]
    public void Test12()
    {
        var result = _calculator.Evaluate("-X * -I - I");
        var resultTest = result.Equals("IX");
        Assert.IsTrue(resultTest, $"-X * -I - I result:{result}");
    }
    
    [Test]
    public void Test13()
    {
        var result = _calculator.Evaluate("-X * -I * I");
        var resultTest = result.Equals("X");
        Assert.IsTrue(resultTest, $"-X * -I * I result:{result}");
    }
    
    [Test]
    public void Test14()
    {
        var result = _calculator.Evaluate("-V + (-VIII + VIII) * V - I");
        var resultTest = result.Equals("-VI");
        Assert.IsTrue(resultTest, $"-V + (-VIII + VIII) * V - I result:{result}");
    }
    
    [Test]
    public void Test15()
    {
        Assert.Throws<ExpressionException>(() => _calculator.Evaluate("-V + (-I"));
    }
    
    [Test]
    public void Test16()
    {
        var result = _calculator.Evaluate("-V + -I");
        var resultTest = result.Equals("-VI");
        Assert.IsTrue(resultTest, $"-V + -I result:{result}");
    }
    
    [Test]
    public void Test17()
    {
        var result = _calculator.Evaluate("-V+-I");
        var resultTest = result.Equals("-VI");
        Assert.IsTrue(resultTest, $"-V + -I result:{result}");
    }
}