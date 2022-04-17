// See https://aka.ms/new-console-template for more information

using TextBaseCalculator;
Console.WriteLine("Welcome to Oren's Text Based Calculator!");
Console.WriteLine("Basic rules: the calculator assums that the input is a valid expression, for example 'x = 1 + 3'");
Console.WriteLine("Add as many expressions as you want. when you want to calculate, write 'calc'");

List<string> inputs = new List<string>();

while (true)
{
    Console.Write(">> ");
    string input = Console.ReadLine();

    inputs.Add(input);
    if (input == "calc")
    {
        
        var output = new Calculator().Calculate(inputs);

        foreach (var item in output)
        {
            Console.WriteLine(item.Key + ":" + item.Value);
        }
    }
}

