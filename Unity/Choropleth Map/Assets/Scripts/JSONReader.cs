/* Authored by Christian Motley
 * For use in Dr. Aidong Lu's Immersive Vis Repository for her ITCS - 4123/5123 - Visualization and Visual Communication course at UNC Charlotte.
 * Using the Quick Outline asset from the Unity Asset Store with slight modifications - https://assetstore.unity.com/packages/tools/particles-effects/quick-outline-115488
 * Last Modified: October 13th, 2020 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    [Tooltip("Drag your JSON file here.")]
    public TextAsset jsonFile;
    private Collider lastSelected = null;

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

    void Update()
    {
        singleSelection();
    }

    // Highlights a gameobject when it is clicked, disables the highlighting on previously selected gameobjects.
    void singleSelection()
    {
        if (Input.GetButtonDown("Fire1")) // Change input settings with Profile>Input Manager> Axes.
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out raycastHit))
            {
                // Unhighlighting the previously selected gameobject.
                if (lastSelected != null)
                {
                    // Simple way to unhighlight the previously selected gameobject.
                    //GameObject.Find(lastSelected.name).GetComponent<Outline>().enabled = false;

                    /* Other way to unhighlight the previously selected gameobject, allows for altering the outline width.
                       Potentially useful if you want to add multiple selection and have the most recent selection with the greatest width.*/
                    outline = GameObject.Find(lastSelected.name).GetComponent<Outline>();
                    outline.outlineWidth = 0f;
                    outline.needsUpdate = true;
                }
                // Highlighting the selected gameobject.
                if (lastSelected == null || (raycastHit.collider.name != lastSelected.name))
                {
                    // Simple way to highlight the selected gameobject. Need to have the outlineWidth variable set to a value > 0f in the Outline script.
                    //GameObject.Find(raycastHit.collider.name).GetComponent<Outline>().enabled = true;

                    /* Other way to highlight the selected gameobject, allows for altering the outline width.
                       Potentially useful if you want to add multiple selection and have the most recent selection with the greatest width.*/
                    outline = GameObject.Find(raycastHit.collider.name).GetComponent<Outline>();
                    outline.outlineWidth = 20f;
                    outline.outlineColor = Color.white;
                    outline.needsUpdate = true;
                    lastSelected = raycastHit.collider;
                }
            }
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