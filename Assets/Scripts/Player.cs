using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    ///public float jumpforce;
    public float Speed;
    public float RotationSpeed;
    private float AxisLR = 0f;
    //public GameObject BulletPrefab;
    //public float Gravity;
    private Rigidbody RB;
    public Vector3 PlayerVel;

	// Use this for initialization
	void Start () {
        //重力を強くする
        //Physics.gravity = new Vector3(0, Gravity * -1f, 0);

        RB = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        PlayerVel = RB.velocity;

        AxisLR = 0;
        if (Input.GetButton("L1"))
        {
            AxisLR = -1;
        }
        if(Input.GetButton("R1"))
        {
            AxisLR = 1;
        }

        float translationZ = Input.GetAxis("Vertical") * Speed;
        float translationX = Input.GetAxis("Horizontal") * Speed;
        
        float rotation = AxisLR * RotationSpeed;
        translationZ *= Time.deltaTime;
        translationX *= Time.deltaTime;
        rotation *= Time.deltaTime;
        PlayerVel = new Vector3(translationX, 0, translationZ).normalized;
        transform.Translate(translationX, 0, translationZ);
        transform.Rotate(0, rotation, 0);

        //Spaceキーを押している間、上昇
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    RB.AddForce(transform.up * jumpforce);
        //}
	}
}
