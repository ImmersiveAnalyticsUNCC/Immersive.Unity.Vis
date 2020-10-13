using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Accord.MachineLearning.Clustering;
using Accord.Math;
using System;
using Accord.Statistics.Analysis;


public class tsnetest : MonoBehaviour
{
  
    public GameObject point;
    
    double[][] obs;
    int[] output;
    
    public void Start()
    {
        readData("Assets/hospital_visits_s.csv");

       
        // We will create a LDA object for the data
    var lda = new LinearDiscriminantAnalysis();

        // Compute the analysis and create a classifier
    var classifier = lda.Learn(obs, output);

        // Now we can project the data into LDA space:
    double[][] projection = lda.Transform(obs);

        //get x and y from projections
        for (int i = 0; i < projection.Length; i++)
        {
            
            float x =(float) projection[i][0];
            for (int j = 0; j < projection[i].Length; j++)
            {
                float y =(float) projection[i][j];
                //create objects at x and y points
                Instantiate(point, new UnityEngine.Vector3(x/5, y/5,0), Quaternion.identity);


            }
        }
    }
    public void readData(string filename)
    {
       
        string[] reader = System.IO.File.ReadAllLines(filename);
        // get the number of nodes; 
        string[] line = reader[0].Split(',');
        output = new int[line.Length];
        obs = new double [reader.Length][];
        for (int i = 0; i < reader.Length; i++)
        {
            
           for(int j =0; j < line.Length; j++) {
                //output for every column
                output[j] = j;
                obs[i] = Array.ConvertAll(reader[i].Split(','), double.Parse);
               
           }
            
        }

    }
    

}