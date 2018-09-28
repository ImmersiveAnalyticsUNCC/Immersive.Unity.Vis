#pragma strict



function Start () {
	
}


function Update () {
	
	if(Input.GetKey(KeyCode.DownArrow)){
		transform.Rotate(Vector3.left*Time.deltaTime*100,Space.World);
	}else if(Input.GetKey(KeyCode.UpArrow)){
		transform.Rotate(Vector3.right*Time.deltaTime*100, Space.World);
	}else if(Input.GetKey(KeyCode.LeftArrow)){
		transform.Rotate(Vector3.up * Time.deltaTime*100, Space.World);
	}else if(Input.GetKey(KeyCode.RightArrow)){
		transform.Rotate(Vector3.down *Time.deltaTime*100, Space.World);
	}else if(Input.GetKeyDown(KeyCode.Space)){
	    transform.eulerAngles = Vector3(0,0,0);
	}
	
//	if(Input.GetMouseButton(0)){
//		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//		var hit : RaycastHit;
//		if (Physics.Raycast (ray, hit, 100)) {
//			Debug.DrawLine (ray.origin, hit.point);
//			Debug.Log(hit.point);
//		}
//	}
	
}

