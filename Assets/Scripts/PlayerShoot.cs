using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject aim;

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
            Shoot();
            Time.timeScale = 1.0f;
            aim.gameObject.SetActive(false);
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, (Vector2)focalPoint.Instance.transform.position, focalPoint.Instance.transform.rotation);
    }
}
