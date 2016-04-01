using UnityEngine;
using LitJson;
using System.Collections;
using System.IO;

public class JsonTest : MonoBehaviour {

    private string jsonString;
    private JsonData jsonData;

	// Use this for initialization
	void Start () {
        //jsonString = File.ReadAllText(Application.dataPath + "/Simple.json");
        //jsonData = JsonMapper.ToObject(jsonString);

        //var xxx = jsonData[0];
        //var yyy = jsonData["age"];

        //Debug.Log(xxx);
        //Debug.Log(yyy);
        PlayerStatus player = new PlayerStatus(1, 18, "John", "Freeter", false,new int[] { 3, 5, 4, 555 });
        jsonData = JsonMapper.ToJson(player);
        File.WriteAllText(Application.dataPath+"/Simple.json", jsonData.ToString());
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
