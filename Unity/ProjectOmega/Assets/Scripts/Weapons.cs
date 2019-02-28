using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {
    public int str;
    //Don't have to but here
    public int durability;
    public GameObject owner;
    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("attackign"))
        {
            anim.SetBool("attacking", false);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(owner != null && other.gameObject != owner)
        {
            if (owner.gameObject.GetComponent<PlayerControl>())
            {
                PlayerControl PC = owner.gameObject.GetComponent<PlayerControl>();
                EnemyAI EA = other.GetComponent<EnemyAI>();
                int damage = Mathf.RoundToInt(str + PC.strMod / EA.def);
                EA.HP -= damage;
                Debug.Log("Damage done is: " + damage);
                anim.SetBool("attacking", false);
            }
        }
    }
}
