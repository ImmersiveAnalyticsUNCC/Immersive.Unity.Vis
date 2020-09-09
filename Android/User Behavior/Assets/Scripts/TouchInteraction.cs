using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class TouchInteraction : MonoBehaviour
{
    public GameObject circle;
    public List<TouchLoc> touches = new List<TouchLoc>();
    string path;
    Vector3 oldlocation;
    string writeText;

    //creates file path to store user data on device used
    private void Start()
    {
        path = Application.persistentDataPath + "/debug.txt";
        CreateFile();
    }
    void Update()
    {

        //while the user is touching the screen update location, write position of touch to file, add touch location to list and update according to 
        //player touch location, spawns a prefab wherever the player is touching the screen, delete prefab when player is no longer touching
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            oldlocation = t.position;
            writeText += "Timestamp: " + DateTime.Now.ToString("yyyyMMddTHH:mm:ssZ") + "Location: " + oldlocation + "\r\n";

            WriteToLogFile(writeText);
            if (t.phase == TouchPhase.Began)
            {
                Debug.Log("touch began");
                touches.Add(new TouchLoc(t.fingerId, createCircle(t)));

                

            }
            else if (t.phase == TouchPhase.Ended)
            {
                Debug.Log("touch ended");
                TouchLoc thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
                Destroy(thisTouch.circle);
                touches.RemoveAt(touches.IndexOf(thisTouch));


       

            }
            else if (t.phase == TouchPhase.Moved)
            {
                Debug.Log("touch is moving");
                
               
              TouchLoc thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
              thisTouch.circle.transform.position = getTouchPosition(t.position);

                
            }
            ++i;

            
        }
    }
    //gets and returns position of user touch
    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y+.5f, transform.position.z));
    }

    //Spawns gameobject at touch position
    GameObject createCircle(Touch t)
    {
        GameObject c = Instantiate(circle) as GameObject;
        c.name = "Touch" + t.fingerId;
        c.transform.position = getTouchPosition(t.position);
        return c;
    }
    //writes to file based on the string passed in
    void WriteToLogFile(string message)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(message);
            }


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }
    //creates/updates file at specific path
    private void CreateFile()
    {
      
            File.Create(path);
        

    }

}
  