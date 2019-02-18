    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed;
    public float rotatinSpeed;

    private Rigidbody RB;
    private GameManager GM;

    // Use this for initialization
    void Start()
    {
        //GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        RB = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        float foreAndAft = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotatinSpeed;
        RB.AddRelativeForce(0, 0, foreAndAft);
        RB.AddTorque(0, rotation, 0);

    }
}
