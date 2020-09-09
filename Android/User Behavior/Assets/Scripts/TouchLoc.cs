using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLoc : MonoBehaviour
{
    public int touchId;
    public GameObject circle;

    public TouchLoc(int nTouchid, GameObject newC)
    {
        touchId = nTouchid;
        circle = newC;
    }
}
