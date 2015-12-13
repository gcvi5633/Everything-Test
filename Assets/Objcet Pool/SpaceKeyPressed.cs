using UnityEngine;
using System.Collections;

public class SpaceKeyPressed : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//使用Unity內Ray變數將Camera位置到滑鼠位置轉換成一條3D射線
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))//將射線投到物件上，這裡使用物件的Tag名稱以及是否按下滑鼠左鍵作為判斷
        {
	    if(Input.GetMouseButton(0)){
			GameObject obj = Poolmanager._istance.GetPooledObject();
			if(obj == null)return;
			obj.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
			obj.SetActive(true);
			}
			//check the pool list to see if any item are "INACTIVE"
			//set active true
		}
	}
}
