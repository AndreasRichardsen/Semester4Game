using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    public Transform lookAt;
    public Transform camTransform;

    Camera cam;

    float smoothing = 5f;
    float distance = 10f;
    float currentX = 0f;
    float currentY = 50f;
    float sensitivityX = 10f;
    float sensitivityY = 5f;

    void Start()
    {
        camTransform = transform;
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY -= Input.GetAxis("Mouse Y");
    }

    void LateUpdate()
    {
        Vector3 dir = new Vector3(0f, 0f, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0f);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
