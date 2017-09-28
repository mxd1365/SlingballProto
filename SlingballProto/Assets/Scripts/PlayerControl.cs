using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed = 3f;
    public float turnSpeed = 3f;
    public float maxVel = 100;
    private Rigidbody rigBody;

    private float pitch;
    private float yaw;

	void Awake () {
        rigBody = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {

        pitch = Input.GetAxis("Horizontal");
        yaw = Input.GetAxis("Vertical");

        rigBody.AddRelativeTorque(yaw * turnSpeed, pitch * turnSpeed, 0);

        if(Input.GetMouseButton(0))
        {
            if (rigBody.velocity.magnitude <= maxVel)
            {
                rigBody.AddRelativeForce(0, 0, speed);
            }
        }

        //Level out
      
    }
}
