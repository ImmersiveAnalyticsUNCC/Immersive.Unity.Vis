using UnityEngine;
using System.Collections;


public class MouseOrbitImproved : MonoBehaviour
{
    public GameObject barchart;
    bool rotate;
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
  
    private Vector3 originalPos;
    public Quaternion originalRot;

    public Vector3 delta = Vector3.zero;
    private Vector3 lastPos = Vector3.zero;


    // Use this for initialization
    //Sets original positions of both barchart and Camera
    void Start()
    {
       
        originalRot = barchart.transform.rotation;
        originalPos = Camera.main.transform.position;
   
    }

    void Update()
    {
    
        //if user clicks the left mouse button change touchstrart to where the mouse position is located
        //store position into last position
        if (Input.GetMouseButtonDown(0))
        {

            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastPos = Input.mousePosition;

        }
        //if two touches are detected, find the previous and current positions of each touch
        //calculate the previous and current magnitudes and find the difference between the two
        //call the zoom function using the difference
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
        //if mouse button is pressed/ or finger is touched on screen, will calculate delta of mouse/finger position 
        //if rotate is false, will then pan screen by changing camera position by adding offset of direction of mouse
        //if rotate is enabled, will rotate barchart around its axis according to the X axis of the mouse/touch and by the speed at which mouse/finger is moving
        /*else if (Input.GetMouseButton(0))
        {
            delta = Input.mousePosition - lastPos;


            if (rotate == false)
            {
                Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Camera.main.transform.position += direction;
            }
            else
            {
                Debug.Log(Time.deltaTime);
                barchart.transform.RotateAround(barchart.transform.position, new Vector3(0, Input.GetAxis("Mouse X"), 0), delta.magnitude*Time.deltaTime+delta.magnitude/100);

            }
            
        }*/
        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }
    //Change the camera orthographic view size between the range of zoomout min and max, and subtract current size from the increment passed in
    void Zoom(float increment)
    {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomoutMax);
    }
    //Toggle function called when toggle button is pressed, toggles rotate between true and false
    /*public void Toggle()
    {
        if (rotate == false)
        {
            rotate = true;
        }
        else
        {
            rotate = false;
        }
    }
    //resets camera and barchart to original positions and sizes when reset button is clicked/pressed
    public void Reset()
    {
        Camera.main.transform.position = originalPos;
        barchart.transform.rotation = originalRot;
        Camera.main.orthographicSize = 20;
    }*/

}