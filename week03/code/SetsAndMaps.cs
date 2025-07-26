using System.Reflection.PortableExecutable;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        /// Logic Steps:
    /// 1. Create a set to track seen words
    /// 2. Create a list to store the matched pairs
    /// 3. Loop through each word in the original array
    ///       -- ignoring pairs with same leters -like "aa"
    ///       -- create the reverse of the word
    ///       -- check if the reverse word is not in our set to add it in our list
    /// 4. Return the resulting list 
        var seen = new HashSet<string>();
        var result = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1])
                continue;  //stop this if
            char firstLetter = word[0];
            char secondLetter = word[1];
            string reversed = $"{secondLetter}{firstLetter}";
            if (seen.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
            }
            else
                seen.Add(word); // add the first word of possible reverse pair            
        }
        
        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    /// 
    /// Logic steps:
    /// Get what is in index [3] of each record and with the dictionary, count every time we find that unique degree.
    
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE

            string degree = fields[3];
            if (degrees.ContainsKey(degree))
                degrees[degree]++;  // increses by one the time that we have found again the same degree
            else
                degrees[degree] = 1; // it is the first time we see this degree in our dictionary    

        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    
    /// Logic Steps:
    ///    - 1. make the case doesn't matter, and remove spaces
    ///    - 2. Return false inmediatly we learn the two words have different length
    ///    - 3. In a dictionary, store how many times the uniquely letter repeats itself in the first word. The letter is the key, the times is the value
    ///    - 4. Compare each letter in word2 and if it founds the same, subtract one.
    ///    - 5. When finish comparing, check if a letter repeats more times in word2 than in word1, if so, the times for that letter would be less than 0.
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;
        Dictionary<char, int> counter = new Dictionary<char, int>();
        foreach (char l in word1)
        {
            if (counter.ContainsKey(l)) 
                counter[l]++;
            else
                counter[l] = 1;    
        }

        foreach (char l in word2)
        {
            if (!counter.ContainsKey(l)) // if word2 contains a letter that is not in directory, then return false.
                return false;
            if (counter.ContainsKey(l))
                    counter[l]--;
            if (counter[l] < 0) // ensure the frecuency of each individual letter is the same. Did this letter in second word ocurr more times than in the first?
                return false;       
        }
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        
        return [];
    }
}