using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public PlayerControl PC;
    public NavMeshAgent agent;
    //public GameObject coin;
    public GameManager GM;
    public int MaxHP;
    public int HP;
    public int str;
    public int def;
    public float dist;
    public bool isAttacking = false;

    // Use this for initialization
    void Start()
    {
        if (MaxHP == 0)
            Debug.LogError("Need to set MaxHP");
        else
            HP = MaxHP;
        if (str == 0)
            Debug.LogError("Need to set STR");
        if (def == 0)
            Debug.LogError("Need to set DEF");
        player = GameObject.FindGameObjectWithTag("Player");
        PC = player.GetComponent<PlayerControl>();
        agent = GetComponent<NavMeshAgent>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP >= 1)
        {
            dist = Vector3.Distance(transform.position, player.transform.position);
            if (dist <= 3 && !isAttacking)
                StartCoroutine(Attack());
            else
            {
                FollowPlayer(dist);
                StopCoroutine(Attack());
            }
        }
        else
        {
            PC.EXP += 3;
            //Instantiate(GM.money, transform.position, Quaternion.identity); will be made to code in droppable loot
            Destroy(gameObject);
        }
    }

    public void FollowPlayer(float distn)
    {
        agent.SetDestination(player.transform.position);
        if (distn >= 10)
        {
            if (agent.path.status != NavMeshPathStatus.PathPartial)
            {
                agent.isStopped = false;
                agent.speed = 13;
            }
        }
        else if (distn >= 3)
        {
            if (agent.path.status != NavMeshPathStatus.PathPartial)
            {
                agent.isStopped = false;
                agent.speed = 6f;
            }
        }
        else
        {
            Vector3 lookPOS = (player.transform.position - transform.position).normalized;
            Quaternion lookROT = Quaternion.LookRotation(lookPOS);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookROT, Time.deltaTime * 10);
            agent.isStopped = true;
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(.3f);
        int damage = Mathf.RoundToInt(str / PC.def);
        Debug.Log("Mob does " + damage + " damage to player");
        PC.hp -= damage;
        yield return new WaitForSeconds(.3f);
        isAttacking = false;
    }
}

