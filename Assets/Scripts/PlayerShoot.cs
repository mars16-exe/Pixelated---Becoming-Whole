using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : Singleton<PlayerShoot>
{
    public GameObject bullet;
    public GameObject aim;

    private Camera cam;

    public bool mouseOnUI;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Aiming();
        //MouseInput();
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
            
            if(touch.phase == TouchPhase.Began && !mouseOnUI)
            {
                sloMo();
            }
            else if(touch.phase == TouchPhase.Ended && !mouseOnUI)
            {
                Shoot();
                NotsloMo();
            }
        }
    }

    private void MouseInput()                       //for MOUSE
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        aim.transform.position = mousePosition;

        if (Input.GetButtonDown("Fire1") && !mouseOnUI)
        {
            sloMo();
        }
        else if (Input.GetButtonUp("Fire1") && !mouseOnUI)
        {

            Shoot();
            NotsloMo();
        }
    }

    private void sloMo()
    {
        Time.timeScale = 0.3f;
        aim.gameObject.SetActive(true);
    }
    private void NotsloMo()
    {
        Time.timeScale = 1.0f;
        aim.gameObject.SetActive(false);
    }


}
