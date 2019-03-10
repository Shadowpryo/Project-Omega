using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonCam : MonoBehaviour {

    public Transform player;
    private Camera cam;
    //public Transform camTransform;

    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensivityX = 4.0f;
    private float sensivityY = 2.0f;

    private const float yAngleMin = 0.0f;
    private const float yAngleMax = 50.0f;

    public Vector3 offset;
    public Vector3 rotateOffset;

    private void Start()
    {
        //camTransform = transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cam = Camera.main;
        offset = transform.position - player.transform.position;

    }
    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensivityX;
        currentY += Input.GetAxis("Mouse Y") * sensivityY;

        currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -50 * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, 50 * Time.deltaTime);
    }
    void LateUpdate()
    {
        if (Input.GetButton("Fire2"))
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 4, Vector3.up) * offset;
            transform.position = player.position + offset;
            transform.LookAt(player.position);
        }
        else
        {
            // Calculate the current rotation angles
            float wantedRotationAngle = player.eulerAngles.y;
            float wantedHeight = player.position.y + offset.y;

            float currentRotationAngle = transform.eulerAngles.y;
            float currentHeight = transform.position.y;

            // Damp the rotation around the y-axis
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, 3 * Time.deltaTime);

            // Damp the height
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, 2 * Time.deltaTime);

            // Convert the angle into a rotation
            var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            // Set the position of the camera on the x-z plane to:
            // distance meters behind the target
            transform.position = player.position;
            transform.position -= currentRotation * Vector3.forward * 4.41f;

            // Set the height of the camera
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

            // Always look at the target
            transform.LookAt(player);
        }
    }
}
