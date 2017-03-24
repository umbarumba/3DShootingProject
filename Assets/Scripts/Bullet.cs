using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float T = 0.0f;
    private float DeleteTime = 5.0f;
    private Rigidbody RB;
    private float speed = 1000;
    private Player PlayerScript;

	// Use this for initialization
	void Start () {

        PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        RB = GetComponent<Rigidbody>();
        RB.velocity = PlayerScript.PlayerVel;
        RB.AddForce(transform.forward * speed);
		
	}
	
	// Update is called once per frame
	void Update () {
        T += Time.deltaTime;
        if (T >= DeleteTime)
        {
            Destroy(gameObject);
        }

    }
}
