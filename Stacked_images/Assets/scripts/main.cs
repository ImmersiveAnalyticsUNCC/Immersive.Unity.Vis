using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour {

    public Transform img1; public Transform img2; public Transform img3; public Transform img4; public Transform img5; public Transform img6; public Transform img7; public Transform img8;
    private List<Transform> allImages;
    // Use this for initialization
    void Start () {
        allImages = new List<Transform>() { img1, img2, img3, img4, img5, img6, img7, img8 };
        showImages();
	}
	
    public void showImages()
    {
        for(int i = 0; i<allImages.Count; i++)
        {
            Transform map = GameObject.Instantiate(allImages[i]) as Transform;
            map.parent = this.transform;
            map.localRotation = Quaternion.identity;
            map.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            map.localPosition = new Vector3(1, 0, -1-i);
            map.name = i.ToString();


        }
    }
	
}
