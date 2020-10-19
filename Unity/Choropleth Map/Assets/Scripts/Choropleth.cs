/* Authored by Christian Motley
 * For use in Dr. Aidong Lu's Immersive Vis Repository for her ITCS - 4123/5123 - Visualization and Visual Communication course at UNC Charlotte.
 * Using the Quick Outline asset from the Unity Asset Store with slight modifications - https://assetstore.unity.com/packages/tools/particles-effects/quick-outline-115488
 * Last Modified: October 19th, 2020 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choropleth : MonoBehaviour
{
    [Tooltip("Array of data values.")]
    public float dataValue = 0;
    [HideInInspector]
    public Collider lastSelected = null;

    Choropleth choropleth;
    Outline outline;

    void Start()
    {
        choropleth = gameObject.GetComponent<Choropleth>();
        Invoke("checkColorValue", 2.0f); // Calls the method after X seconds.
        //InvokeRepeating("checkColorValue", 2.0f, 3.0f); // Calls the method in X seconds and repeats the call every Y seconds.
    }

    void Update()
    {
        singleSelection();
    }

    // Highlights a gameobject when it is clicked, disables the highlighting on previously selected gameobjects.
    void singleSelection()
    {
        if (Input.GetButtonDown("Fire1")) // Change input settings with Profile>Input Manager> Axes. Currently set to Left-Mouse Button click or Single Tap on mobile.
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out raycastHit))
            {
                // Unhighlighting and unfocusing the previously selected gameobject.
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

                // Highlighting and focusing the selected gameobject.
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

                // Unhighlighting and unfocusing the selected gameobject.
                else if (lastSelected.name == raycastHit.collider.name)
                {
                    outline = GameObject.Find(lastSelected.name).GetComponent<Outline>();
                    outline.outlineWidth = 0f;
                    outline.needsUpdate = true;
                    lastSelected = null;
                }
            }
        }
    }

    // Checks the dataValue and changes the gameobject's color base on whichever color cut-off range it falls under.
    void checkColorValue()
    {
        // Change the color and cut-off value to whatever you want.
        if (dataValue <= 0)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.grey;
        }
        else if(dataValue > 0 && dataValue <= 25)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        else if(dataValue > 25 && dataValue <= 50)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
        }
        else if(dataValue > 50 && dataValue <= 75)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if(dataValue > 75 && dataValue <= 99)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else // 100+
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}