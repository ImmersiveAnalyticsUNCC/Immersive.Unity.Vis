using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


//This class keeps track of the toggle buttons and updates the list of columns
public class AxisToggles : MonoBehaviour
{
    [HideInInspector] public List<string> columnX;
    [HideInInspector] public List<string> columnY;
    private List<Toggle> checkboxes;
    private Plot toCallPlotMethod;

    

    // Start is called before the first frame update
    void Start()
    {
        columnX = new List<string>();
        columnY = new List<string>();
        checkboxes = GetComponentsInChildren<Toggle>().ToList();
        toCallPlotMethod = GameObject.Find("Visualize").GetComponent<Plot>();

        foreach (Toggle toggle in checkboxes)                                                               //The toggle under Xaxis is saved in columnX list and same for columnY
        {
            if (toggle.transform.parent.name.Contains("X") && toggle.isOn && !columnX.Contains(toggle.GetComponentInChildren<Text>().text))
            {
                columnX.Add(toggle.GetComponentInChildren<Text>().text);
            }
            else if (toggle.transform.parent.name.Contains("Y") && toggle.isOn && !columnY.Contains(toggle.GetComponentInChildren<Text>().text))
            {
                columnY.Add(toggle.GetComponentInChildren<Text>().text);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnToggleValueChanged(bool newValue)                                 //This method is called when the toggle value changes and the list is refreshed
    {
        columnX.Clear();
        columnY.Clear();
        foreach (Toggle toggle in checkboxes)
        {
            
            if (toggle.transform.parent.name.Contains("X") && toggle.isOn)
            {
                columnX.Add(toggle.GetComponentInChildren<Text>().text);
            }
            else if (toggle.transform.parent.name.Contains("Y") && toggle.isOn)
            {
                columnY.Add(toggle.GetComponentInChildren<Text>().text);
            }
        }
        toCallPlotMethod.DestroyChildren();
        toCallPlotMethod.PlotPoints();
    }

    public void AddColumns()
    {
        
    }
}
