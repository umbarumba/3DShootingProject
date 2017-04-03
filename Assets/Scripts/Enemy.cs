using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float speed = 3f;
    private float rotationSmooth = 1f;

    private Vector3 targetPosition;

    private float changeTargetSqrDistance = 40f;

    private Transform player;

    private Transform muzzle;
    public GameObject bulletPrefab;

    private float attackInterval = 0.5f;
    private float turretRotationSmooth = 0.8f;
    private float lastAttackTime;

    private float attackSqrDistance = 300f;
    private float pursuitSqrDistance = 1000f;

    private bool _chaseBool;

    //private RaycastHit hit;

	// Use this for initialization
	void Start () {

        targetPosition = GetRandomPositionOnLevel();

        player = GameObject.FindWithTag("Player").transform;

        muzzle = GameObject.FindWithTag("Muzzle").transform;
		
	}
	
	// Update is called once per frame
	void Update () {

        //Loitering();
        //Chasing();
        //Attack();

        //Ray ray = new Ray(transform.position, transform.forward);
        //if (Physics.Raycast(ray, out hit, 5.0f))
        //{
            

        //}

        _chaseBool = true;

        float sqrDistanceToPlayer = Vector3.SqrMagnitude(transform.position - player.position);
        Debug.Log(sqrDistanceToPlayer);
        if(sqrDistanceToPlayer < attackSqrDistance)
        {
            _chaseBool = false;
            Attack();
        }

        if (sqrDistanceToPlayer > pursuitSqrDistance)
        {
            _chaseBool = false;
            Loitering();
        }

        if(_chaseBool == true)
        {
            Chasing();
        }
	}

    public void Loitering ()
    {
        float sqrDistanceToTarget = Vector3.SqrMagnitude(transform.position - targetPosition);
        if (sqrDistanceToTarget < changeTargetSqrDistance)
        {
            targetPosition = GetRandomPositionOnLevel();
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public Vector3 GetRandomPositionOnLevel()
    {
        float levelSize = 55f;
        return new Vector3(Random.Range(-levelSize, levelSize), 0, Random.Range(-levelSize, levelSize));
    }

    public void Chasing ()
    {
        Debug.Log("Chasing" + player.transform.position);
        //Quaternion TargetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, Time.deltaTime * rotationSmooth);

        transform.LookAt(player);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void Attack()
    {
        transform.LookAt(player);

        if(Time.time > lastAttackTime + attackInterval)
        {
            Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            lastAttackTime = Time.time;
        }
    }
}
