using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Poolmanager : MonoBehaviour {

	public static Poolmanager _istance;

	public GameObject bulletfab;//Object Pool的物件
	public GameObject bulletContainer;//Object Pool的放置位置
	public int bulletsToSppawn;//Object Pool 的大小
	public bool willGrow = true;//控制是否要讓 Object Pool 能夠被加大

	public List<GameObject> bulletsList = new List<GameObject>();

	void Awake(){
		_istance = this;
	}

	void Start(){

		for(int i = 0; i< bulletsToSppawn; i++){

			//一開始線製造出 bulletsToSppawn 數量的 bullet 物件
			GameObject bullet = Instantiate(bulletfab,Vector3.zero,Quaternion.identity) as GameObject;

			//將 bullet 物件的親代設到 bulletContainer 裡，所以開始時會看到 bullet 物件都被放到 bulletContainer 的 GameEmpty 理了
            bullet.transform.parent = bulletContainer.transform;

			//把生出來的 bullet 物件給狀態給關掉
			bullet.SetActive(false);

			//將 bullet 放到 bulletsList 裡面
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

		//若是 willGrow 為 true ，則 Object Pool 就可以被加大
		if(willGrow){
				GameObject bullet = Instantiate(bulletfab,Vector3.zero,Quaternion.identity) as GameObject;
	            bullet.transform.parent = bulletContainer.transform;
				bulletsList.Add(bullet);
				return bullet;
		}
		return null;
	}
}
