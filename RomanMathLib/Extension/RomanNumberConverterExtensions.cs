using RomanMathLib.Model;

namespace RomanMathLib.Extension;

public static class RomanNumberConverterExtensions
{

    private static Dictionary<char, int> _romanNumbersDictionary = new()
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };
    
    internal static Number ConvertToNumber(this string number)
    {
        var convertedNumber = RomanToInt(number);
        var romanNumber = new Number(convertedNumber);
        return romanNumber;
    }

    private static int RomanToInt(string s)
    {
        var sum = 0;
        for (var i = 0; i < s.Length; i++)
        {
            char currentRomanChar = s[i];
            _romanNumbersDictionary.TryGetValue(currentRomanChar, out int num);
            if (i + 1 < s.Length && _romanNumbersDictionary[s[i + 1]] > _romanNumbersDictionary[currentRomanChar])
            {
                sum -= num;
            }
            else
            {
                sum += num;
            }
        }

        return sum;
    }

    public static string ToRoman(this long number)
    {
        var romanNumerals = new List<string>()
            { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        var numerals = new List<int>() { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        var isNegativeNumber = number < 0;

        if (number == 0)
        {
            return $"nulla";
        }
        
        number = Math.Abs(number);
        var romanNumeral = string.Empty;
        while (number > 0)
        {
            var index = numerals.FindIndex(x => x <= number);
            number -= numerals[index];
            romanNumeral += romanNumerals[index];
        }

        romanNumeral = isNegativeNumber ? $"-{romanNumeral}" : romanNumeral;
        return romanNumeral;
    }


    internal static bool IsRomanNum(this char number)
    {
        return _romanNumbersDictionary.TryGetValue(number, out var value);
    }
}