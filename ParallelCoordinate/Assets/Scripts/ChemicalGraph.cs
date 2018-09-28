using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class StateChemInfo
{
    public float value1;
    public string name1;
    public float value2;
    public string name2;
    public float value3;
    public string name3;
    public float value4;
    public string name4;
    public float value5;
    public string name5;
    public float value6;
    public string name6;
    public float value7;
    public string name7;
    public float value8;
    public string name8;
    public float value9;
    public string name9;
    public float value10;
    public string name10;
}

[System.Serializable]
public class AllStateChemInfo
{
    public StateChemInfo WA;
    public StateChemInfo DE;
    public StateChemInfo DC;
    public StateChemInfo WI;
    public StateChemInfo WV;
    public StateChemInfo FL;
    public StateChemInfo WY;
    public StateChemInfo NH;
    public StateChemInfo NJ;
    public StateChemInfo NM;
    public StateChemInfo TX;
    public StateChemInfo LA;
    public StateChemInfo NC;
    public StateChemInfo ND;
    public StateChemInfo NE;
    public StateChemInfo TN;
    public StateChemInfo NY;
    public StateChemInfo PA;
    public StateChemInfo CT;
    public StateChemInfo RI;
    public StateChemInfo NV;
    public StateChemInfo VA;
    public StateChemInfo CO;
    public StateChemInfo CA;
    public StateChemInfo AL;
    public StateChemInfo AS;
    public StateChemInfo AR;
    public StateChemInfo VT;
    public StateChemInfo IL;
    public StateChemInfo GA;
    public StateChemInfo IN;
    public StateChemInfo IA;
    public StateChemInfo MA;
    public StateChemInfo AZ;
    public StateChemInfo ID;
    public StateChemInfo ME;
    public StateChemInfo MD;
    public StateChemInfo OK;
    public StateChemInfo OH;
    public StateChemInfo UT;
    public StateChemInfo MO;
    public StateChemInfo MN;
    public StateChemInfo MI;
    public StateChemInfo KS;
    public StateChemInfo MT;
    public StateChemInfo MS;
    public StateChemInfo SC;
    public StateChemInfo KY;
    public StateChemInfo OR;
    public StateChemInfo SD;
    public StateChemInfo AK;
    public StateChemInfo HI;
}

public class ChemicalGraph : MonoBehaviour {

    private AllStateChemInfo states;
    private Dictionary<string, StateChemInfo> statesDict = new Dictionary<string, StateChemInfo>();

    // Pie graph values and colors
    private float[] values = new float[10];
    private Color[] wedgeColors = new Color[10];
    private string[] wedgeLabels = new string[10];
    public Image wedgePrefab;
    public Vector3 upperTarget;
    public Vector3 midTarget;
    public Vector3 lowerTarget;
    private Vector3 target;
    public float expandSpeed;
    private string lastState;
    public Text hoverText;
    public Text valueText;
    public string selectedLabel = "";
    public string selectedValue = "";

    //Sibling graphs
    public ChemicalGraph sibling1;
    public ChemicalGraph sibling2;

    public bool generated = false;
    public Text stateTitle;

    public StateLayoutManager layout;

    private void Awake()
    {
        UpdateDict();
    }

