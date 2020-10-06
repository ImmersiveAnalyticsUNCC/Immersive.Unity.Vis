using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReader : MonoBehaviour
{
    public string filename = "";
    // Start is called before the first frame update
    void Start()
    {
        readData(filename);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // reading and parsing CSV file and adding data to appropriate data structures
    public void readData(string filename)
    {
        //Here we are loading the csv file from the resources folder at path "filename" as a TextAsset game obj
        TextAsset txt = (TextAsset)Resources.Load(filename, typeof(TextAsset));
        string filecontents = txt.text; //convert textasset to a string
        string[] reader = filecontents.Split('\n');//create array "reader" to hold each line as a string 
        string[] line = filecontents.Split(',');//create array "line" to hold each individual value seperated by a ,

        /*// get the number of nodes; 
        nodenumber = int.Parse(line[0]);

        // get the link information;
        for (int i = 1; i < reader.Length - 1; i++)
        {
            linknumber++;
            line = reader[i].Split(',');//get each value in each line in csv and store in array "line"
            linksdata.Add(int.Parse(line[0])); //adds data from each column from csv
            linksdata.Add(int.Parse(line[1]));//adds data from each column from csv
        }*/
    }
}
