using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is responsible for parsing the csv file
 */
public class Parser
{
    public static Dictionary<string, List<float>> data;

    public static void Parse()
    {
        data = new Dictionary<string, List<float>>();
        List<string> lines = new List<string>();
        TextAsset csv = Resources.Load("Admission_Predict") as TextAsset;                       //Loading the csv file from the Resources folder
        lines = TextAssetToList(csv);                                                           //This method splits the TextAsset into lines based on the delimiter \n
        List<string> header = new List<string>();

        

        bool firstPass = true;
        foreach(string line in lines)                                                           
        {
            if (!firstPass && line.Length != 0)
            {
                List<string> keys = new List<string>(data.Keys);
                var values = line.Split(',');                                                   //Split each line based on the delimiter ','
                List<float> temp;
                int i = 0;
                foreach (string key in keys)
                {
                    temp = data[key];
                    temp.Add(float.Parse(values[i]));
                   // data.Remove(key);
                    data[key] = temp;
                    i++;
                }
                //gre.Add(float.Parse(values[1]));
                //toefl.Add(float.Parse(values[2]));
                //sop.Add(float.Parse(values[4]));
                //lor.Add(float.Parse(values[5]));

            }
            else
            {
                var values = line.Split(',');
                for(int i = 0; i < values.Length; i++)
                {
                    data.Add(values[i], new List<float>());
                    header.Add(values[i]);
                }
                
                firstPass = false;                                                             //The first line contains headers of the csv file
            }
                
        }


    }

    private static List<string> TextAssetToList(TextAsset csv)
    {
        return new List<string>(csv.text.Split("\r\n"[0]));
    }

  }
