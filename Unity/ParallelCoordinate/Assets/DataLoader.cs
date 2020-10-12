using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataLoader : MonoBehaviour
{
    public List<float> data_1 = new List<float>();
    public List<float> data_2 = new List<float>();
    public List<float> data_3 = new List<float>();

    public GameObject Axes;
    public GameObject[] Lines;

    // Start is called before the first frame update
    void Start()
    {
        Axes = new GameObject();
        readData("grocery_visits_1");
        makePlot();
    }

    // reading and parsing CSV file and adding data to appropriate data structures
    public void readData(string filename)
    {
        TextAsset file = Resources.Load<TextAsset>(filename);
        string dataStr = file.ToString();
        string[] lines = dataStr.Split('\n');

        for (int j = 0; j < lines.Length; j++)
        {
            string[] items = lines[j].Split(',');
            if (items.Length > 3)
            {
                data_1.Add(float.Parse(items[0]));
                data_2.Add(float.Parse(items[1]));
                data_3.Add(float.Parse(items[2]));
            }
        }

        normalizeData(data_1);
        normalizeData(data_2);
        normalizeData(data_3);

    }

    // use our datasets to generate the parallel coordinates
    public void makePlot()
    {
        // show the axes
        for (int i = 0; i < 3; i++)
        {
            LineRenderer p = new GameObject("Line").AddComponent<LineRenderer>();
            Vector3 startPos = new Vector3(2f * i, 0, 0);
            Vector3 endPos = new Vector3(startPos.x, 1f, 0);
            p.SetPosition(0, startPos);
            p.SetPosition(1, endPos);

            p.material = new Material(Shader.Find("Sprites/Default"));
            p.startColor = Color.blue;
            p.endColor = new Color(1, 1, 1, 0);

            p.startWidth = 0.05f;
            p.endWidth = 0.2f;
            p.tag = "axis";
            p.transform.parent = Axes.transform;
        }
        Lines = GameObject.FindGameObjectsWithTag("axis");

        // show the data line segments
        for (int i = 0; i < data_1.Count; i++)
        {
            LineRenderer p = new GameObject("Line").AddComponent<LineRenderer>();
            Vector3[] positions = new Vector3[3];
            positions[0] = new Vector3(0, data_1[i], 0);
            positions[1] = new Vector3(2, data_2[i], 0);
            positions[2] = new Vector3(4, data_3[i], 0);
            p.positionCount = positions.Length;
            p.SetPositions(positions);

            p.material = new Material(Shader.Find("Sprites/Default"));
            p.startColor = Color.red;
            p.endColor = Color.yellow;

            p.startWidth = 0.01f;
            p.endWidth = 0.01f;
            p.tag = "line";
            p.transform.parent = Axes.transform;

        }
    }

    private void normalizeData(List<float> data)
    {
        float min, max;

        // initialize
        min = data[0];
        max = data[0];

        // find the min and max
        for (int i = 1; i < data.Count; i++)
        {
            if (data[i] < min) min = data[i];
            else if (data[i] > max) max = data[i];
        }

        // normalize the data to [0, 1]
        if (max - min < 0.001) return;
        
        for (int i = 0; i < data.Count; i++)
        {
            data[i] = (data[i] - min) / (max - min);
        }
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
