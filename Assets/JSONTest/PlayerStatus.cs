using UnityEngine;
using System.Collections;

public class PlayerStatus {
    public int id;
    public int age;
    public string name;
    public string job;
    public bool happy;
    public int[] stats;

    public PlayerStatus(int id, string name, bool happy) {
        Debug.Log(id);
        Debug.Log(name);
        Debug.Log(happy);
    }

    public PlayerStatus(int id,int age, string name,string job, bool happy,int[] stats) {
        this.id = id;
        this.age = age;
        this.name = name;
        this.job = job;
        this.happy = happy;
        this.stats = stats;
    }
}
