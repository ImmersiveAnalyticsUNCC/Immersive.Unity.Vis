using System.IO;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class DataAdaptor {
    public static List<string> ReadCSVFile(string filename)
    {
        List<string> all_data = new List<string>();
        StreamReader file = new StreamReader(filename);
        string line;
        while ((line = file.ReadLine()) != null)
        {
            string[] line_data = line.Split(',');
            foreach (string data in line_data)
            {
                all_data.Add(data);
            }
        }
        return all_data;
    }

    // TODO: Same as above
    public static JSONNode ReadJSONFile(string filename)
    {
        // This JSONNode is essentially just a Dictionary. Values can be accessed like json["id"]
        JSONNode json = JSON.Parse(File.ReadAllText(filename));
        return json;
    }
}
