using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class nodelink : MonoBehaviour
{
    [SerializeField]
    public GameObject nodecollection;
    public GameObject linkcollection;
    public GameObject textPrefab;
    public GameObject textcollection;

    public int nodenumber = 0;
    public int linknumber = 0;
    List<int> linksdata = new List<int>();
    float nodescale = 0.5f;
    float noderange = 4.0f;
    public GameObject[] nodes;
    public GameObject[] links;
    private Color[] colors;

    void Awake()
    {
        colors = new Color[15];
        colors[0] = new Color(0.5f, 0.5f, 0, 1); // blue
        colors[1] = new Color(1, 0, 1, 1); // green
        colors[2] = new Color(1, 1, 0, 1); // red
        colors[3] = new Color(0.5f, 1, 0.5f, 1); // purple
        colors[4] = new Color(0.25f, 0, 0.5f, 1); // yellow
        colors[5] = new Color(1, 0.5f, 0.5f, 1); // maroon
        colors[6] = new Color(1, 0.25f, 0, 1); // aqua
        colors[7] = new Color(0, 0.5f, 1, 1); // pink
        colors[8] = new Color(1, 1, 0.25f, 1); // teal
        colors[9] = new Color(.75f, .25f, 1, 1); // gold
        colors[10] = new Color(0.5f, .25f, 0.5f, 1); // baby pink
        colors[10] = new Color(0.5f, .25f, 0.5f, 1); // baby pink
        colors[11] = new Color(0, 0.25f, 0, 1); // dark blue
        colors[12] = new Color(0.5f, 0, 0.5f, 1); // orange
        colors[13] = new Color(0, 0, 0.5f, 1); // silver
        colors[14] = new Color(1f, 1f, 1f, 1); // white
    }

    void Start()
    {
       // TextAsset txt = (TextAsset)Resources.Load("Assets/Data/graph1.csv");
        readData("Data/graph1");
       Generate();
    }

    // reading and parsing CSV file and adding data to appropriate data structures
    public void readData(string filename)
    {
        TextAsset txt = (TextAsset)Resources.Load(filename, typeof(TextAsset));
        string filecontents = txt.text;
        string[] reader = filecontents.Split('\n');
        string[] line = filecontents.Split(',');
 
        // get the number of nodes; 
        nodenumber = int.Parse(line[0]);
        
        // get the link information;
       for (int i = 1; i < reader.Length-1; i++)
        {
            linknumber++;
          line = reader[i].Split(',');
           
            linksdata.Add(int.Parse(line[0]));
           linksdata.Add(int.Parse(line[1]));
       }
    }

    public Vector3 GetAvailabllPos()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        float mindis = 10;

        do
        {
            pos.x = Random.Range(-noderange, noderange);
            pos.y = Random.Range(-noderange, noderange);
            pos.z = 0;

            mindis = 10;

            for (int i = 0; i < nodes.Length; i++)
            {
                float curdis = Vector3.Distance(pos, nodes[i].transform.localPosition);
                if (curdis < mindis) mindis = curdis;
            }

        } while (mindis < 1.5f);

        return pos;
    }

    public void Generate()
    {
        // generate nodes;
        int count = 0;
        for (int i = 0; i < nodenumber; i++)
        {
            var gameObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            gameObj.transform.localPosition = GetAvailabllPos();
            gameObj.transform.localRotation = Quaternion.identity;
            gameObj.transform.localScale = new Vector3(nodescale, nodescale, nodescale);
            int index = count % colors.Length;
            Material newMaterial = new Material(Shader.Find("VertexLit"));
            newMaterial.color = colors[index];
            gameObj.GetComponent<Renderer>().material = newMaterial;
            gameObj.gameObject.SetActive(true);
            gameObj.tag = "node";

            count++;
            if (count >= 15) count = 0;
            // set parent;
            gameObj.transform.parent = nodecollection.transform;

            // labels;
            var t = Instantiate(textPrefab, gameObj.transform.localPosition, Quaternion.identity);
            t.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            TextMesh tmesh = t.GetComponentInChildren<TextMesh>();
            tmesh.text = i.ToString();
            tmesh.color = Color.black;
            t.transform.parent = textcollection.transform;

            nodes = GameObject.FindGameObjectsWithTag("node");
        }


        // generate links;
        for (int i = 0; i < linknumber; i++)
        {
            LineRenderer p = new GameObject("Line").AddComponent<LineRenderer>();
            p.SetPosition(0, nodes[linksdata[2 * i]].transform.localPosition);
            p.SetPosition(1, nodes[linksdata[2 * i + 1]].transform.localPosition);

            p.material = new Material(Shader.Find("Sprites/Default"));
            p.startColor = Color.blue;
            p.endColor = new Color(1, 1, 1, 0);

            p.startWidth = 0.05f;
            p.endWidth = 0.2f;
            p.tag = "link";
            p.transform.parent = linkcollection.transform;
        }
        links = GameObject.FindGameObjectsWithTag("link");
    }
}
