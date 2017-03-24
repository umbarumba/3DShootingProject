using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public float RotMaxX = 60f;
    public float RotMaxY = 120f;
    private float AxisX;

    private float _CanShot = 0;
    //private float AxisY;

    public GameObject BulletPrefab;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        AxisX = Input.GetAxis("Horizontal2") * 0.5f;
        //AxisY = Input.GetAxis("Vertical2") * 0.5f;

        //Debug.Log(AxisX + "," + AxisY);

        //float RotationX = RotMaxX * AxisY;
        float RotationY = RotMaxY * AxisX;

        this.transform.localRotation = Quaternion.Euler(0, RotationY, 0f);

        if (Input.GetButton("R2"))
        {
            _CanShot += 1;
            Shot(_CanShot);
        } else
        {
            _CanShot = 0;
        }
    }

    void Shot (float ShotTime)
    {
        if (ShotTime == 1)
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
        }
    }
}
