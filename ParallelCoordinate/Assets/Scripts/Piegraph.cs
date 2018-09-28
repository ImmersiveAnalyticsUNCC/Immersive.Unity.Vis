using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Piegraph : MonoBehaviour {

    public float[] values;
    public Color[] wedgeColors;
    public Image wedgePrefeb;

	// Use this for initialization
	void Start () {
        MakeGraph();
	}

    public void MakeGraph(){
        float total = 0f;
        float zRotation = 0f;
        for (int i = 0; i < values.Length; i++){
            total += values[i];
        }

        for (int i = 0; i < values.Length; i++){
            Image newWedge = Instantiate(wedgePrefeb) as Image;
            newWedge.transform.SetParent(transform, false);
            newWedge.color = wedgeColors[i];
            newWedge.fillAmount = values[i] / total;
            newWedge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));
            zRotation -= newWedge.fillAmount * 360f;
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
