using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 * This script is resposible for plotting the datapoints on the game view.
 * It uses the sphere prefab and calculates its position and assign color to show a gradient view.
 * In the Start method the script calls the Parse() to get the data from the csv file.
 * With the help of those values plot the datapoints.
 */

public class Plot : MonoBehaviour
{
    public GameObject prefab;                                   //The data point that acts as the points of the dataset
    public GameObject PointHolder;                              //An empty GameObject which will hold all the scatter points in the game view

    private float scale = 10f;      
    
    private AxisToggles toggles;

    //public string[] columnX = { "GRE Score", "TOEFL Score", "SOP", "LOR " };
    //public string[] columnY = { "GRE Score", "TOEFL Score", "SOP", "LOR " };


    // Start is called before the first frame update
    void Start()
    {
        toggles = GameObject.Find("Canvas").GetComponent<AxisToggles>();    //Get all the toggle buttons from the Canvas
        Parser.Parse();                                                     //Calling Parse method in Parser script to get the data from the csv file
        PlotPoints();                                                       //This method creates the 4x4 matrix
        
}



    public void PlotPoints()
    {

        List<float> x = null, y = null;

        for (int i = 0; i < toggles.columnX.Count; i++)                         //Loops responsible for creating the matrix based on the values in columnX and columnY
        {
            x = Parser.data[toggles.columnX[i]];
                for (int j = 0; j < toggles.columnY.Count; j++)         
                {
                    y = Parser.data[toggles.columnY[j]];
                    PlotDataPoints(x, y, i*2, j*2, toggles.columnX[i], toggles.columnY[j]); 
                }
            }
         


    }

    //This method is responsible for plotting the datapoints
    private void PlotDataPoints(List<float> xC, List<float> yC, int xOffset, int yOffset, string xTitle, string yTitle)
    {
        float xMin = FindMinValue(xC);
        float yMin = FindMinValue(yC);

        float xMax = FindMaxValue(xC);
        float yMax = FindMaxValue(yC);
        for (var i = 0;xC != null && i < xC.Count; i++)
        {
            float x = (Convert.ToSingle(xC[i]) - xMin) / (xMax - xMin);                                 //Normalize the x values
            float y = (Convert.ToSingle(yC[i]) - yMin) / (yMax - yMin);                                 //Normalize the y values
            string nameX = "X" + (xOffset / 2 + 1);
            string nameY = "Y" + (yOffset / 2 + 1);
            GameObject.Find(nameX).GetComponent<TextMeshProUGUI>().enabled = true;                  
            GameObject.Find(nameX).GetComponent<TextMeshProUGUI>().text = xTitle;                       //To write the name of the attributes
                
            GameObject.Find(nameY).GetComponent<TextMeshProUGUI>().enabled = true;
            GameObject.Find(nameY).GetComponent<TextMeshProUGUI>().text = yTitle;

         //   GameObject line = Instantiate(linePrefab, new Vector3(), Quaternion.identity);

            GameObject dataPoint = Instantiate(prefab, new Vector3(x + xOffset, y + yOffset, 0f)*scale, Quaternion.identity);           //Create the prefab dynamically with position as x,y,z 
            dataPoint.transform.parent = PointHolder.transform;                                                                         //Assign the parent of the datapoints as PointHolder
            dataPoint.GetComponent<Renderer>().material.color =  new Color(x, y, (0), 1);                                               //Set the color for each datapoint
        }
        
    }

    private float FindMaxValue(List<float> x)                                                           //Method responsible to find Max value in a given list
    {
        float maxValue = Convert.ToSingle(x[0]);
        for (var i = 0; i < x.Count; i++)
        {
            if (maxValue < Convert.ToSingle(x[i]))
                maxValue = Convert.ToSingle(x[i]);
        }
        return maxValue;
    }

    private float FindMinValue(List<float> x)                                                            //Method responsible to find Min value in a given list
    {
        float minValue = Convert.ToSingle(x[0]);
        for (var i = 0; i < x.Count; i++)
        {
            if (Convert.ToSingle(x[i]) < minValue)
                minValue = Convert.ToSingle(x[i]);
        }
        return minValue;
    }

    //This method is responsible for destroying all the points previously plotted and disabling the text attributes
    public void DestroyChildren()
    {
        Transform parent = GameObject.Find("ParentPoints").transform;
       // int children = parent.childCount;
        if(parent.childCount > 0)
            while (parent.childCount > 0)
            {
                Transform child = parent.GetChild(0);
                child.transform.parent = null;
                Destroy(child.gameObject);
            }

        for(int i = 1; i < 8; i++)
        {
            string nameX = "X" + i;
            string nameY = "Y" + i;
            GameObject.Find(nameX).GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find(nameY).GetComponent<TextMeshProUGUI>().enabled = false;
        }
    }
    
}
