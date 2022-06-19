using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject aim;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Aiming();
    }

    private void Shoot()
    {
        Instantiate(bullet, (Vector2)focalPoint.Instance.transform.position, focalPoint.Instance.transform.rotation);
    }

    private void Aiming()                           //for TOUCH
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 aimPosition = cam.ScreenToWorldPoint(touch.position);
            aim.transform.position = aimPosition;
            
            if(touch.phase == TouchPhase.Began)
            {
                Time.timeScale = 0.3f;
                aim.gameObject.SetActive(true);
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                Shoot();
                Time.timeScale = 1.0f;
                aim.gameObject.SetActive(false);
            }
        }
    }

    //private void Clicking()                       //for MOUSE
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        Time.timeScale = 0.3f;
    //        aim.gameObject.SetActive(true);
    //    }
    //}

    //private void Releasing()                      //For MOUSE
    //{
    //    if (Input.GetButtonUp("Fire1"))
    //    {
    //        Shoot();
    //        Time.timeScale = 1.0f;
    //        aim.gameObject.SetActive(false);
    //    }
    //}
}
