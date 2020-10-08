using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Accord.MachineLearning.Clustering;
using Accord.Math;
using System;



public class tsnetest : MonoBehaviour
{
   // float[,] Observations = new float[3221, 21];
    List<List<float>> array =new List<List<float>>();
    public GameObject point;
    string[][] lines;
    double[][] obs;
    // Accord.Math.Random.Generator.Seed = 0;
    public void Start()
    {
        readData("Assets/hospital_visits.csv");

        // Declare some observations
        double[][] observations = 
        {
            new double[] { -5, -2, -1 },
            new double[] { -5, -5, -6 },
            new double[] {  2,  1,  1 },
            new double[] {  1,  1,  2 },
            new double[] {  1,  2,  2 },
            new double[] {  3,  1,  2 },
            new double[] { 11,  5,  4 },
            new double[] { 15,  5,  6 },
            new double[] { 10,  5,  6 },
        };
       
        // Create a new t-SNE algorithm 
        TSNE tSNE = new TSNE()
        {
        NumberOfOutputs = 3,
        Perplexity = 2.5
        };
        
    // Transform to a reduced dimensionality space
      double[][] output = tSNE.Transform(obs);

    
        for (int i = 0; i < output.Length; i++)
        {
            float x =(float) output[i][0];
            for (int j = 0; j < output[i].Length; j++)
            {
                float y =( float) output[i][j];
               


                //float x = (float)output[i][j];
                Instantiate(point, new UnityEngine.Vector3(x/4, y/4,0), Quaternion.identity);


            }
        }
    }
    public void readData(string filename)
    {
        string[] reader = System.IO.File.ReadAllLines(filename);
        // get the number of nodes; 
        string[] line = reader[0].Split(',');
        
        obs = new double [reader.Length][];
        for (int i = 0; i < reader.Length; i++)
        {
           for(int j =0; j < line.Length; j++) {

                obs[i] = Array.ConvertAll(reader[i].Split(','), double.Parse);
               
           }
            
        }

    }
    

}