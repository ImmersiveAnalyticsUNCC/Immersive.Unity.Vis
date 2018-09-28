using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Document
{
    public int YEAR;
    public string FACILITY_NAME;
    public string STREET_ADDRESS;
    public string CITY;
    public string COUNTY;
    public string ST;
    public int ZIP;
    public float LATITUDE;
    public float LONGITUDE;
    public string FEDERAL_FACILITY;
    public int INDUSTRY_SECTOR_CODE;
    public string INDUSTRY_SECTOR;
    public string CHEMICAL;
    public string CLEAR_AIR_ACT_CHEMICAL;
    public string CLASSIFICATION;
    public string METAL;
    public int METAL_CATEGORY;
    public string CARCINOGEN;
    public string UNIT_OF_MEASURE;
    public int TOTAL_RELEASES;
    public string PARENT_COMPANY_NAME;
}

[System.Serializable]
public class AllDocuments
{
    public Document[] docs;
}

    public class DataConverter : MonoBehaviour {
    
    
    void Start () {
        string dataAsJson = File.ReadAllText("Assets/Data/2015US.json");
        AllDocuments info = JsonUtility.FromJson<AllDocuments>(dataAsJson);

        foreach (Document doc in info.docs)
        {
            Debug.Log(doc.ST);
        }
    }
}
