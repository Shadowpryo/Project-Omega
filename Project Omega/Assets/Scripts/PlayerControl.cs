    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed;
    public float rotatinSpeed;
    public Camera cam;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    public Transform relativeTransform;
    public bool canMove;
    public bool inMenu;
    public Animator anim;
    //public string name;
    
    //basic stats
    public int MaxHP;
    public int hp;
    public int str;
    public int strMod;
    public int def;
    public int MaxEXP;
    public int EXP;
    public int Level;
    public int statPoints;
    //Easy access to block it off like this

    private Rigidbody RB;
    private GameManager GM;
    

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); 
    }

    // Use this for initialization
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        RB = GetComponent<Rigidbody>();
        canMove = false;
        hp = MaxHP;
        EXP = 0;
        Level = 1;
        name = gameObject.name;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (EXP >= MaxEXP)
        {
            Debug.Log("Congrats you Lvld up!");
            EXP = EXP - MaxEXP;
            MaxEXP = Mathf.RoundToInt(MaxEXP * 2.5f);
            hp = MaxHP;
            statPoints += 3;
            Level++;
        }
        if (GM.inGame)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                inMenu = !inMenu;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetBool("isAttacking", true);
                /*RaycastHit hit;

                Vector3 fwd = relativeTransform.forward;
                Debug.DrawRay(transform.position, fwd * 10, Color.red);
                if (Physics.Raycast(transform.position, fwd, out hit, 10))
                {
                    switch (hit.collider.gameObject.layer)
                    {
                        case 8:
                            EnemyAI EA = hit.transform.GetComponent<EnemyAI>();
                            int damage = Mathf.RoundToInt(str + strMod / EA.def);
                            EA.HP -= damage;
                            Debug.Log("Damage done is: " + damage);
                            break;
                    }
                }*/
            }
            if (Input.GetButtonUp("Fire1"))
            {
                anim.SetBool("isAttacking", false);

                /*
                RaycastHit hit;

                Vector3 fwd = relativeTransform.forward;
                Debug.DrawRay(transform.position, fwd * 10, Color.red);
                if (Physics.Raycast(transform.position, fwd, out hit, 10))
                {
                    switch (hit.collider.gameObject.layer)
                    {
                        case 8:
                            EnemyAI EA = hit.transform.GetComponent<EnemyAI>();
                            int damage = Mathf.RoundToInt(str + strMod / EA.def);
                            EA.HP -= damage;
                            Debug.Log("Damage done is: " + damage);
                            break;
                    }
                }*/
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Vector3 moveDirection = Vector3.zero;
            if (Input.GetKey(KeyCode.W)) moveDirection += relativeTransform.forward;
            if (Input.GetKey(KeyCode.S)) moveDirection += -relativeTransform.forward;
            if (Input.GetKey(KeyCode.A)) moveDirection += -relativeTransform.right;
            if (Input.GetKey(KeyCode.D)) moveDirection += relativeTransform.right;

            moveDirection.y = 0f;

            transform.position += moveDirection.normalized * speed * Time.deltaTime;
            anim.SetFloat("walking", -1);

            if (moveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(moveDirection), rotatinSpeed * Time.deltaTime);
                anim.SetFloat("walking", 1);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "PickUpCollider")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Weapons weapon = other.GetComponentInParent<Weapons>();
                Transform hand = GameObject.Find("mixamorig:RightHandIndex1").GetComponent<Transform>();
                other.gameObject.SetActive(false);
                weapon.transform.parent = hand.transform;
                weapon.transform.position = new Vector3(hand.position.x, hand.position.y, hand.position.z+.3f);
                //weapon.transform.position = new Vector3(-.104f, -.035f, -.413f);
                weapon.transform.Rotate(new Vector3(90, 35, 0));
                //weapon.transform.Rotate(-90, 0, 0);
                //weapon.gameObject.SetActive(false);
                strMod += weapon.str;
                weapon.owner = gameObject;
                //Destroy(other.gameObject);

            }
        }
    }

    private void OnGUI()
    {
        if (GM.inGame)
        {
            GUI.skin.textField.wordWrap = true;
            if (inMenu)
            {
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 150, 100, 25),
                    string.Format("Stat Points: " + statPoints));
                GUI.Box(new Rect(Screen.width / 2, Screen.height / 2 - 150, 100, 25),
                    string.Format("Level: " + Level));
                GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 100, 25),
                    string.Format("Health: " + MaxHP));
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 - 100, 100, 25),
                    string.Format("Upgrade health?")))
                {
                    if (statPoints >= 1)
                    {
                        MaxHP = MaxHP + 10;
                        hp = MaxHP;
                        statPoints--;
                    }
                    else
                        Debug.Log("You don't have any stat points!");
                }
                GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 100, 25),
                    string.Format("Strenght: " + str));
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 - 50, 100, 25),
                    string.Format("Upgrade Strenght?")))
                {
                    if (statPoints >= 1)
                    {
                        str = str + 2;
                        statPoints--;
                    }
                    else
                        Debug.Log("You don't have any stat points!");
                }
                GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2, 100, 25),
                    string.Format("Defence: " + def));
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 25),
                    string.Format("Upgrade Defence?")))
                {
                    if (statPoints >= 1)
                    {
                        def = def + 2;
                        statPoints--;
                    }
                    else
                        Debug.Log("You don't have any stat points!");
                }
            }
            else
            {
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }
}
