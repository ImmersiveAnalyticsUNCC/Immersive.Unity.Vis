using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class scatterplot : MonoBehaviour {
    static float xOffset = 0.4f;
    private List<float> x_axis1 = new List<float>();
    private List<float> y_axis1 = new List<float>();
    private List<string> clusterID1 = new List<string>();
    private List<float> x_axis2 = new List<float>();
    private List<float> y_axis2 = new List<float>();
    private List<string> clusterID2 = new List<string>();

    // Use this for initialization
    void Start () {
        readData("Assets/SP_data.csv", x_axis1, y_axis1, clusterID1);
        makePlot(1, x_axis1, y_axis1, clusterID1);
        readData("Assets/SP2_data.csv", x_axis2, y_axis2, clusterID2);
        makePlot(0, x_axis2, y_axis2, clusterID2);
    }
	// reading and parsing CSV file and adding data to appropriate data structures
    public void readData(string filename, List<float> x_axis, List<float> y_axis, List<string> clusterID)
    {
        List<string> all_data = new List<string>();
        StreamReader file = new StreamReader(filename);
        string line;
        while ((line = file.ReadLine()) != null)
        {
            string[] line_data = line.Split(',');
            x_axis.Add(float.Parse(line_data[0]));
            y_axis.Add(float.Parse(line_data[1]));
            clusterID.Add((line_data[2]));
        }
    }
    // creating Unity built-in primitive(sphere) and using it as a dataPoint in scatter-plot
    public void makePlot(int check, List<float> x_axis, List<float> y_axis, List<string> clusterID)
    {
        float scale = 0.03f;
        for (int i = 0; i < x_axis.Count; i++)
        {
            var dataPt = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            if(check == 1) { dataPt.transform.parent = this.transform; }
            dataPt.transform.localPosition = new Vector3((x_axis[i] / 1.4f) + xOffset, (y_axis[i] / 1.5f - 0.6f) + xOffset, 1f);
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
