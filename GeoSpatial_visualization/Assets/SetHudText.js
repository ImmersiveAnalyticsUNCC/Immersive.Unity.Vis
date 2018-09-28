#pragma strict

import UnityEngine.UI;


private var text;

function Start () {
 	text = LoadData.lbText;

}

function Update () {
	
	var textObj: Text = GetComponent.<Text>();

	switch (tag){
		case "LB":
			text = LoadData.lbText;
			break;			
		case "LT":
			text = LoadData.ltText;
			break;
		
		case "RB":
			text = LoadData.rbText;
			break;
		
		case "RT":
			text = LoadData.rtText;
			break;		
		case "MT":
			var catText = LoadData.categoryText==""?"":" Category: "+LoadData.categoryText;
			text = "Events from: "+LoadData.countryText+catText;
			break;
		case "MB":
			text = LoadData.weatherText;
			break;
		case "CM":
			text = LoadData.loadingText;
			break;
		default:
			text = "Unknown component";
			Debug.Log("Unknown text");
	
	}
	
	textObj.text = text;
	
}