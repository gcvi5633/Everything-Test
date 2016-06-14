using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public Transform sword;
    public Transform rightHandPos;

    public GameObject swordCollider;

    public float distance;
    public float maxDis;
    public float minDis;
    public float speed;
    Animator anim;

    GameObject target;

    bool canAttack = true;
    bool damage;
    // Use this for initialization

    AnimatorStateInfo currentBaseState;

    int idleState = Animator.StringToHash("Base Layer.attackstanceidle");
    int walkState = Animator.StringToHash("Base Layer.attackwalkforward");
    int attackState = Animator.StringToHash("Base Layer.attack3front");
    int gethurtState = Animator.StringToHash("Base Layer.attackgethit");

    void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        equipSword();
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate() {
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        
        Attack();
        GetHurt();
        Idle();
        Targeted();
        SwordCollider();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Atk"))
        {
            anim.Play("attackgethit");
        }
    }
    void SwordCollider() {
        if (currentBaseState.nameHash == attackState) {
            swordCollider.SetActive(true);
        } else {
            swordCollider.SetActive(false);
        }
    }

    void Attack() {
        if(currentBaseState.nameHash != attackState && currentBaseState.nameHash != walkState) {
            if (canAttack) {
                {
                    anim.Play("attack3front");
                }
            }
        }
    }

    void GetHurt() {
        if (currentBaseState.nameHash == gethurtState) {
            canAttack = false;
        }
    }

    void Idle() {
        if(currentBaseState.nameHash == idleState) {
            canAttack = true;
        }
    }
    void Targeted() {
        distance = Vector3.Distance(transform.position , target.transform.position);
        if (distance > maxDis) {
            canAttack = false;
        }
        if (distance < maxDis && distance > minDis) {
            if (currentBaseState.nameHash != walkState && currentBaseState.nameHash != attackState) {
                anim.Play("attackwalkforward");
            }
            transform.LookAt(target.transform);
            if (currentBaseState.nameHash != attackState) {
                transform.position = Vector3.MoveTowards(transform.position , target.transform.position , speed * Time.deltaTime);
            }
        } else {
            if (currentBaseState.nameHash == walkState) {
                anim.Play("attackstanceidle");
            }
        }
    }

    void equipSword() {
        sword.parent = rightHandPos;
        sword.position = rightHandPos.position;
        sword.rotation = rightHandPos.rotation;
    }
}
