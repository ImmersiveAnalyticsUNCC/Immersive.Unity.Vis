using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class DataAdaptor {
    public static List<string> ReadCSVFile(string filename)
    {
        List<string> all_data = new List<string>();

        string[] reader = System.IO.File.ReadAllLines(filename);
        for (int i = 0; i < reader.Length; i++)
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
