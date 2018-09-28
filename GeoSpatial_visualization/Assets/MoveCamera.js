#pragma strict
var earth:GameObject;
function Start () {

}

function Update () {
//	var distance = Vector3.Distance(earth.transform.position,transform.position);
	var distance = 3;
	if(distance >= 0 ){
		if(Input.GetKey(KeyCode.W)){
			transform.Translate(Vector3.forward*Time.deltaTime*10);
		}else if(Input.GetKey(KeyCode.S)){
			transform.Translate(Vector3.back*Time.deltaTime*10);
		}
	}
}