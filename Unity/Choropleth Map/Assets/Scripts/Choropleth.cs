/* Authored by Christian Motley
 * For use in Dr. Aidong Lu's Immersive Vis Repository for her ITCS - 4123/5123 - Visualization and Visual Communication course at UNC Charlotte.
 * Last Modified: October 6th, 2020 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choropleth : MonoBehaviour
{
    [Tooltip("Array of data values.")]
    public float dataValue = 0;
    private GameObject gameobject;

    void Start()
    {
        string gameObjectName = this.name;
        gameobject = GameObject.Find(gameObjectName);

        Invoke("checkColorValue", 2.0f); // Calls the method after X seconds.
        //InvokeRepeating("checkColorValue", 2.0f, 3.0f); // Calls the method in X seconds and repeats the call every Y seconds.
    }

    // Checks the dataValue and changes the gameobject's color base on whichever color cut-off range it falls under.
    void checkColorValue()
    {
        // Change the color and cut-off value to whatever you want.
        if (dataValue <= 0)
        {
            gameobject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else if(dataValue > 0 && dataValue <= 25)
        {
            gameobject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        else if(dataValue > 25 && dataValue <= 50)
        {
            gameobject.GetComponent<MeshRenderer>().material.color = Color.cyan;
        }
        else if(dataValue > 50 && dataValue <= 75)
        {
            gameobject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if(dataValue > 75 && dataValue <= 99)
        {
            gameobject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else
        {
            gameobject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}