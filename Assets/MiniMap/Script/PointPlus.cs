using UnityEngine;
using System.Collections;

public class PointPlus : MonoBehaviour {

	public int point;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			point++;
		}
	}

	public void GetPoint(){
		point++;
	}
	void OnGUI(){
		GUI.Label (new Rect(Screen.width - 100,30,250,30),"Point: " + point);
	}
}
