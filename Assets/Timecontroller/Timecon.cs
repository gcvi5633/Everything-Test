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
        //使用 ToString("D2") 的方法來使輸出的時間數字保持有兩位數位置
        time.text = min.ToString("D2") + ":" + sec.ToString("D2");
    }
}
