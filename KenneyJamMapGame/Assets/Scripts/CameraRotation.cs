using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float sensitivity = 5.0f;
    private Quaternion idleRotation;

    private void Awake()
    {
        idleRotation = transform.rotation;
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.eulerAngles += sensitivity * new Vector3(0, Input.GetAxis("Mouse X"), 0);
        }
        if (!Input.GetMouseButton(1))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, idleRotation, sensitivity*Time.deltaTime);
        }
    }
}
