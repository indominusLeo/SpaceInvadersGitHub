using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float startTime;

    private float velocity = 0.5f;

    private Transform enemyTransform;

    private int count;

    private float deltaTime = 1.0f;

    Animator anim;

	// Use this for initialization
	void Start () {
        count = 0;
        enemyTransform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        InvokeRepeating("enemyMovement", startTime, deltaTime);

    }
	
	void enemyMovement () {

        count++;
        anim.SetTrigger("Move");

        if (count == 18)
        {
            count = 0;
            velocity = -velocity;
            enemyTransform.position += Vector3.down * 0.5f;
            enemyTransform.position += Vector3.right * velocity;
            count++;
            CancelInvoke();
            InvokeRepeating("enemyMovement", 1, deltaTime - 0.2f);
        } else
        {
            enemyTransform.position += Vector3.right * velocity;
        }
	}
}
