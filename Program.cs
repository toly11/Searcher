using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Searcher;

internal class Program
{
    public static void Main()
    {
        var path = Utils.getInputAndValidate("in witch folder to search?: ", (v) => Directory.Exists(v), "Invalid path");
        var pathInfo = new DirectoryInfo(path);
        bool includeSubFolders = Utils.ConfirmYN("to include sub folders? (Y/N): ");
        var filesTree = pathInfo.GetFiles("*", includeSubFolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

        var pattern = Utils.getInputAndValidate("now input your regexp pattern", (v) => !String.IsNullOrWhiteSpace(v));

        var results = new List<FileInfo>();
        foreach (var file in filesTree)
            if (Regex.Match(file.Name, pattern, RegexOptions.IgnoreCase).Success)
                results.Add(file);

        Console.WriteLine("Found {0} results", results.Count);
        Thread.Sleep(1200);
        results.ForEach(file =>
        {
            Console.WriteLine(file.FullName);
        });
    }
}
