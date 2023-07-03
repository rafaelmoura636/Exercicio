using Newtonsoft.Json;
using Questao2;
using System;
using System.Collections.Generic;
using System.Net.Http;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    static int getTotalScoredGoals(string teamName, int year)
    {
        int totalGoals = 0;
        int pages = 1;
        int totalPages = 0;

        using (HttpClient Client = new HttpClient())
        {
            while (pages != totalPages)
            {
                string url = $"https://jsonmock.hackerrank.com/api/football_matches?page={pages}year={year}&team1={teamName}";
                HttpResponseMessage response = Client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var matchesResponse = JsonConvert.DeserializeObject<ResponsePartidas>(content);
                    totalPages = matchesResponse.TotalPages;
                    var matches = matchesResponse.Data;

                    foreach (var match in matches)
                    {
                        int team1Goals = Convert.ToInt32(match["team1goals"]);

                        totalGoals += team1Goals;
                    }
                    pages++;
                }
            }
        }
        return totalGoals;
    }
}
