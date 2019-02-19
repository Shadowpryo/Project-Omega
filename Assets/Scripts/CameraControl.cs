using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    Vector2 rotation = new Vector2(0, 0);
    public float speed = 3;
    public Vector3 offset;
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        offset = transform.position - player.transform.position;
    }


    private void Update()
    {

        Vector3 mouse = Input.mousePosition;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(
                                                        mouse.x,
                                                        mouse.y,
                                                        player.transform.position.y));
        Vector3 forward = mouseWorld - player.transform.position;
        player.transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
        
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * speed;

    }

    private void LateUpdate()
    {
        //transform.position = player.transform.position + offset;
    }
}
