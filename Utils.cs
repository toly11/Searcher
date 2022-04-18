using System;

namespace Searcher;

internal class Utils
{
    public static bool ConfirmYN(string message = "Please input your choice (Y/N): ")
    {
        Console.Write(message);

        var answar = Console.ReadLine()!.ToUpper();
        if (answar == "Y") return true;
        if (answar == "N") return false;

        Console.WriteLine("bad input, please try again...");
        return ConfirmYN(message);
    }

    public static string getInputAndValidate(string message, Func<string, bool> validator, string errorMessage = "bad input, please try again")
    {
        Console.WriteLine(message);
        string input = Console.ReadLine()!;
        if (validator(input))
            return input;
        else
        {
            Console.WriteLine(errorMessage);
            return getInputAndValidate(message, validator, errorMessage);
        }
    }
}
