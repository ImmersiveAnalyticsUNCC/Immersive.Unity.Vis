using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class scatterplot : MonoBehaviour
{
    // Variables to store data, xy locations and cluster IDs
    private List<float> x_axis = new List<float>();
    private List<float> y_axis = new List<float>();
    private List<string> clusterID = new List<string>();

    // Use this for initialization
    void Start () {
        readData("Assets/Data/SP_data.csv");
        makePlot();
    }
	// reading and parsing CSV file and adding data to appropriate data structures
    public void readData(string filename)
    {
        string[] reader = System.IO.File.ReadAllLines(filename);
        for (int i = 0; i < reader.Length; i++)
        {
            string[] line = reader[i].Split(',');
            x_axis.Add(float.Parse(line[0]));
            y_axis.Add(float.Parse(line[1]));
            clusterID.Add(line[2]);
        }

    }
    // creating Unity built-in primitive(sphere) and using it as a dataPoint in scatter-plot
    public void makePlot()
    {
        float scale = 0.03f;
        for (int i = 0; i < x_axis.Count; i++)
        {
            var dataPt = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //dataPt.transform.parent = this.transform;
            dataPt.transform.localPosition = new Vector3(x_axis[i], y_axis[i], 1f);
            dataPt.transform.localRotation = Quaternion.identity;
            dataPt.transform.localScale = new Vector3(scale, scale, scale);
            Material newMaterial = new Material(Shader.Find("VertexLit"));
            newMaterial.color = findColor(clusterID[i]);
            dataPt.GetComponent<Renderer>().material = newMaterial;
            dataPt.gameObject.SetActive(true);
        }
    }

    public static Color findColor(string color)
    {
        Color outt = Color.white;
        switch (color)
        {
            case "1":
                outt = Color.green;
                break;
            case "2":
                outt = Color.blue;
                break;
            case "3":
                outt = Color.red;
                break;
            case "4":
                outt = Color.yellow;
                break;
            case "5":
                outt = Color.cyan;
                break;
            case "6":
                outt = Color.magenta;
                break;
            case "7":
                outt = Color.gray;
                break;
        }
        return outt;
    }

    // Update is called once per frame
    void Update() { }
}
