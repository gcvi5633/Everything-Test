using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider))]
public class Slider : MonoBehaviour {

    public Transform knob;//取得一個 knob 方塊
	public TextMesh textmesh;
	public string slidername;//輸入取得這個 Slider 的名字

	public int[] valueRange;//做一個音量大小的區間
	public int decimalPlaces;//製作一個小數點後第幾位的變數
	public float initialsliderPrecent;//一開始動作時的音量大小

	private Vector3 targetPos;
	private float sliderpercent;
	private float sliderDisplayValue;
	private float sliderlenth;
	// Use this for initialization
	void Start () {
		sliderlenth = GetComponent<BoxCollider>().size.x-.2f;//讓 sliderlenth 取得 BoxCollider 的 size.x-.2f
        sliderpercent = initialsliderPrecent;
	    targetPos = knob.position + Vector3.right * (sliderlenth/-2 + sliderlenth * sliderpercent);
		knob.position = targetPos;
	}

	void Update () {
        //將 knob.position 以 Lerp 的方式做一個線性的滑動
        knob.position = Vector3.Lerp(knob.position,targetPos,Time.deltaTime * 10);

        //將 sliderpercent 使用 Mathf.Clamp01 的方法將大於 1 的值回傳 1 ，小於 0 的值回傳 0
        sliderpercent = Mathf.Clamp01((knob.localPosition.x + sliderlenth / 2) / sliderlenth);
        
        sliderDisplayValue = Mathf.Lerp(valueRange[0],valueRange[1],sliderpercent);

        //將 textmesh.text 改成 slidername 與 sliderDisplayValue 再使用 ToString("F") 轉換成小數字串，使用 decimalPlaces 來控制小數後幾位數
        textmesh.text = slidername + ": " + sliderDisplayValue.ToString("F" + decimalPlaces);
	}

	void OnTouchStay(Vector3 point){
		targetPos = new Vector3(point.x,targetPos.y,targetPos.z);
	}

	public float GetSliderPercent(){
		return sliderpercent;
	}
}
