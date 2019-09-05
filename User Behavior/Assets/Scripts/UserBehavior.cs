using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public class UserBehavior : MonoBehaviour {

    [SerializeField] Transform player;
    [SerializeField] GameObject location;
    [SerializeField] float r;
    [SerializeField] float g;
    [SerializeField] float b;
    Vector3 oldlocation;
    /*[SerializeField]*/ string path;
    StreamWriter fs;
    string writeText;
    int count;

    // Use this for initialization
    void Start () {
        count = 0;
        oldlocation = player.position;
        path = Application.dataPath + "/Log/debug.txt";
        Debug.Log(path);
        Instantiate(location, player.position, Quaternion.identity).GetComponent<Renderer>().material.color = Color.black;
        CreateFile();
    }

    private void CreateFile()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        //fs = new StreamWriter(path);
    }

    // Update is called once per frame
    void Update () {
       // Instantiate(location, player.position, Quaternion.identity);
        if (Vector3.Distance(oldlocation, player.position) > 1)
        {
            var newSphere = Instantiate(location, player.position, Quaternion.identity);
            newSphere.GetComponent<Renderer>().material.color = new Color(r *count++,g * count,b * count,1);
            oldlocation = player.position;
            Debug.Log(oldlocation);
            writeText += "Timestamp: " + DateTime.Now.ToString("yyyyMMddTHH:mm:ssZ") + "Location: " + oldlocation + "\r\n";
            Debug.Log(writeText);
            WriteToLogFile(writeText);
           // count++;
        }
        

    }

    void WriteToLogFile(string message)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(message);
            }

            //using (StreamReader sr = File.OpenText(path))
            //{
            //    string s = "";
            //    while ((s = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
