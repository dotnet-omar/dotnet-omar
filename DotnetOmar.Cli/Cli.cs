namespace DotnetOmar.Cli;

public static class Cli
{
    public static string Prompt(string label, bool required = false, string[]? options = null)
    {
        var inputValue = "";
        var isValidValue = true;
        var isValidOptions = true;

        do
        {
            if (!isValidValue)
            {
                LogError($" {label} is required ");
            }
            else if (options != null && !isValidOptions)
            {
                LogError($"The value you have entered is invalid. ({inputValue})");
                Console.WriteLine("Please enter one of the following values");
                Console.WriteLine(string.Join(", ", options));
            }

            Console.Write("Please enter the {0}: ", label);
            Console.ForegroundColor = ConsoleColor.Green;
            inputValue = Console.ReadLine() ?? "";
            Console.ResetColor();
            inputValue = inputValue.Trim();

            isValidValue = !required || !string.IsNullOrWhiteSpace(inputValue);
            isValidOptions = options == null || options.Contains(inputValue);
        } while (!isValidValue || !isValidOptions);

        return inputValue;
    }

    public static void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write(message);
        Console.ResetColor();
        Console.WriteLine();
    }
}