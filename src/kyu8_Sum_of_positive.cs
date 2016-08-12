/*
https://www.codewars.com/kata/sum-of-positive

You get an array of numbers, return the sum of all of the positives ones.

Example [1,-4,7,12] => 1 + 7 + 12 = 20
*/

using System;
using System.Linq;
using System.Reflection;

public static class Solution
{
    public static int PositiveSum_01(int[] arr)
    {
        int ret = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > 0)
                ret += arr[i];
        }
        return ret;
    }
    public static int PositiveSum_02(int[] arr)
    {
        return arr.Sum(c => (c < 0 ? 0 : c));
    }

    public static int PositiveSum_03(int[] arr)
    {
        return arr.Where(a => a > 0).Sum();
    }
};

public static class Tests
{
    public static int[] RandomArray(int length)
    {
        int[] result = new int[length];
        Random rnd = new Random();
        for (int i = 0; i < length; ++i)
        {
            result[i] = rnd.Next(-100, 100);
        }
        return result;
    }
    private static int Solution(int[] arr)
    {
        return arr.Where(x => x > 0).Sum();
    }
    private static void Assert(bool val)
    {
        if (!val)
            throw new Exception("Assertion Error");
    }
    public static void Test(MethodInfo method)
    {
        for (int i = 10; i < 100; i++)
        {
            int[] arr = RandomArray(i);
            Assert(Solution(arr) == (int)method.Invoke(null, new object[] { arr }));
        }
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