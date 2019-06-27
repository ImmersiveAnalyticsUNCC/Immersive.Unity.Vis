using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateBars : MonoBehaviour {
    
    public const float barGap = 0.1F;
    public const float inflationSpeed = 0.5f;

    float barSeparation;
    float barWidth;
    float barSeparationZ;
    float barDepth;

    public string barType = "prefabs/bars/prefabSqBar"; //prefab name: can be bar, dot, ...


    void Start () {

        barSeparation = (float)Settings.ENV_MAX_SIZE_WIDTH / (float)JSONtoObj.MainChart.xaxis.values.Count;
        barWidth = barSeparation - barGap;

        barSeparationZ = (float)Settings.ENV_MAX_SIZE_DEPTH / (float)JSONtoObj.MainChart.category.Count;
        barDepth = barSeparationZ - barGap;

        for (int numCat = 0; numCat < JSONtoObj.MainChart.category.Count; numCat++)  // per category...
        {

            for (int numValues = 0; numValues < JSONtoObj.MainChart.xaxis.values.Count; numValues++)  // ... create the row of bars
            {
                double height = (JSONtoObj.MainChart.category[numCat].values[numValues] * Settings.ENV_MAX_SIZE_HEIGHT) / JSONtoObj.MainChart.yaxis.maxValue;

                //we used to store the bars in the jsontoobj array, but doesnt seem that interesting now. back to flat objects...
                //JSONtoObj.MainChart.category[numCat].bars[numValues] = Instantiate(Resources.Load("prefabs/bars/prefabSqBar"), new Vector3(numValues * barSeparation, 0, (numCat * barSeparationZ) + (barSeparationZ / 2)), Quaternion.identity) as GameObject;
                GameObject bar = Instantiate(Resources.Load(barType), new Vector3(numValues * barSeparation, 0, (numCat * barSeparationZ) + (barSeparationZ / 2)), Quaternion.identity) as GameObject;

                //change bar color
                //double red = JSONtoObj.MainChart.category[numCat].values[numValues] / 255;
                //GameObject theBar = GameObject.Find("theBar"); //the cube within the bar prefab
                //theBar.GetComponent<Renderer>().material.color = new Color(numCat * 20, (float)red, 1);

                // this next section copies the relevant attributes of the bar in the bar itself, so they can be accessed later - currently in the create pop up label class
                var barVal = bar.GetComponent<CreatePopUpLabel>();
                barVal.value = JSONtoObj.MainChart.category[numCat].values[numValues];
                barVal.xLabel = JSONtoObj.MainChart.xaxis.values[numValues];
                barVal.categoryLabel = JSONtoObj.MainChart.category[numCat].label;

                // Bar.gameObject.transform.localScale = new Vector3(barWidth, (float)height, barDepth);
                Vector3 barScale = new Vector3(barWidth, (float)height, barDepth);
                StartCoroutine(inflateBar(bar, barScale));

            }


            //Label for Categories
            GameObject objCategoryLabel = Instantiate(Resources.Load("prefabs/axis/CategoryLabel"), new Vector3(Settings.ENV_MAX_SIZE_WIDTH, 0, (numCat * barSeparationZ) + (barSeparationZ / 2)), Quaternion.identity) as GameObject;
            objCategoryLabel.transform.Rotate(90, 0, 0);

            float characterSize = (1f / (float)JSONtoObj.MainChart.category.Count) * (Settings.ENV_MAX_SIZE_DEPTH / 10f);
            if (characterSize > 0.1f) { characterSize = 0.1f; } // beyond 0.1, font gets too big
            objCategoryLabel.GetComponent<TextMesh>().characterSize =  characterSize;

            objCategoryLabel.GetComponent<TextMesh>().text = " " + JSONtoObj.MainChart.category[numCat].label;
        }
    }

    //Animation when bar is created
    IEnumerator inflateBar(GameObject Bar, Vector3 barScale)
    {
        while (Vector3.Distance(Bar.transform.localScale, barScale) > 0.1f)
        {
            Bar.transform.localScale = Vector3.Lerp(Bar.transform.localScale, barScale, Time.deltaTime * inflationSpeed);
            yield return null;
        }
        Bar.transform.localScale = barScale;
    }
}
