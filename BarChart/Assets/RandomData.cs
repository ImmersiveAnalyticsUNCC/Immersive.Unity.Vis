using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomData : MonoBehaviour
{
    public GameObject BarPrefeb;

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
            Vector3 tarPos = new Vector3(2 * i - number, data[i] / 2.0f, 0);
            BarPrefeb.transform.localScale = new Vector3(1, data[i], 1);
            //BarPrefeb.GetComponents<Label>;
            Instantiate(BarPrefeb, tarPos, Quaternion.identity);
        }
    }
}

