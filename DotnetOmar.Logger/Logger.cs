using System.Collections;

namespace DotnetOmar.Logger;

public static class Logger
{
    private const ConsoleColor KeyColor = ConsoleColor.Yellow;
    private const ConsoleColor StringValueColor = ConsoleColor.Green;
    private const ConsoleColor BoolValueColor = ConsoleColor.Blue;
    private const ConsoleColor NumericValueColor = ConsoleColor.Red;
    private const ConsoleColor NullValueColor = ConsoleColor.DarkGray;


    public static void LogDictionary(IDictionary dictionary, int depth = 1)
    {
        if (depth == 1)
        {
            Console.WriteLine("{");
        }

        var indent = new string(' ', depth * 2);

        foreach (var key in dictionary.Keys)
        {
            var value = dictionary[key];

            Console.ForegroundColor = KeyColor;
            Console.Write($"{indent}{key}: ");
            Console.ResetColor();

            if (value is IDictionary subDictionary)
            {
                Console.WriteLine();
                LogDictionary(subDictionary, depth + 1);
            }
            else if (value is not string && value is IEnumerable array)
            {
                Console.WriteLine();
                LogArray(array, depth + 1);
            }
            else
            {
                LogValue(value);
            }
        }

        if (depth == 1)
        {
            Console.WriteLine("}");
        }
    }

    public static void LogArray(IEnumerable array, int depth)
    {
        var indent = new string(' ', depth * 2);


        foreach (var item in array)
        {
            Console.ForegroundColor = KeyColor;
            Console.Write($"{indent}- ");
            Console.ResetColor();

            switch (item)
            {
                case IDictionary subDict:
                    Console.WriteLine();
                    LogDictionary(subDict, depth + 1);
                    break;
                case IEnumerable subArray:
                    Console.WriteLine();
                    LogArray(subArray, depth + 1);
                    break;
                default:
                    LogValue(item);
                    break;
            }
        }
    }

    public static void LogValue(object? value)
    {
        switch (value)
        {
            case null:
                Console.ForegroundColor = NullValueColor;
                Console.WriteLine("null");
                break;
            case string str:
                Console.ForegroundColor = StringValueColor;
                Console.WriteLine($"\"{str}\"");
                break;
            case bool b:
                Console.ForegroundColor = BoolValueColor;
                Console.WriteLine(b);
                break;
            case int or long or double or float or decimal:
                Console.ForegroundColor = NumericValueColor;
                Console.WriteLine(value);
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(value);
                break;
        }

        Console.ResetColor();
    }
}