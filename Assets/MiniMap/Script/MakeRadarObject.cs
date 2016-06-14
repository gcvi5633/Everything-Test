﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MakeRadarObject : MonoBehaviour {

	public Image image;

	// Use this for initialization
	void Start () {
		Radar.registerRadarObject (this.gameObject, image);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnDestroy(){
		Radar.RemoveRadarObject (this.gameObject);
	}
}
