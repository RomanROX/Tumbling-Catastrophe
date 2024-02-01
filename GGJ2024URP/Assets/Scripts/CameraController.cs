using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public Transform rootTansform;

    float mouseX, mouseY;

    public float stomachOffset;

    public ConfigurableJoint hipConfigJoint, stomachConfigJoint;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY += Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        Quaternion rootRotation = Quaternion.Euler(mouseY, mouseX, 0);

        rootTansform.rotation = rootRotation;

        hipConfigJoint.targetRotation = Quaternion.Euler(0, -mouseX, 0);
        stomachConfigJoint.targetRotation = Quaternion.Euler(
            mouseY + stomachOffset, 0, 0);
    }
}