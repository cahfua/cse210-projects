using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        var simple = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(simple.GetSummary());
        Console.WriteLine();

        var math = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());
        Console.WriteLine();

        var writing = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
        Console.WriteLine();

        var assignments = new List<Assignment> { math, writing, simple };
        foreach (var a in assignments)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}