using System.Collections.Generic;
using UnityEngine;

public class barCharts : MonoBehaviour {

    private int columnCount;
    private int rowCount;
    private float max = 0;
    List<string> Rawdata = new List<string>();
    List<float> data = new List<float>();
    List<Color> colors = new List<Color>() { Color.white, Color.green};             // Add more colors based on rows in data
    string[] columnNames;
    // Use this for initialization
    public GameObject obj;
    public GameObject axis;
    public Transform textprefab;
    void Start () {
        Camera.main.transform.position = new Vector3(4.5f, 6f, -11.5f);
        Rawdata = DataAdaptor.ReadCSVFile("Assets/stacked_data.csv");   // reading csv file
        foreach(string item in Rawdata)
        {
            data.Add(float.Parse(item));                                // converting data from string to float
        }
        columnCount = DataAdaptor.header.Split(',').Length;
        rowCount = data.Count / columnCount;
        findMax();
        makeAxis();
        instantiateBars();
	}
    public void makeAxis()
    {
        GameObject vertAxis = Instantiate(axis) as GameObject;                  // vertical axis
        vertAxis.transform.localScale = new Vector3(0.1f, max + 1, 0.1f);
        vertAxis.transform.position = new Vector3(-0.6f, -0.2f, 0);
        GameObject hortAxis = Instantiate(axis) as GameObject;                  // horizontal axis
        hortAxis.transform.localScale = new Vector3(columnCount+1, 0.1f, 0.1f);
        hortAxis.transform.position = new Vector3(4.9f, -0.2f, 0);
        GameObject[] axes = GameObject.FindGameObjectsWithTag("axis-Color");
        foreach(var item in axes)
        {
            item.GetComponent<Renderer>().material.color = Color.black;
        }
        columnNames = DataAdaptor.header.Split(',');
        int pos = 0;
        foreach (var item in columnNames)
        {                                                                       // creating labels for horizontal axis
            var text = Instantiate(textprefab);
            text.parent = this.transform;
            text.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            text.transform.localPosition = new Vector3(pos-0.2f, -0.3f, 0);
            text.GetComponent<TextMesh>().fontSize = 28;
            text.GetComponent<TextMesh>().text = item;
            pos++;
        }
    }
    public void instantiateBars()
    {
        int colorIndex = 0;
        GameObject[] cubes;
        for (int i = 0; i < data.Count; i++)
        {
            int iter = i % columnCount;
            // obj is a prefab attached to this script in Unity Editor. The prefab is an empty gameobject with cube as its child, this way cube is not anchored at the centre
            GameObject bar = Instantiate(obj) as GameObject;                
            bar.transform.localPosition = new Vector3(iter + 0.1f, 0, 0);
            bar.transform.localScale = new Vector3(0.9f, data[i], 0.1f);
            

        }
        cubes = GameObject.FindGameObjectsWithTag("bar");
        // we have to color the bars based on the row of data it represent
        for (int item = 0; item<cubes.Length; item++)
        {
            
            int index = item % columnCount;
            cubes[item].GetComponent<Renderer>().material.color = colors[colorIndex];
            Shader shader1 = Shader.Find("Transparent/Diffuse");
            cubes[item].GetComponent<Renderer>().material.shader = shader1;
            Color temp = cubes[item].GetComponent<Renderer>().material.color;
            // changing alpha value to make bars transparent
            temp.a = 0.3f;                                                  
            cubes[item].GetComponent<Renderer>().material.color = temp;
            if(index == columnCount - 1) { colorIndex++; }
        }

    }
    public void findMax()
    {
        foreach(var item in data)
        { if(item > max) { max = item; } }
    }
    void Update() { }
}
