using UnityEngine;
using System.Collections;

public class ManageBarEvents : MonoBehaviour {

    //public CreatePopUpLabel createPopUpLabel;

	void OnMouseDown() {
        //this piece calls the pop up creation script from the parent object
        CreatePopUpLabel script = this.transform.parent.GetComponent<CreatePopUpLabel>();
        script.CreateValuePopUp();

    }

    // Update is called once per frame
    void Update () {

    }
}
