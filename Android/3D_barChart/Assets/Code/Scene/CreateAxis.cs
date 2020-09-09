using UnityEngine;
using System.Collections;

public class CreateAxis : MonoBehaviour {
    public GameObject barchart;
	// Use this for initialization
	void Start () {
        float barSeparation = (float)Settings.ENV_MAX_SIZE_WIDTH / (float)JSONtoObj.MainChart.xaxis.values.Count;
        //float barWidth = barSeparation - barGap;

        // XAxis
        for (int numLabel = 0; numLabel < JSONtoObj.MainChart.xaxis.values.Count; numLabel++)  // ... create the X labels
        {
            GameObject newLabel = Instantiate(Resources.Load("prefabs/axis/XAxisLabel"), new Vector3(numLabel * barSeparation, 0, - 0.3f), Quaternion.Euler(0, 180, 0)) as GameObject;
            newLabel.transform.parent = barchart.transform;
            newLabel.GetComponent<TextMesh>().text = "  " + JSONtoObj.MainChart.xaxis.values[numLabel].ToString();

            float characterSize = (1f / (float)JSONtoObj.MainChart.xaxis.values.Count) * (Settings.ENV_MAX_SIZE_WIDTH / 10f);
            if (characterSize > 0.1f) { characterSize = 0.1f; } // beyond 0.1, font gets too big
            newLabel.GetComponent<TextMesh>().characterSize = characterSize;

            newLabel.transform.Rotate(90f, 0, -90f);
        }


        // YAxis grid lines
        float YLineSeparation = (float)Settings.ENV_MAX_SIZE_HEIGHT / 10;
        for (int numYLine = 0; numYLine < 10; numYLine++)
        {
            GameObject YLine = Instantiate(Resources.Load("prefabs/axis/YAxisLine"), new Vector3(-0.96f, YLineSeparation*numYLine, 5f),Quaternion.Euler(0,90,0)) as GameObject;
            GameObject YLineLabel = Instantiate(Resources.Load("prefabs/axis/YAxisLabel"), new Vector3(-1f, YLineSeparation*numYLine, 0f), Quaternion.Euler(0, -90, 0)) as GameObject;
            YLine.transform.parent = barchart.transform;//added obj as child to barchart
            YLineLabel.transform.parent = barchart.transform;//added obj as child to barchart
            var YLabelValue= (JSONtoObj.MainChart.yaxis.maxValue / 10) * numYLine;
            YLineLabel.GetComponent<TextMesh>().text= YLabelValue.ToString("0,0"); //TODO: number formatting
    }
}
	

}
