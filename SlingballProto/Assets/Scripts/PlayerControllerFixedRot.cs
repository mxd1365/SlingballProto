using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFixedRot : MonoBehaviour {

    private Rigidbody rigBody;

    public float rotSpeed = 100f;
    public float thrustSpeed = 1000f;
    public float airBrakeDrag = 2f;
    public float floatDrag = 0f;
    public float maxSpeed = 1000f;

    public float jukeStrength = 100f;

	// Use this for initialization
	void Awake () {
        rigBody = GetComponent<Rigidbody>();
        rigBody.freezeRotation = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float yaw = Input.GetAxis("Horizontal");
        float pitch = Input.GetAxis("Vertical");
        
        Quaternion curRot = rigBody.rotation;
        Quaternion target = Quaternion.Euler(curRot.eulerAngles.x + (pitch * rotSpeed * Time.fixedDeltaTime), curRot.eulerAngles.y + (yaw * rotSpeed * Time.fixedDeltaTime), curRot.eulerAngles.z);
        
        rigBody.MoveRotation(target);

        if(Input.GetButton("Thrust"))
        {
            rigBody.AddRelativeForce(0f, 0f, thrustSpeed * Time.fixedDeltaTime);
        }

        if(Input.GetButton("AirBrakes"))
        {
            rigBody.drag = airBrakeDrag;
        }
        else
        {
            rigBody.drag = floatDrag;
        }
        
        if(Input.GetButtonDown("JukeRight"))
        {
            rigBody.AddRelativeForce(jukeStrength, 0f, 0f);
        }

        if(Input.GetButtonDown("JukeLeft"))
        {
            rigBody.AddRelativeForce(-jukeStrength, 0f, 0f);
        }

        //slow down
        float speed = rigBody.velocity.magnitude;

        Debug.Log("Speed:" + speed);
        if(speed > maxSpeed)
        {
            float brakeSpeed = speed - maxSpeed;
            Vector3 normVelocity = rigBody.velocity.normalized;
            Vector3 brakeVelocity = -(normVelocity * brakeSpeed);
            rigBody.AddForce(brakeVelocity);
        }
	}
}
