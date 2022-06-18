using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject aim;
    public GameObject bullet;
    private Bullet bulletSC;

    void Start()
    {
        bulletSC = bullet.GetComponent<Bullet>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Time.timeScale = 0.4f;
        }

        if(Input.GetButtonUp("Fire1"))
        {
            Vector2 dir = aim.transform.position - transform.position;
            bulletSC.Shoot(dir);
            Instantiate(bulletSC, transform.position, Quaternion.identity);


            Time.timeScale = 1.0f;
        }

    }
}
