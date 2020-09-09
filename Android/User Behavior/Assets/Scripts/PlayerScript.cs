using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour {
   
   
   //destroys game obj when mouse touches the collider 
    private void OnMouseEnter()
    {

        Destroy(this.gameObject);
            
       
    }

   
}
