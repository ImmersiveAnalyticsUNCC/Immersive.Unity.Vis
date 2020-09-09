using UnityEngine;
using System.Collections;

public class CreateTitles : MonoBehaviour {
    public GameObject barchart;
	// Use this for initialization
	void Start () {
        GameObject TitlesPannel = Instantiate(Resources.Load("prefabs/others/TitlesPannel"), new Vector3(5, 7, 0), Quaternion.identity) as GameObject;
        TitlesPannel.transform.parent = barchart.transform;
        TextMesh Title = GameObject.FindWithTag("Title").GetComponent<TextMesh>();
        Title.text = JSONtoObj.MainChart.Title;

        TextMesh subTitle = GameObject.FindWithTag("Subtitle").GetComponent<TextMesh>();
        subTitle.text = JSONtoObj.MainChart.SubTitle;

        TextMesh source = GameObject.FindWithTag("DataSource").GetComponent<TextMesh>();
        source.text = JSONtoObj.MainChart.DataSource;

    }


}
