using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class DataAdaptor
{
    public static string header;
    public static List<string> ReadCSVFile(string filename)
    {
        List<string> all_data = new List<string>();

        string[] reader = System.IO.File.ReadAllLines(filename);
        if (reader == null) return null;

        header = reader[0];

        for (int i = 1; i < reader.Length; i++)
        {
            string[] line = reader[i].Split(',');
            foreach (string data in line)
            {
                all_data.Add(data);
            }
        }

        return all_data;
    }
}
