using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
    
    Animator anim;
    bool damage;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
        Damage();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Atk"))
        {
            damage = !damage;
        }
    }

    void Damage() {
        if (damage) {
            anim.SetBool("Damage" , true);
            damage = !damage;
        } else {
            anim.SetBool("Damage" , false);
        }
    }
}
