/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

// My Logic steps:
//    1. Accumulate total points for each player
//    2. Sort the dictionary by total points at the top
//    3. Select the top 10 players and print playerID and accumulated points.

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!; //my note: ! at the end is used to suppress copiler warnings about possible null values when your're sure a value isn't null.
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            //Step 1. Add
            // check if the player in the our new dictionary of players has been seen before and add the corresponding points
            if (players.ContainsKey(playerId))
            {
                players[playerId] += points; // player is in player
            }
            else
            {
                players[playerId] = points; // first time in our dictionary
            }
        }

        // Step 2. Sort
        // Note: p=>p.value -- for each player, sort by its value
        var topPlayers = players.OrderByDescending(p => p.Value).Take(10).ToList(); 

        // Step 3. Print results
         // Print results
        //Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");
               

        //var topPlayers = new string[10];        

    }
    
}