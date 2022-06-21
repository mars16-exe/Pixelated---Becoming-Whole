using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGround : Enemy
{
    private Rigidbody2D body;
    [SerializeField] protected float spinSpeed;
    [SerializeField] private float followSpeed = 0.4f;
    //[SerializeField] private float power = 0f;

    private Transform myTransform;


    private void Awake()
    {
        Health = 100;
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 lookDirection = (PlayerShoot.Instance.transform.position - this.transform.position).normalized;

        body.AddForce(lookDirection * followSpeed);
        
    }
}
