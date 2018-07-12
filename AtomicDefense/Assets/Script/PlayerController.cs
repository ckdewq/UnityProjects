using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour {

    Rigidbody myRigidbody;
    Vector3 velocity;
	// Use this for initialization

	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Lookat(Vector3 _point)
    {
        Vector3 heightCorrectedPoint = new Vector3(_point.x, transform.position.y, _point.z);
        transform.LookAt(heightCorrectedPoint);
    }

    private void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
