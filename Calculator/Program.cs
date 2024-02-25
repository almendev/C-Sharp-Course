﻿Console.WriteLine("Hello!");

Console.WriteLine("Input the first number:");
int number1 = int.Parse(Console.ReadLine());

Console.WriteLine("Input the second number:");
int number2 = int.Parse(Console.ReadLine());

Console.WriteLine("What do you want to do?");
Console.WriteLine("[A]dd numbers");
Console.WriteLine("[S]ubstract numbers");
Console.WriteLine("[M]ultiply numbers");

var choice = Console.ReadLine();

if (EqualsCaseInsensitive(choice, "A"))
{
    var sum = number1 + number2;
    PrintFinalEquation(number1, number2, sum, "+");
}
else if (EqualsCaseInsensitive(choice, "S"))
{
    var difference = number1 - number2;
    PrintFinalEquation(number1, number2, difference, "-");

}
else if (EqualsCaseInsensitive(choice, "M"))
{
    var multiplied = number1 * number2;
    PrintFinalEquation(number1, number2, multiplied, "*");

}
else
{
    Console.WriteLine("Invalid choice!");
}

Console.WriteLine("Press any key to close.");
Console.ReadKey();

void PrintFinalEquation(int number1, int number2, int result, string @operator)
{
    Console.WriteLine($"{number1} {@operator} {number2} = {result}");
}

bool EqualsCaseInsensitive(string left, string right)
{
    return left.ToUpper() == right.ToUpper();
}