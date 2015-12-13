using UnityEngine;
using System.Collections;

public class Bahavior : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * 10);

		if(transform.position.y > 10){
			OnDisable();
		}
	}

	void OnDisable(){
		this.gameObject.SetActive(false);		
	}
}
