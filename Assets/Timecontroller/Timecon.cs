using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timecon : MonoBehaviour {
    public float tc;//看是要幾秒  #Timecontroller
    public Text time;
    int min;
    int sec;
    // Use this for initialization
    void Start() {

            }

    // Update is called once per frame
    void Update()
    {
        //當時間是設在零秒以上時，才會動作
        if (tc > 0)
            Timer();
    }

    public void Timer()
    {
        tc -= Time.deltaTime;
        sec = (int)tc;//將 int 型態的 tc設成 sec
        min = sec / 60;
        sec = sec % 60;
        if (sec % 60 < 10)
            time.text = min.ToString() + ":0" + sec.ToString();
        else
            time.text = min.ToString() + ":" + sec.ToString();
    }
}
