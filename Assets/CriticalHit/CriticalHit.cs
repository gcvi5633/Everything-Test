using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CriticalHit : MonoBehaviour {

    
    public Text criticalHitText;
    public float percent;
    float ramdomValue;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            xxx();
    }
    void xxx() {
        ramdomValue = Random.Range(0, 99);
        CriticalHitView();
    }

    void CriticalHitView() {
        if(ramdomValue<=percent)
            criticalHitText.text = "Critical Hit!!";
        else if(ramdomValue>percent)
            criticalHitText.text = "Normal Hit!!";
        Debug.Log(ramdomValue);
    }
}
