using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerShoot : Singleton<PlayerShoot>
{
    public GameObject bullet;
    public GameObject aim;
    public GunMechanics ammoCounter;
    public SpriteRenderer fire;
    public GameObject gun;
    public AudioClip gunshotClip;

    private Camera cam;

    public bool mouseOnUI;

    void Start()
    {
        cam = Camera.main;
        ammoCounter = GetComponent<GunMechanics>();
        fire = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        gun = transform.GetChild(0).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Aiming();
        keyboardmouseInput();
    }

    private void Shoot()
    {
        if(ammoCounter.gunLoaded == true)
        {
            Instantiate(bullet, (Vector2)focalPoint.Instance.transform.position, focalPoint.Instance.transform.rotation);
            //deduct bullet count
            ammoCounter.ammo--;
            //fire flames show
            showFire();
            AudioSource.PlayClipAtPoint(gunshotClip, transform.position);
        }
    }
    private void showFire()
    {
        fire.gameObject.SetActive(true);
        Invoke("hideFire", 0.08f);
        Invoke("hideGun", 1.2f);
    }

    private void hideFire()
    {
        fire.gameObject.SetActive(false);
    }

    private void showGun()
    {
        gun.SetActive(true);
    }

    private void hideGun()
    {
        gun.SetActive(false);
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
                showGun();
                sloMo();
            }
            else if(touch.phase == TouchPhase.Ended && !mouseOnUI)
            {
                Shoot();
                NotsloMo();
            }
            else if (touch.phase == TouchPhase.Ended && mouseOnUI)
            {
                Shoot();
                NotsloMo();
            }
        }
    }

    private void keyboardmouseInput()                       //for MOUSE
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        aim.transform.position = mousePosition;

        if (Input.GetButtonDown("Fire1") && !mouseOnUI)
        {
            showGun();
            sloMo();
        }
        if (Input.GetButtonUp("Fire1") && !mouseOnUI)
        {
            Shoot();
            NotsloMo();
        }
    }

    private void sloMo()
    {
        Time.timeScale = 0.35f;
        aim.gameObject.SetActive(true);
    }
    private void NotsloMo()
    {
        Time.timeScale = 1.0f;
        aim.gameObject.SetActive(false);
    }


}
