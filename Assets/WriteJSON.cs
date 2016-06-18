using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.IO;
using LitJson;

public class WriteJSON : MonoBehaviour {
    public Character player;
    public int id;
    public new string name;
    public int health;
    public bool aggresive;
    public int str, agi, def;
    public string saveFileName;
    JsonData playerJson;
    // Use this for initialization
    void Start() {
        Debug.Log(PlayerPrefs.GetString("test1"));
    }
	
	// Update is called once per frame
	void Update () {
       
        
    }

    public void DateSave(string saveFileName/*int id, string name, int health, bool aggresive , int str, int agi, int def*/) {
        int[] stats ={ str, def, agi };
        player = new Character(id, name, health, aggresive, stats);
        playerJson = JsonMapper.ToJson(player);
        File.WriteAllText(Application.dataPath + "/" + saveFileName + ".json", playerJson.ToString());
        Debug.Log("Save!");
        var hash = GetHash(saveFileName);

        PlayerPrefs.SetString(saveFileName, hash);
    }
    public string GetHash(string saveFileName) {
        FileStream f = new FileStream(Application.dataPath + "/" + saveFileName + ".json", FileMode.Open);
        MD5 m = MD5.Create();
        byte[] hashID = m.ComputeHash(f);
        string str = "";
        foreach (byte b in hashID) {
            str += b.ToString();
        }
        Debug.Log("Hash ID: "+str);
        f.Close();//關閉文件讀取
        return str;
    }
    public void VerifyMD5Hash(string saveFileName) {
        var oldHash = PlayerPrefs.GetString(saveFileName);
        var newHash = GetHash(saveFileName);
        if(oldHash == newHash) {
            Debug.Log("Yes You Can!");
        } else {
            Debug.Log("No I Can't!");
            return;
        }
        Debug.Log("Load Data....");
    }

}

public class Character {
    public int id { get; set; }
    public string name { get; set; }
    public int health { get; set; }
    public bool aggresive { get; set; }
    public int[] stats { get; set; }

    public Character(int id,string name,int health,bool aggresive, int[] stats) {
        this.id        = id       ;
        this.name      = name     ;
        this.health    = health   ;
        this.aggresive = aggresive;
        this.stats     = stats    ;
        for(int i =0;i<stats.Length;i++) {
            this.stats[i] = stats[i];
        }
    }
}

public class Stats {
    public int Str { get; set; }
    public int Def { get; set; }
    public int Agi { get; set; }

    public Stats(int str, int def, int agi) {
        this.Str = str;
        this.Def = def;
        this.Agi = agi;
    }
}
