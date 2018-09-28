//#pragma strict

import SimpleJSON;
import System.IO;

var prefab:GameObject;

var allEvents=new Array();

public static var lbText="Use w/s to zoom in/out";
public static var rbText="Click marker to select event";
public static var ltText="No event selected";
public static var rtText="Use arrow keys to move the earth";
public static var countryText="United States";
public static var categoryText="music";
public static var weatherText="";
public static var loadingText="";


function Start () {
	var t: System.DateTime = System.DateTime.Now;
    var dateString = String.Format("{0:D2}{1:D2}{2:D2}", t.Day, t.Month, t.Year);
    var country = "United%20States";
//    country="India";
    var fileName = dateString+"_"+country;
    var fullPath = Application.dataPath + "/" + fileName;
	var pgsz = 100;
	prefab = Resources.Load("Marker");


    if(File.Exists(fullPath+"_count.json")){
    	Debug.Log("From file");
    	var sr = new StreamReader(fullPath+"_count.json");
		var fileContents = sr.ReadToEnd();
		sr.Close();
		var jsonObjCF = JSON.Parse(fileContents);
		var eventC = jsonObjCF["total_items"].AsInt;
		
		var inc = eventC%pgsz==0?0:1;
		var pageCount = eventC/pgsz+inc;
		for (var m = 1;m<=pageCount;m++){
			var fnJ = fullPath+"_"+m+".json";
			if(File.Exists(fnJ)){
				var srT = new StreamReader(fnJ);
				var fileContentsT = srT.ReadToEnd();
				var jsonObjF = JSON.Parse(fileContentsT);
				var tempF = jsonObjF["events"]["event"];
				var countF = tempF.Count;
				for(var l=0;l<countF;l++){
					allEvents.push(tempF[l]);
					drawSphere(tempF[l]);
				}
			}
		}
		Debug.Log(tempF);		

    }else{
    	Debug.Log("From url");
		var urlBase = "http://api.eventful.com/json/events/search?";
		var appKey = "app_key=D4WVJt3mRXKmGNLk";
		var category = "&category="+categoryText;
//		category="";
		var location = "&location="+country;
		var date = "&date=today";
		var format = "&format=json";
		var pageSize = "&page_size="+pgsz;
		var url = urlBase+appKey+location+date+pageSize+category;
		var urlCountOnly = url+"&count_only=true";
		Debug.Log(urlCountOnly);
		var wwwC: WWW = new WWW(urlCountOnly);
		yield wwwC;
		if(wwwC.error){
			Debug.Log(wwwC.error);
		}else{
			var countData = wwwC.text;
			var dataBytes = System.Text.Encoding.UTF8.GetBytes(countData);
			File.WriteAllBytes(fullPath+"_count.json",dataBytes);
			var jsonObjC = JSON.Parse(countData);
			
			var totalItems = jsonObjC["total_items"].AsInt;
			
			inc = totalItems%pgsz==0?0:1;
			pageCount = totalItems/pgsz+inc;
			loadingText = "Loading.. Completed 0/"+totalItems;

			for (var j = 1;j<=pageCount;j++){
				var pageNum = "&page_number="+j;
				var www: WWW = new WWW(url+pageNum);
				yield www;
				if(www.error){
					Debug.Log(www.error);
				}else{
					var data = www.text;
					dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
					File.WriteAllBytes(fullPath+"_"+j+".json",dataBytes);
					var jsonObjU = JSON.Parse(data);
					var temp = jsonObjU["events"]["event"];
					var count = temp.Count;
					var current = transform.eulerAngles;
					transform.eulerAngles = Vector3.zero;
					for(var k=0;k<count;k++){
						allEvents.push(temp[k]);
						drawSphere(temp[k]);

					}
					transform.eulerAngles = current;
					if(j==pageCount){
						loadingText = "";
					}else{
						loadingText = "Loading.. Completed "+j*100+"/"+totalItems;
					}
				}
			}
		
			
		}
		
		
    }
	Debug.Log(allEvents);
	if(allEvents != null){
	    for (var i =0 ;i<allEvents.Count;i++) {
			var event = allEvents[i];
//			drawSphere(event);
			
		}    
	}
        
}

function drawSphere(event)
{
	    var radius = 10.0;
		var lon:float = event["longitude"].AsFloat;
        var lat:float = event["latitude"].AsFloat;
        if(lat == 0 && lon ==0) return;
        lon = lon * Mathf.Deg2Rad;
        lat = lat * Mathf.Deg2Rad;
        var pos = new Vector3(Mathf.Cos(lon)*Mathf.Cos(lat)*radius, Mathf.Sin(lat)*radius, Mathf.Sin(lon)*Mathf.Cos(lat)*radius);
        var sphere = Instantiate(prefab, pos, Quaternion.identity);
		
		var showDetail:ShowDetails = sphere.GetComponent.<ShowDetails>();
		showDetail.event = event;

        var size = 0.08;
    	sphere.transform.localScale = Vector3(size,size,size);
		sphere.transform.parent = transform;
		sphere.transform.rotation = transform.rotation;
		sphere.transform.position = pos;
}

function Update () {
	
}



function OnMouseDown(){
	
	Debug.Log("Sphere clicked");
}
