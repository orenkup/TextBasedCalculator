// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
namespace TextBaseCalculator;

public class program
{
    static void Main(string[] args)
    {
        var x = 1;
        var t = ++x ;
        var i = 4 * 2 ;
        x = i++ + 5 ;
        x += i ;
        var j = 6 + i ;
        var y = (5 + 3) * 10;
        Console.WriteLine($"x={x}, t={t}, i={i}, j={j}, y={y}");



        List<string> inputs = new List<string>();
        inputs.Add("x = 1");
        inputs.Add("t = ++x");
        inputs.Add("i = 4 * 2");
        inputs.Add("x = i++ + 5");
        inputs.Add("x += i");
        inputs.Add("j = 6 + i");
        inputs.Add("y = (5 + 3) * 10");

       var output= new Calculator().Calculate(inputs);

        foreach (var item in output)
        {
            Console.WriteLine(item.Key + ":" + item.Value);
        }

    }
    
}
