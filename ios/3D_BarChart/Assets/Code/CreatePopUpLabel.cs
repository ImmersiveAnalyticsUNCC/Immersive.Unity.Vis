using UnityEngine;
using System.Collections;

public class CreatePopUpLabel : MonoBehaviour {
    public GameObject barchart;
    public double value;
    public string xLabel;
    public string categoryLabel;
    GameObject objPopUp;

    void Update() { PopToFaceCam(); }
    void OnMouseDown() { CreateValuePopUp(); }

    public void CreateValuePopUp () {

        // eliminate all pop ups before creating the new one
        try
        {
            GameObject[] popUps = GameObject.FindGameObjectsWithTag("PopUpValue");
            foreach (GameObject pops in popUps) { Destroy(pops); }
        }

        finally
        {
            Vector3 popUpPos = this.gameObject.transform.position + new Vector3(0, this.transform.localScale.y + 1f, 0);
            objPopUp = Instantiate(Resources.Load("prefabs/others/PopUpValue"), popUpPos, Quaternion.identity) as GameObject; //from prefab
            objPopUp.transform.parent = barchart.transform;
            GameObject popUpLabel = GameObject.Find("PopUpLabel");
            popUpLabel.GetComponent<TextMesh>().text = "X: " + xLabel + "\nCategory: " + categoryLabel + "\nValue: " + value.ToString(); //TODO: for some reason this thing doesnt update on screen - does retain the inspector screens value
        }
    }
	
	// Update is called once per frame
	public void PopToFaceCam () {
        // rotates the popup to face the cam
        if (objPopUp != null)
        {
            objPopUp.transform.LookAt(Camera.main.transform.position );
            objPopUp.transform.Rotate(0, 180, 0); // for some reason the plane is looking to the back
        }
    }
}
