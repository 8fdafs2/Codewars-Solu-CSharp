/*
https://www.codewars.com/kata/highest-and-lowest

In this little assignment you are given a string of 
space separated numbers, 
and have to return the highest and lowest number.

Example:

Kata.HighAndLow("1 2 3 4 5"); // return "5 1"
Kata.HighAndLow("1 2 -3 4 5"); // return "5 -3"
Kata.HighAndLow("1 9 3 4 -5"); // return "9 -5"
Notes:

All numbers are valid Int32, no need to validate them.
There will always be at least one number in the input string.
Output string must be two numbers separated by a single space, and highest number is first.
*/

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

public static class Solution
{
    public static string HighAndLow_01(string numbers)
    {
        string[] str_arr = numbers.Split(' ');
        List<int> num_lst = new List<int>();
        foreach (string s in str_arr)
        {
            num_lst.Add(int.Parse(s));
        }
        return string.Format("{0} {1}", num_lst.Max(), num_lst.Min());
    }

    public static string HighAndLow_02(string numbers)
    {
        var parsed = numbers.Split().Select(int.Parse);
        return parsed.Max() + " " + parsed.Min();
    }

    public static string HighAndLow_03(string numbers)
    {
        var StringsArray = numbers.Split(' ');
        var IntArray = StringsArray.Select(x => int.Parse(x)).ToArray();
        return IntArray.Max().ToString() + ' ' + IntArray.Min().ToString();
    }
};

public class Tests
{
    private static void Assert(bool val)
    {
        if (!val)
            throw new Exception("Assertion Error");
    }
    public static void Test(MethodInfo method)
    {
        Random r = new Random();
        List<int> numbers = new List<int>();
        for (int i = r.Next(1, 42); i > 0; i--)
            numbers.Add(r.Next(Int32.MinValue, Int32.MaxValue));
        string Expected = numbers.Max().ToString() + " " + numbers.Min().ToString();
        string Actual = (string)method.Invoke(null, new object[] { String.Join(" ", numbers.Select(n => n.ToString()).ToArray()) });
        Assert(Expected == Actual);
    }
    static void Main()
    {
        Type type = typeof(Solution);
        foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Static))
        {
            var parameters = method.GetParameters();
            var parameterDescriptions = string.Join
                (", ", method.GetParameters()
                             .Select(x => x.ParameterType + " " + x.Name)
                             .ToArray());
            Console.WriteLine("{0} {1} ({2})",
                method.ReturnType,
                method.Name,
                parameterDescriptions);
            Test(method); 
        }
    }
};