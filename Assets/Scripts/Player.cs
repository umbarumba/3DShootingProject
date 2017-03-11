using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody RB;

    public float Speed = 20f;
    public float RotationSpeed = 100f;
    public float jumpforce = 10f;

	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody>();
        //Physics.gravity = new Vector3(0f, -10f, 0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int count = 0;
            count++;
            Debug.Log(count);
            RB.AddForce (transform.up * jumpforce);
        }

        float Moveforward = Input.GetAxis("Vertical") * Speed;
        float Rotation = Input.GetAxis("Horizontal") * RotationSpeed;
        Rotation *= Time.deltaTime;
        RB.velocity = transform.forward * Moveforward;
        transform.Rotate(0f, Rotation, 0f);
	}
}
