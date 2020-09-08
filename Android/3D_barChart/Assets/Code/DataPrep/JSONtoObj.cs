using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Boomlagoon.JSON;


public class XAxis {
    public string label { get; set; }
    public List<string> values { get; set; } 
}

public class YAxis {
    public string label { get; set; }
    public string uom { get; set; }
    public double maxValue { get; set; }
    public double minValue { get; set; }
    public string numberFormat { get; set; }
}

public class Category {
    public string label { get; set; }
    public List<double> values { get; set; }
    //public List<GameObject> bars { get; set; } //these are the actual graphical objects
}

public class FullChart {
    public string Title {get; set; }
    public string SubTitle { get; set; }
    public string DataSource { get; set; }
    public XAxis xaxis { get; set; }
    public YAxis yaxis { get; set; }
    public List<Category> category { get; set; }
    public string parsingErrors { get; set; } // records the critcal errors found during parsing the json file, for reference
}

public class JSONtoObj : MonoBehaviour {

    public TextAsset jsonFile;

    void readChartTitles (string JSONstr)
    {
        JSONObject jsonObject = JSONObject.Parse(JSONstr);
        try { MainChart.Title = jsonObject.GetValue("Title").Str; } catch (System.Exception err) { MainChart.Title= ""; }
        try { MainChart.SubTitle = jsonObject.GetValue("Subtitle").Str;} catch (System.Exception err) { MainChart.SubTitle= ""; }
        try { MainChart.DataSource = jsonObject.GetValue("DataSource").Str; } catch (System.Exception err) { MainChart.DataSource = ""; }
    }

    XAxis readXAxisJson (string JSONstr) {
        XAxis xax = new XAxis();
        JSONObject jsonObject = JSONObject.Parse(JSONstr);
        try { xax.label = jsonObject.GetValue("Label").Str; } catch (System.Exception err) { xax.label = ""; }
        xax.values = new List<string>();
        foreach (JSONValue val in jsonObject.GetArray("Values"))
        {
            //Debug.Log("valoreEESSSS: " + val.Str);
            xax.values.Add(val.Str);
        }
        return xax;
    }

    YAxis readYAxisJson(string JSONstr)
    {
        YAxis yax = new YAxis();
        JSONObject jsonObject = JSONObject.Parse(JSONstr);
        try { yax.label = jsonObject.GetValue("Label").Str; } catch (System.Exception err) { yax.label = ""; }
        try { yax.uom = jsonObject.GetValue("UoM").Str; } catch (System.Exception err) { yax.uom = ""; }
        try { yax.maxValue = jsonObject.GetNumber("MaxValue"); } catch (System.Exception err) { yax.maxValue = 100; MainChart.parsingErrors += "Error reading Maxvalue for YAXis, defaulting to 100. Moving on..."; }
        try { yax.minValue = jsonObject.GetNumber("MinValue"); } catch (System.Exception err) { yax.maxValue = 0; MainChart.parsingErrors += "Error reading Minvalue for YAXis, defaulting to 0. Moving on..."; }
        return yax;
    }

    Category readCategoryJson(string JSONstr)
    {
        Category cat = new Category();
        JSONObject jsonObject = JSONObject.Parse(JSONstr);
        try { cat.label = jsonObject.GetValue("Label").Str; } catch (System.Exception err) { cat.label = "CATEGORY"; }

        cat.values = new List<double>();
        //cat.bars = new List<GameObject>();
        foreach (JSONValue val in jsonObject.GetArray("Values"))
        {
            cat.values.Add(val.Number);
          //  cat.bars.Add(new GameObject("empty")); //empty object as a placeholder for the graphical bar, created later
        }
        return cat;
    }

        public static FullChart MainChart = new FullChart() ;

    
    void Awake() {  //Awake is called before Start()

        string strJSON = "";
        // reads the JSON string from a file in the resources folder
        try
        {
            //jsonFile = Resources.Load("JSON_DATA.txt") as TextAsset; // ASSIGNED IN THE INSPECTOR
            strJSON = jsonFile.text;
        }
        catch (System.Exception err)
        {
            //If err, put a sample data string, just to keep going...
            strJSON = "{\r\n  \"XAXIS\": {\r\n    \"Label\": \"Year\",\r\n    \"Values\": [\r\n      \"1950\",\r\n      \"1951\",\r\n      \"1952\",\r\n      \"1953\",\r\n      \"1954\",\r\n      \"1955\",\r\n      \"1956\",\r\n      \"1957\",\r\n      \"1958\",\r\n      \"1959\",\r\n      \"1960\",\r\n      \"1961\"\r\n    ]\r\n  },\r\n  \"YAXIS\": {\r\n    \"Label\": \"Population\",\r\n    \"UOM\": \"People\",\r\n    \"MaxValue\": 4000000,\r\n    \"MinValue\": 0\r\n  },\r\n  \"CATEGORY1\": {\r\n    \"Label\": \"World\",\r\n    \"Values\": [\r\n      2525149,\r\n      2571868,\r\n      2617940,\r\n      2664029,\r\n      2710678,\r\n      2758315,\r\n      2807246,\r\n      2857663,\r\n      2909651,\r\n      2963216,\r\n      3018344,\r\n      3075073\r\n    ]\r\n  },\r\n  \"CATEGORY2\": {\r\n    \"Label\": \"More developed regions\",\r\n    \"Values\": [\r\n      812989,\r\n      822320,\r\n      832149,\r\n      842294,\r\n      852613,\r\n      863004,\r\n      873402,\r\n      883779,\r\n      894144,\r\n      904526,\r\n      914951,\r\n      925414\r\n    ]\r\n  },\r\n  \"CATEGORY3\": {\r\n    \"Label\": \"Less developed regions\",\r\n    \"Values\": [\r\n      1712161,\r\n      1749547,\r\n      1785792,\r\n      1821735,\r\n      1858064,\r\n      1895310,\r\n      1933845,\r\n      1973884,\r\n      2015507,\r\n      2058691,\r\n      2103393,\r\n      2149659\r\n    ]\r\n  }\r\n}";
            MainChart.parsingErrors += "Critical error reading the json file, we've added a sample data just to keep you entertained. " + err.Message;
            Debug.Log(err.Message);
            throw;
        }

        MainChart.category = new List<Category>(); // inititalizes the array of categories
        
        //Parses JSON with BOOMLAGOON 
        JSONObject jsonObject = JSONObject.Parse(strJSON);

        //Debug.Log("XAXIS.Label: " + jsonObject.GetString("XAXIS"));
        foreach (KeyValuePair<string, JSONValue> pair in jsonObject)
        {
            if (pair.Key =="CHART") { readChartTitles(pair.Value.ToString()); }
            if (pair.Key == "XAXIS") { MainChart.xaxis = readXAxisJson(pair.Value.ToString()); }
            if (pair.Key == "YAXIS") { MainChart.yaxis = readYAxisJson(pair.Value.ToString()); }
            if (pair.Key.Contains("CATEGORY")) { MainChart.category.Add(readCategoryJson(pair.Value.ToString())); }
        }
    }



    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
