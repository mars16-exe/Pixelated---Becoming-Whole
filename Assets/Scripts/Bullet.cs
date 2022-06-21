using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject focalPoint;
    private float damage = 20f;
    public float Damage
    {
        get { return damage; }
        private set {}
    }


    private Rigidbody2D rbBODY;
    [SerializeField] private float power = 7000f;

    private void Awake()
    {
        rbBODY = GetComponent<Rigidbody2D>();
        focalPoint = GameObject.Find("focalPoint");
        
        rbBODY.velocity = focalPoint.transform.forward.normalized * power * Time.deltaTime;
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
