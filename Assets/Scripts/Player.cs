using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float jumpforce;
    public float Speed;
    public float RotationSpeed;
    public float Gravity;
    public Rigidbody RB;

	// Use this for initialization
	void Start () {
        Physics.gravity = new Vector3(0, Gravity * -1f, 0);
        RB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float translation = Input.GetAxis("Vertical") * Speed;
        float rotation = Input.GetAxis("Horizontal") * RotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        //Spaceキーを押している間、上昇
        if (Input.GetKey(KeyCode.Space))
        {
            RB.AddForce(transform.up * jumpforce);
        }

	}
}
