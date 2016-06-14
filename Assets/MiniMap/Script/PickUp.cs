using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	public GameObject pointCheck;

	// Use this for initialization
	void Start () {
		pointCheck = GameObject.Find ("PointManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			pointCheck.GetComponent<PointPlus>().GetPoint();
			Destroy(this.gameObject);
		}
	}
}
