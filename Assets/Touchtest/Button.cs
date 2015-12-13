using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public Color defaultcolor;
    public Color selectcolor;

    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
	void OnTouchDown()
    {
        mat.color = selectcolor;
    }
    void OnTouchUp()
    {
        mat.color = defaultcolor;
    }
    void OnTouchStay()
    {
        mat.color = selectcolor;
    }
    void OnTouchExit()
    {
        mat.color = defaultcolor;
    }
}
