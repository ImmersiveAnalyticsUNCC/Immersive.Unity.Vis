using System.Collections.Generic;
using UnityEngine;


public class CircularHeatmapScript : MonoBehaviour {

    private List<string> rawData = new List<string>();
    private List<float> energyData = new List<float>();
    private double max;
    private double min;

    // Use this for initialization
    void Awake () {
        // Read the data from the file using our "generic" adaptor
        rawData = DataAdaptor.ReadCSVFile("Assets/circular_heatchart_data.csv");
        // Parse the data from strings to floats
        foreach (string data in rawData)
        {
            energyData.Add(float.Parse(data));
        }

        max = 0;
        min = energyData[0];

        // Find the max and min of our array
        for(int i = 0; i < energyData.Count; i++)
        {
            if(energyData[i] > max)
            {
                max = energyData[i];
            }
            if(energyData[i] < min)
            {
                min = energyData[i];
            }
        }
        // Create a segment for each data point
        for (int i = 0; i < energyData.Count; i++)
        {
            int ringNumber = i / 12;

            Mesh segmentWedge = CustomMeshGenerator.Create3DToroidWedge(40, ringNumber + 1, ringNumber + 2, 30, 1);
            GameObject newSegment = new GameObject("Chart Segment" + (i+1));
            newSegment.AddComponent<MeshCollider>().sharedMesh = segmentWedge;
            newSegment.AddComponent<MeshFilter>().mesh = segmentWedge;
            newSegment.AddComponent<MeshRenderer>().material.color = PointToColor(energyData[i]);
            // localRotation cannot be a vector3, have to use Quaternion
            newSegment.transform.localRotation = Quaternion.Euler(0, 0, -30 * (i % 12));
        }
        // Move the camera so we can see the whole chart
        transform.position = new Vector3(0f, 0f, -0.21f * energyData.Count);
    }

    // Using black to blue color scale
    private Color PointToColor(double value)
    {
        float blueValue = (float) ((value) * ((max - min)) + min);
        Color color = new Color(0f, 0f, blueValue);
        return color;
    }
}
