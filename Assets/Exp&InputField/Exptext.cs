using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Exptext : MonoBehaviour {

    public Text expTxt;
    public Text levelTxt;
    public Text expFloor;
    public InputField inputExp;

    private float exp;//玩家現有經驗值
    private float maxExp;//所需經驗值
    private float maxExpGrow;//所需經驗值成長倍率
    private int floor;//經驗值倍率階層
    private int level;//等級
    // Use this for initialization
    void Start () {
        exp = 0;
        maxExp = 100;
        maxExpGrow = 100;
        floor = 1;
        level = 1;
        setText();
    }

	// Update is called once per frame
	void Update () {
        //若是玩家經驗值大於所需經驗值，玩家經驗值就會減去上一次的所需經驗值
        //然後所需經驗值會成長，等級會增加
        if(exp >= maxExp){
            exp = exp - maxExp;
            maxExp = maxExp + maxExpGrow;
            level++;
            //若是等級能夠被一個等級階層，例如下面的10等，階層就會增加並且增加經驗值倍率
            if((level % 10) == 0){
                floor++;
                maxExpGrow = maxExpGrow * floor;
            }
        }
        setText();
    }

    public void expPlus(int minu_){
        minu_ = int.Parse(inputExp.text);//使用 int.Parse() 來將 String 轉換為 Int32
        if (minu_ < 0) return; //經驗值輸入小於 0 則不會有反應
        exp = exp + minu_;
    }

    void setText(){
        expTxt.text = exp.ToString("F" + 0) + "/" + maxExp.ToString("F" + 0);
        levelTxt.text = "LV: " + level.ToString();
        expFloor.text = "第 " + floor.ToString() + " 階經驗值倍率";
    }
}
