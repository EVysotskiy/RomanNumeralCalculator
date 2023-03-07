using RomanMathLib;

ICalculator calculator = new RomanCalculator();

Console.WriteLine("Enter expression:");
var expression = Console.ReadLine();

if (string.IsNullOrEmpty(expression))
{
    Console.WriteLine("Enter expression");
    return;
}

var result = calculator.Evaluate(expression);
Console.WriteLine(result);