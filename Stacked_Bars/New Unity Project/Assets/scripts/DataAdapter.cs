using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class DataAdaptor
{
    public static string header;
    public static List<string> ReadCSVFile(string filename)
    {
        List<string> all_data = new List<string>();
        StreamReader file = new StreamReader(filename);
        string line;
        header = null;
        while ((line = file.ReadLine()) != null)
        {
            if(header == null)
            {
                header = line;
                continue;
            }
            string[] line_data = line.Split(',');
            foreach (string data in line_data)
            {
                all_data.Add(data);
            }
        }
        return all_data;
    }
}
