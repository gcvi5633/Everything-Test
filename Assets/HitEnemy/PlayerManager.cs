using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public Animator anim;
    public GameObject atkCollider;

    bool atk;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", v);
        anim.SetFloat("Turn", h);
        var move = new Vector3(0,0,v*Time.deltaTime);
        var rotation = new Vector3(0, h*3, 0);
        this.transform.Translate(move);
        this.transform.Rotate(rotation);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Atk",true);
            atk = true;
            Invoke("xxx",0.1f);
        }
        Atk();
    }

    void xxx()
    {
        anim.SetBool("Atk",false);
        atk = false;
    }

    void Atk()
    {
        if (atk)
            atkCollider.SetActive(true);
        else
            atkCollider.SetActive(false);
    }


}
