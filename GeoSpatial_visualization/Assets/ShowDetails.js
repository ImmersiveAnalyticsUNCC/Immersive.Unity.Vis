//#pragma strict

import SimpleJSON;

public var event;

function Start () {

}

function Update () {
	
}

function OnMouseDown(){
	LoadData.weatherText= "Weather: Loading..." ;
	LoadData.lbText = "Event title: "+event["title"].Value;
	LoadData.rbText = "City: "+event["city_name"].Value;
	LoadData.ltText = "Venue: "+event["venue_name"].Value;
	LoadData.rtText = "Start time: "+event["start_time"].Value; 
	var lat = event["latitude"].AsFloat;
	var lon = event["longitude"].AsFloat;
	var url = "http://api.openweathermap.org/data/2.5/weather?lat="+lat+"&lon="+lon+"&appid=f71d3212c24ebe8282a9bf42e71ad368";
	Debug.Log(url);
	var wwwW: WWW = new WWW(url);
	yield wwwW;
	if(wwwW.error){
			Debug.Log(wwwW.error);
			LoadData.weatherText= "" ;

	}else{
		var jsonObjW = JSON.Parse(wwwW.text);
		LoadData.weatherText = "Weather: "+jsonObjW["weather"][0]["description"].Value;
		Debug.Log(jsonObjW["weather"][0]["description"]+Random.value);	 
	}

	 
	

}