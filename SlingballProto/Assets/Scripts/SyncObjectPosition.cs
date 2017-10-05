using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncObjectPosition : MonoBehaviour {

    public Rigidbody otherBody;
    private Rigidbody myBody;
        
	void Awake () {
        myBody = GetComponent<Rigidbody>();
        myBody.MovePosition(otherBody.position);
	}
	
	
	void FixedUpdate () {

        myBody.MovePosition(otherBody.position);


    }
}
