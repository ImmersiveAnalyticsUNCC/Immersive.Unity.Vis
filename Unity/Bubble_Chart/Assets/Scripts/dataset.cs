using System.Collections.Generic;
using UnityEngine;

public class dataset : MonoBehaviour {

    public static Dictionary<string, int> data = new Dictionary<string, int>();
    public static int MaxNormalvalue = 5;
    public static int MinNormalValue = 1;

    public static void makedata()
    {
        data.Add("type1", 78);
        data.Add("type2", 816);
        data.Add("type3", 2791);
        data.Add("type4", 595);
        data.Add("type5", 148);
        data.Add("type6", 25);
        data.Add("type7", 38);
        data.Add("type8", 1462);
        data.Add("type9", 168);
        data.Add("type10", 282);
        data.Add("type11", 33);
        data.Add("type12", 735);
        data.Add("type13", 118);
        data.Add("type14", 75);
        data.Add("type15", 75);
    }

    public static int MinInArray()
    {
        int result = 1000000;
        foreach (var pair in data)
        {
            if(pair.Value < result) { result = pair.Value; }
        }
        return result;
    }
    public static int MaxInArray()
    {
        int result = 0;
        foreach (var pair in data)
        {
            if (pair.Value > result) { result = pair.Value; }
        }
        return result;
    }
}
