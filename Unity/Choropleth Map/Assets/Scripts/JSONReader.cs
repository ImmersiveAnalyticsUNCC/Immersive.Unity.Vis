/* Authored by Christian Motley
 * For use in Dr. Aidong Lu's Immersive Vis Repository for her ITCS - 4123/5123 - Visualization and Visual Communication course at UNC Charlotte.
 * Using the Quick Outline asset from the Unity Asset Store with slight modifications - https://assetstore.unity.com/packages/tools/particles-effects/quick-outline-115488
 * Last Modified: October 19th, 2020 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    [Tooltip("Drag your JSON file here.")]
    public TextAsset jsonFile;

    Choropleth choropleth;
    Outline outline;

    void Start()
    {
        States statesInJson = JsonUtility.FromJson<States>(jsonFile.text);

        foreach (State state in statesInJson.states)
        {
            /* Make sure the name of the gameobject in the Hierarchy is exactly the same as the name in the JSON file.
             * If the state's name is "North Carolina" in the JSON file then the gameobject in the hierarchy must also be named North Carolina
             * otherwise there will be an NullReferenceException and all following states will not be read. */
            choropleth = GameObject.Find(state.name).GetComponent<Choropleth>(); //Finds the gameobject with the name that matches the name in the JSON file and gets the Choropleth script.
            choropleth.dataValue = state.number; // Changes the Chroropleth script that is attatched to the state's dataValue variable to the number from the JSON file.
            //Debug.Log("Found state: " + state.name + "\n\t  With data value: " + state.number);
        }
    }
}

[System.Serializable]
public class State
{
    /* Change to whatever your JSON file has the variable named. 
     * In this example it is "name": "WhatevertheStatesNameIs"
     * And "number":"whateverTheNumberIs" */
    public string name;
    public float number;
}

[System.Serializable]
public class States
{
    // Array of states (and the values) found in the JSON file.
    public State[] states;
}