using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour {

    private Rigidbody rigBody;

    public float rotSpeedMax = 10.0f;
    public float rotSpeedMin = .2f;
    public float thrust = 10f;
    private float pitch;
    private float yaw;


	void Awake () {
        rigBody = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {

        yaw = Input.GetAxis("Horizontal");
        pitch = Input.GetAxis("Vertical");
        if(Input.GetButton("Thrust"))
        {
            rigBody.AddRelativeForce(0f, 0f, thrust);
        }
        Debug.Log(pitch);

        rigBody.AddRelativeTorque(pitch, yaw, 0);

        if(pitch == 0 && yaw == 0)
        {
            float rotSpeed = Vector3.Angle(transform.up, Vector3.up);
            rotSpeed = (rotSpeed / 180f) * rotSpeedMax;
            rotSpeed = Mathf.Clamp(rotSpeed, rotSpeedMin, rotSpeedMax);
            rigBody.rotation =  Quaternion.RotateTowards(rigBody.rotation, Quaternion.LookRotation(transform.forward, Vector3.up), rotSpeed);

        }
    
    }
}
