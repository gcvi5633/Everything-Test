using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class RadarObject{
	public Image icon{ get; set;}
	public GameObject onwer{ get; set;}
}

public class Radar : MonoBehaviour {

	public Transform playerPos;
	public float mapScale = 1.0f;

	public bool rotation;

	public static List<RadarObject> radarObjects = new List<RadarObject>(); 

	public static void registerRadarObject(GameObject o,Image i){
		Image image = Instantiate (i);
		radarObjects.Add (new RadarObject (){onwer = o,icon = image});
	}

	public static void RemoveRadarObject(GameObject o){
		List<RadarObject> newList = new List<RadarObject> ();
		for (int i =0; i<radarObjects.Count; i++) {
			if(radarObjects[i].onwer == o){
				Destroy(radarObjects[i].icon);
				continue;
			}else {
				newList.Add(radarObjects[i]);
			}
		}
		radarObjects.RemoveRange (0, radarObjects.Count);
		radarObjects.AddRange (newList);
	}
	void DrawRadarDots(){
		foreach (RadarObject ro in radarObjects) {
			Vector3 radarPos = (ro.onwer.transform.position - playerPos.position);
			float distToObject = Vector3.Distance(playerPos.position,ro.onwer.transform.position)*mapScale;
			if(rotation){
			float deltay = Mathf.Atan2(radarPos.x,radarPos.z)*Mathf.Rad2Deg - 270 - playerPos.eulerAngles.y;
			radarPos.x= distToObject*Mathf.Cos(deltay*Mathf.Deg2Rad)*-1;
			radarPos.z= distToObject*Mathf.Sin(deltay*Mathf.Deg2Rad);
			}
			ro.icon.transform.SetParent(this.transform);
			ro.icon.transform.position = new Vector3(radarPos.x,radarPos.z,0)+this.transform.position;
		}
	}
	void Update(){
		DrawRadarDots ();
	}
}
