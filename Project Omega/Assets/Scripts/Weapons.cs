using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {
    public int str;
    //Don't have to but here
    public int durability;
    public GameObject owner;


    private void OnTriggerEnter(Collider other)
    {
        if(owner != null && other.gameObject != owner)
        {
            if (owner.gameObject.GetComponent<PlayerControl>())
            {
                PlayerControl PC = owner.gameObject.GetComponent<PlayerControl>();
                EnemyAI EA = other.GetComponent<EnemyAI>();
                int damage = Mathf.RoundToInt(str + PC.str / EA.def);
                EA.HP -= damage;
                Debug.Log("Damage done is: " + damage);
            }
        }
    }
}
