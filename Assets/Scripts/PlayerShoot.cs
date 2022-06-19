using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject aim;
    public GameObject bullet;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Time.timeScale = 0.3f;
            aim.gameObject.SetActive(true);
        }

        if(Input.GetButtonUp("Fire1"))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            Time.timeScale = 1.0f;
            aim.gameObject.SetActive(false);
        }
    }
}
