using System;
using System.Collections.Generic;
using System.Linq;

string input = String.Empty;

Dictionary<string,string> contests = new Dictionary<string,string>();

SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();


while ((input = Console.ReadLine()) != "end of contests")
{
    string[] inputArguments = input.Split(":");
    string contestName = inputArguments[0];
    string contestPassword = inputArguments[1];
    
    contests[contestName]= contestPassword;
}

input = String.Empty;

while ((input = Console.ReadLine()) != "end of submissions")
{
    string[] inputArguments = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);

    string contestName = inputArguments[0];
    string contestPassword = inputArguments[1];
    string username = inputArguments[2];
    int points = int.Parse(inputArguments[3]);

    if (contests.ContainsKey(contestName) && contests[contestName] == contestPassword)
    {
        if (!users.ContainsKey(username))
        {
            users[username] = new Dictionary<string, int>();
        }

        if (!users[username].ContainsKey(contestName))
        {
            users[username][contestName] = points;
        }
        else if (users[username][contestName] < points)
        {
            users[username][contestName] = points;
        }
    }
}

string bestUser = users.MaxBy(u => u.Value.Values.Sum()).Key;
int bestUserPoints = users[bestUser].Values.Sum();
//int bestUserPoints = users.MaxBy(u => u.Value.Values.Sum()).Value.Values.Sum();

Console.WriteLine($"Best candidate is {bestUser} with total {bestUserPoints} points.");
Console.WriteLine("Ranking:");

foreach (var (name, contestsInfo) in users)
{
    Console.WriteLine(name);

    foreach (var (contest, points) in contestsInfo.OrderByDescending(c => c.Value))
    {
        Console.WriteLine($"#  {contest} -> {points}");
    }
}