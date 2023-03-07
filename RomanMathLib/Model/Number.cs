using System;
using RomanMathLib.Exceptions;
using RomanMathLib.Extension;
using RomanMathLib.Operations.Abstractions;

namespace RomanMathLib.Model;

public struct Number : IEquatable<Number>,IOperation
{
    private const long MAX_VALUE = 3999;
    private const long MIN_VALUE = -3999;
    private long _value;

    public Number()
    {
        _value = 0;
    }
    
    public Number(long value)
    {
        _value = value;

        if (IsValid() is false)
        {
            var maxValue = MAX_VALUE.ToRoman();
            var minValue = MIN_VALUE.ToRoman();
            throw new UnsupportedNumberException($"Unsupported value. Max value:{maxValue} Min value:{minValue}");
        }
    }
    
    public static bool operator <(Number a, Number b) => a._value < b._value;
    public static bool operator <=(Number a, Number b) => a._value <= b._value;
    public static bool operator >(Number a, Number b) => a._value > b._value;
    public static bool operator >=(Number a, Number b) => a._value >= b._value;

    public static bool operator ==(Number a, Number b) => a._value == b._value;
    public static bool operator !=(Number a, Number b) => a._value != b._value;


    public static Number operator +(Number t1, Number t2) => new Number(t1._value + t2._value);
    public static Number operator -(Number t1, Number t2) => new Number(t1._value - t2._value);
    public static Number operator -(Number t1) => new Number(-t1._value);

    public static Number operator *(Number t1, Number t2) => new Number(t1._value * t2._value);

    public static Number Parse(string numberStr)
    {
        var number = numberStr.ConvertToNumber();
        return number;
    }

    public override string ToString()
    {
       return _value.ToRoman();
    }

    public static bool IsDigit(char num)
    {
        return num.IsRomanNum();
    }
    
    public bool Equals(Number other)
    {
        return _value == other._value;
    }

    public override bool Equals(object? obj)
    {
        return obj is Number other && Equals(other);
    }

    public override int GetHashCode()
    {
        return -1966227333 + _value.GetHashCode();
    }

    public Number Execute()
    {
        return new Number(_value);
    }

    private bool IsValid()
    {
        return _value is <= MAX_VALUE and >= MIN_VALUE;
    }
}