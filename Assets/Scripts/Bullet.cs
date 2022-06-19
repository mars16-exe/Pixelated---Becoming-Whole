using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject focalPoint;


    private Rigidbody2D rbBODY;
    [SerializeField] private float power = 400f;

    private void Awake()
    {
        rbBODY = GetComponent<Rigidbody2D>();
        focalPoint = GameObject.Find("focalPoint");
        
        rbBODY.velocity = focalPoint.transform.forward * power * Time.deltaTime;
        //BulletSound()
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBullet();
        //BulletEffect()
    }

    void DestroyBullet()
    {
        Destroy(transform.parent.gameObject);
    }


}
