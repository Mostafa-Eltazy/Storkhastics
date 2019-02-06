using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonCameraWithRotation : MonoBehaviour {
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 30.0f;

    public Transform lookat;
    public Transform camertransform;

    public float rotatespeed;

    public float distance = 5.0f;
    public float currentX = 0.0f;
    public float currentY = 0.0f;
    public float SenstivityX = 4.01f;
    public float SentivityY = 1.01f;


    void Start()
    {

        camertransform = transform;


    }

    // Update is called once per frame
    void Update()
    {
        currentY += Input.GetAxis("Mouse X");
        currentX += Input.GetAxis("Mouse Y");
        currentX = Mathf.Clamp(currentX, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        /////////////////////////////////////////////////
        float horizontal = Input.GetAxis("Mouse X") * rotatespeed;
        lookat.transform.Rotate(0, horizontal, 0);
        float desiredAngle = lookat.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(currentX, currentY, 0);
        /////////////////////////////////////////////////
        camertransform.position = lookat.position + rotation * dir;
        camertransform.LookAt(lookat.position);
    }
}
