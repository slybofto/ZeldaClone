using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;
    public float speed = 6.0f;
    // public float turnSmoothTime = 0.6f;  
    // float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        // combines horizontal + vert directional data into a single vec3 object
        float horizontal = Input.GetAxisRaw("Horizontal"); 
        float vertical = Input.GetAxisRaw("Vertical"); 
        Vector3 direction = new Vector3(horizontal, 0.0f, vertical).normalized;

        // checks if w, a, s, d is pressed down (this would increases magnitude from 0 to 1)
        if(direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime );
            transform.rotation = Quaternion.Euler(0.0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime); 
        }
    }
}
