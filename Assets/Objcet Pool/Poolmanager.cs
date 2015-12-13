using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Poolmanager : MonoBehaviour {

	public static Poolmanager _istance;

	public GameObject bulletfab;
	public GameObject bulletContainer;
	public int bulletsToSppawn;
	public bool willGrow = true;

	public List<GameObject> bulletsList = new List<GameObject>();

	void Awake(){
		_istance = this;
	}

	void Start(){
		//bulletsToSppawn = bc.gcount;
		for(int i = 0; i< bulletsToSppawn; i++){
			GameObject bullet = Instantiate(bulletfab,Vector3.zero,Quaternion.identity) as GameObject;
            bullet.transform.parent = bulletContainer.transform;
			bullet.SetActive(false);
			bulletsList.Add(bullet);
		}

	}

	void Update(){
		if(bulletsList.Count >49)
		willGrow = false ;
	}

	public GameObject GetPooledObject(){
        for (int i = 0; i < bulletsList.Count; i++){
            if (!bulletsList[i].activeInHierarchy){
                    return bulletsList[i];
                }
        }

		if(willGrow){
				GameObject bullet = Instantiate(bulletfab,Vector3.zero,Quaternion.identity) as GameObject;
	            bullet.transform.parent = bulletContainer.transform;
				bulletsList.Add(bullet);
				return bullet;
		}
			return null;
	}
}
