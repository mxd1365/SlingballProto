using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed = 45f;
    public float turnSpeed = 1f;
    public float maxVel = 100;
    public float levelRangeMin = 10;
    public float levelRangeHalf = 180;

    private Rigidbody rigBody;


    private float pitch;
    private float yaw;


	void Awake () {
        rigBody = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        
        pitch = Input.GetAxis("Horizontal");
        yaw = Input.GetAxis("Vertical");
        float roll = 0;
        if(Input.GetKey(KeyCode.E))
        {
            roll = 1;
        }

        rigBody.AddRelativeTorque(yaw * turnSpeed, pitch * turnSpeed, roll * turnSpeed);

        if(Input.GetButton("Fire1"))
        {
            if (rigBody.velocity.magnitude <= maxVel)
            {
                rigBody.AddRelativeForce(0, 0, speed);
            }
        }

        Debug.Log("Speed:" + rigBody.velocity.magnitude);

    
    }
}
