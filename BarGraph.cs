using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BarGraph : MonoBehaviour {

    public string[] data = new string[1];

    private Selection allBars = new Selection();

    private void Awake()
    {
        allBars.SelectAll(transform);
    }

    private void Update()
    {
        if (!data.SequenceEqual(allBars.currentData))
        {
            allBars.BindData(data);
            Debug.Log("Binding data");
        }
    }
}
