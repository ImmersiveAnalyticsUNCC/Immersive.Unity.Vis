using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomData : MonoBehaviour
{
    public Transform BarChart;
    public GameObject BarPrefab;

    static int number = 10;
    public float[] data = new float[number];


    private void Start()
    {
        GenerateData();
        GenerateBars();
    }
    void GenerateData()
    {
        for (int i = 0; i < number; i ++)
        {
            data[i] = Random.Range(1, 5);
        }
    }

    void GenerateBars()
    {
        for (int i = 0; i < number; i++)
        {
            // for Bar prefeb
            Vector3 tarPos = new Vector3(2 * i - number, data[i] / 2.0f, 0);
            // for Cylinder prefeb
            //Vector3 tarPos = new Vector3(2 * i - number, data[i], 0);
            var p = Instantiate(BarPrefab, tarPos, Quaternion.identity);
            p.transform.localScale = new Vector3(p.transform.localScale.x, 
                p.transform.localScale.y * data[i],
                p.transform.localScale.z); ;
            p.transform.SetParent(BarChart);
        }
    }
}
