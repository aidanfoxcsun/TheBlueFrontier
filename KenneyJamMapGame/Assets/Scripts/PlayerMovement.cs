using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    GameManager gm;

    public float speed = 10.0f;
    public GameObject model;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public Vector3 buoy = new Vector3(0,0.05f,0);
    public Boolean buoyDirection = true;
    public float timeToFlip = 1.5f;

    private void Start()
    {
        gm = GameManager.Instance;
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(vertical, 0, -1 * horizontal).normalized;
        if (!gm.paused)
        {

            if (direction.magnitude >= 0.1f)
            {
                float tragetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(model.transform.eulerAngles.y, tragetAngle, ref turnSmoothVelocity, turnSmoothTime);
                model.transform.rotation = Quaternion.Euler(0, angle, 0);

                transform.position += direction * speed * Time.deltaTime;
            }

            if (buoyDirection)
            {
                model.transform.position += buoy * Time.deltaTime;
                model.transform.rotation *= Quaternion.Euler(0f, 0f, 0.015f);
            }
            else
            {
                model.transform.position -= buoy * Time.deltaTime;
                model.transform.rotation = model.transform.rotation * Quaternion.Inverse(Quaternion.Euler(0f, 0, 0.015f));
            }
            if (timeToFlip <= 0)
            {
                timeToFlip = 3f;
                buoyDirection = !buoyDirection;
            }
            timeToFlip -= Time.deltaTime;
        }

    }

    

}
