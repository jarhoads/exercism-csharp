using System;
using System.Collections.Generic;
using System.Linq;

public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary() => new Dictionary<int, string>();

    public static Dictionary<int, string> GetExistingDictionary() => 
        new Dictionary<int, string>()
        {
            [1] = "United States of America",
            [55] = "Brazil",
            [91] = "India"
        };

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName) =>
        new Dictionary<int, string>()
        {
            [countryCode] = countryName
        };


    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string CountryName)
    {
        var updated = new Dictionary<int, string>(existingDictionary);
        updated.Add(countryCode, CountryName);
        return updated;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode) => 
            existingDictionary.ContainsKey(countryCode) ? existingDictionary[countryCode] : String.Empty;
    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        var updated = new Dictionary<int, string>(existingDictionary);
        if (existingDictionary.ContainsKey(countryCode))
        {
            updated[countryCode] = countryName;
        }
        return updated;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        var updated = new Dictionary<int, string>(existingDictionary);
        if (updated.ContainsKey(countryCode))
        {
            updated.Remove(countryCode);
        }
        return updated;
    }
    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode) => existingDictionary.ContainsKey(countryCode);

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        return (existingDictionary.Count < 1) ? String.Empty : 
                                                existingDictionary.Values.Select(name => new { Name = name, Size = name.Length })
                                                                         .MaxBy(name => name.Size)
                                                                         .Name;
    }
}
