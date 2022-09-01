using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
  
   
    Vector3 touchStart;
    public Transform target;
    public float distance = 20.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float distanceMin = .5f;
    public float distanceMax = 15f;

    public float zoomOutMin = 10;
    public float zoomoutMax = 20;
  
   
    public Vector3 delta = Vector3.zero;
    private Vector3 lastPos = Vector3.zero;

    float x = 0.0f;
    float y = 0.0f;
    GameObject[] array;


    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {


            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastPos = Input.mousePosition;


        }

        if (Input.touchCount == 2)
        {
            Debug.Log("Two touches");
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMag = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMag - prevMag;

            Zoom(difference * 0.01f);
        }
        else if (Input.GetMouseButton(0))
        {
 
           Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
           Camera.main.transform.position += direction;

        }
        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }
    void Zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomoutMax);
    }
    
   
}
