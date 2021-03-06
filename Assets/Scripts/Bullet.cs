using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 60;
    public int Damage
    {
        get { return damage; }
        private set {}
    }


    private Rigidbody2D rbBODY;
    [SerializeField] private float power = 2500f;

    private void Awake()
    {
        rbBODY = GetComponent<Rigidbody2D>();
        
        rbBODY.velocity = focalPoint.Instance.transform.forward.normalized * power * Time.deltaTime;
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
