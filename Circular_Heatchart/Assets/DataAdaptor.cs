using System.IO;
using System.Collections.Generic;
using UnityEngine;

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
}