    void UpdateDict () {
        // Clear out the dictionary before loading new values
        statesDict = new Dictionary<string, StateChemInfo>();

        string dataAsJson = File.ReadAllText("Assets/Data/StateChemicals" + StateLayoutManager.year + ".json");
        states = JsonUtility.FromJson<AllStateChemInfo>(dataAsJson);

        statesDict.Add("AK", states.AK);
        statesDict.Add("AL", states.AL);
        statesDict.Add("AZ", states.AZ);
        statesDict.Add("AR", states.AR);
        statesDict.Add("CA", states.CA);
        statesDict.Add("CO", states.CO);
        statesDict.Add("CT", states.CT);
        statesDict.Add("DE", states.DE);
        statesDict.Add("FL", states.FL);
        statesDict.Add("GA", states.GA);
        statesDict.Add("HI", states.HI);
        statesDict.Add("ID", states.ID);
        statesDict.Add("IL", states.IL);
        statesDict.Add("IN", states.IN);
        statesDict.Add("IA", states.IA);
        statesDict.Add("KS", states.KS);
        statesDict.Add("KY", states.KY);
        statesDict.Add("LA", states.LA);
        statesDict.Add("ME", states.ME);
        statesDict.Add("MD", states.MD);
        statesDict.Add("MA", states.MA);
        statesDict.Add("MI", states.MI);
        statesDict.Add("MN", states.MN);
        statesDict.Add("MS", states.MS);
        statesDict.Add("MO", states.MO);
        statesDict.Add("MT", states.MT);
        statesDict.Add("NE", states.NE);
        statesDict.Add("NV", states.NV);
        statesDict.Add("NH", states.NH);
        statesDict.Add("NJ", states.NJ);
        statesDict.Add("NM", states.NM);
        statesDict.Add("NY", states.NY);
        statesDict.Add("NC", states.NC);
        statesDict.Add("ND", states.ND);
        statesDict.Add("OH", states.OH);
        statesDict.Add("OK", states.OK);
        statesDict.Add("OR", states.OR);
        statesDict.Add("PA", states.PA);
        statesDict.Add("RI", states.RI);
        statesDict.Add("SC", states.SC);
        statesDict.Add("SD", states.SD);
        statesDict.Add("TN", states.TN);
        statesDict.Add("TX", states.TX);
        statesDict.Add("UT", states.UT);
        statesDict.Add("VT", states.VT);
        statesDict.Add("VA", states.VA);
        statesDict.Add("WA", states.WA);
        statesDict.Add("WV", states.WV);
        statesDict.Add("WI", states.WI);
        statesDict.Add("WY", states.WY);
    }

    public void genGraph(string stateTag) {
        UpdateDict();
        lastState = stateTag;
        StateChemInfo state = statesDict[stateTag];

        values[0] = state.value1;
        values[1] = state.value2;
        values[2] = state.value3;
        values[3] = state.value4;
        values[4] = state.value5;
        values[5] = state.value6;
        values[6] = state.value7;
        values[7] = state.value8;
        values[8] = state.value9;
        values[9] = state.value10;

        wedgeLabels[0] = state.name1;
        wedgeLabels[1] = state.name2;
        wedgeLabels[2] = state.name3;
        wedgeLabels[3] = state.name4;
        wedgeLabels[4] = state.name5;
        wedgeLabels[5] = state.name6;
        wedgeLabels[6] = state.name7;
        wedgeLabels[7] = state.name8;
        wedgeLabels[8] = state.name9;
        wedgeLabels[9] = state.name10;

        wedgeColors[0] = new Color(1, 0, 0, 1);
        wedgeColors[1] = new Color(0.9f, 0.1f, 0, 1);
        wedgeColors[2] = new Color(0.8f, 0.2f, 0, 1);
        wedgeColors[3] = new Color(0.7f, 0.3f, 0, 1);
        wedgeColors[4] = new Color(0.6f, 0.4f, 0, 1);
        wedgeColors[5] = new Color(0.5f, 0.5f, 0, 1);
        wedgeColors[6] = new Color(0.4f, 0.6f, 0, 1);
        wedgeColors[7] = new Color(0.3f, 0.7f, 0, 1);
        wedgeColors[8] = new Color(0.2f, 0.8f, 0, 1);
        wedgeColors[9] = new Color(0.1f, 0.9f, 0, 1);
        stateTitle.text = stateTag;
        MakeGraph();
    }

    void MakeGraph()
    {
        float total = 0f;
        float zRotation = 0f;
        for (int i = 0; i < values.Length; i++)
        {
            total += values[i];
        }

        float angle = 0f;
        float angleInRadians = ((angle * Mathf.PI) / 180);
        float angleCos = Mathf.Cos(angleInRadians);
        float angleSin = Mathf.Sin(angleInRadians);

        for (int i = 0; i < values.Length; i++)
        {
            Image newWedge = Instantiate(wedgePrefab) as Image;
            newWedge.transform.SetParent(transform, false);
            newWedge.GetComponent<Wedge>().label = wedgeLabels[i];
            newWedge.color = wedgeColors[i];
            newWedge.GetComponent<Wedge>().defaultColor = wedgeColors[i];
            newWedge.fillAmount = values[i] / total;

            // Create the collider for the wedge and attach it
            PolygonCollider2D collider = newWedge.GetComponent<PolygonCollider2D>();
            Vector2[] points = new Vector2[6];
            points[0] = new Vector2(0, 0);
            // Since we're using triangles to approximate a parital circle, I'm using 4 triangles per wedge
            for (int angleI = 1; angleI <= 4; angleI ++) {
                // The piegraph doesn't generate the same direction as the unit circle, so we'll convert
                angle = 90 + (-(newWedge.fillAmount * 360f * (0.25f * angleI)));
                if (angle < 0)
                {
                    angle += 360;
                }
                // Cos and Sin take radians as parameters, not degrees
                angleInRadians = ((angle * Mathf.PI) / 180);
                angleCos = Mathf.Cos(angleInRadians);
                angleSin = Mathf.Sin(angleInRadians);

                points[5 - angleI] = new Vector2(47.0f * angleCos, 47.0f * angleSin);
            }
            angleCos = Mathf.Cos(angleInRadians);
            angleSin = Mathf.Sin(angleInRadians);
            points[5] = new Vector2(0, 47);
            collider.SetPath(0, points);
            
            newWedge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));
            zRotation -= newWedge.fillAmount * 360f;

