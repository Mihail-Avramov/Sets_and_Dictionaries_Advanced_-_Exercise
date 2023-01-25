using System;
using System.Collections.Generic;
using System.Linq;

Dictionary<string, int> userSubmissions = new Dictionary<string, int>();
Dictionary<string, int> languageSubmissions = new Dictionary<string, int>();

string input = string.Empty;

while ((input = Console.ReadLine()) != "exam finished")
{
    string[] commandArguments = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
    string currentName = commandArguments[0];
    
    if (commandArguments[1] == "banned")
    {
        if (userSubmissions.ContainsKey(currentName))
        {
            userSubmissions.Remove(currentName);
        }
        continue;
    }

    string currentLanguage = commandArguments[1];
    int currentPoints = int.Parse(commandArguments[2]);

    if (!userSubmissions.ContainsKey(currentName))
    {
        userSubmissions[currentName] = 0;
    }

    if (userSubmissions[currentName] < currentPoints)
    {
        userSubmissions[currentName] = currentPoints;
    }

    if (!languageSubmissions.ContainsKey(currentLanguage))
    {
        languageSubmissions[currentLanguage] = 0;
    }

    languageSubmissions[currentLanguage]++;
}

Console.WriteLine("Results:");

foreach (var (name, points) in userSubmissions.OrderByDescending(u => u.Value).ThenBy(u => u.Key))
{
    Console.WriteLine($"{name} | {points}");
}

Console.WriteLine("Submissions:");

foreach (var (language, count) in languageSubmissions.OrderByDescending(l => l.Value).ThenBy(l => l.Key))
{
    Console.WriteLine($"{language} - {count}");
}