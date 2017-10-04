using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFixedRot : MonoBehaviour {

    private Rigidbody rigBody;

    public float rotSpeed = 100f;
    public float thrustSpeed = 1000f;
    public float airBrakeDrag = 2f;
    public float floatDrag = 0f;

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
        Debug.Log(target);
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
        
	}
}