            newWedge.GetComponent<Wedge>().value = values[i];
        }

        target = midTarget;
        generated = true;
        transform.rotation = Quaternion.Euler(new Vector3(0f, -35f, 0f));
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, expandSpeed * Time.deltaTime);
    }

    public void Clear()
    {
        Destroy(transform.Find("Wedge(Clone)").gameObject);
        //while(transform.Find("Wedge(Clone)"))
        foreach(Transform childWedge in transform)
        {
            if (childWedge.name == "Wedge(Clone)")
            {
                Destroy(childWedge.gameObject);
            }
        }
        generated = false;
        transform.position = new Vector3(0, 0, 0);
        target = new Vector3(0, 0, 0);
        stateTitle.text = "";
        hoverText.text = "";
        selectedValue = "";
        valueText.text = "";
    }

    public void ExpandMatchingWedges(string chemical)
    {
        // Only contract if the wedge is not already selected
        if (chemical != selectedLabel)
        {
            foreach (Transform childWedge in sibling1.transform)
            {
                if (childWedge.name == "Wedge(Clone)")
                {
                    string childLabel = childWedge.GetComponent<Wedge>().label;
                    if (chemical.Equals(childLabel))
                    {
                        childWedge.transform.gameObject.GetComponent<Wedge>().Expand();
                    }
                }
            }

            foreach (Transform childWedge in sibling2.transform)
            {
                if (childWedge.name == "Wedge(Clone)")
                {
                    string childLabel = childWedge.GetComponent<Wedge>().label;
                    if (chemical.Equals(childLabel))
                    {
                        childWedge.transform.gameObject.GetComponent<Wedge>().Expand();
                    }
                }
            }
        }
    }

    public void ContractMatchingWedges(string chemical)
    {
        // Only contract if the wedge is not already selected
        if (chemical != selectedLabel)
        {
            foreach (Transform childWedge in sibling1.transform)
            {
                if (childWedge.name == "Wedge(Clone)")
                {
                    string childLabel = childWedge.GetComponent<Wedge>().label;
                    if (chemical.Equals(childLabel))
                    {
                        childWedge.transform.gameObject.GetComponent<Wedge>().Contract();
                        sibling1.selectedValue = "" + childWedge.transform.gameObject.GetComponent<Wedge>().value;
                    }
                }
            }

            foreach (Transform childWedge in sibling2.transform)
            {
                if (childWedge.name == "Wedge(Clone)")
                {
                    string childLabel = childWedge.GetComponent<Wedge>().label;
                    if (chemical.Equals(childLabel))
                    {
                        childWedge.transform.gameObject.GetComponent<Wedge>().Contract();
                        sibling2.selectedValue = "" + childWedge.transform.gameObject.GetComponent<Wedge>().value;
                    }
                }
            }
        }
    }

    public void UpdateHoverText()
    {
        hoverText.text = selectedLabel;
        valueText.text = selectedValue;
        if (sibling1.generated)
        {
            sibling1.hoverText.text = selectedLabel;
            sibling1.valueText.text = sibling1.selectedValue;
        }
        if (sibling2.generated)
        {
            sibling2.hoverText.text = selectedLabel;
            sibling2.valueText.text = sibling2.selectedValue;
        }
    }

    public void RefreshGraph()
    {
        Vector3 currentPos = transform.position;
        Clear();
        genGraph(lastState);
        transform.position = currentPos;
    }
}
