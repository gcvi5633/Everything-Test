using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;

public class ReadJson : MonoBehaviour {
    private string jsonString;
    private JsonData itemData;
	// Use this for initialization
	void Start () {
        jsonString = File.ReadAllText(Application.dataPath + "/test1.json");
        itemData = JsonMapper.ToObject(jsonString);

        Debug.Log(itemData);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
