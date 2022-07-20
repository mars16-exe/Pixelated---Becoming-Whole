using UnityEngine;

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

    [Header("For Debug - SLOWMOindicator")]
    public SLOWMOindicator indicator;

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
        if(GameManager.Instance.currentControlState == 0)  //Dpad
        {
            Aiming();
        }
        else if(GameManager.Instance.currentControlState == 1) //swipe
        {
            Aim();
        }


#if UNITY_EDITOR
        keyboardmouseInput();
#endif
    }
    public void Shoot()
    {
        if(ammoCounter.gunLoaded == true && !mouseOnUI)
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
    }

    private void hideFire()
    {
        fire.gameObject.SetActive(false);
    }


    private void Aim()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 aimPosition = cam.ScreenToWorldPoint(touch.position);
            aim.transform.position = aimPosition;
        }

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
            //else if (touch.phase == TouchPhase.Ended && mouseOnUI)
            //{
            //    Shoot();
            //    NotsloMo();
            //}
        }
    }

    private void keyboardmouseInput()                       //for MOUSE
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        aim.transform.position = mousePosition;

        if (Input.GetButtonDown("Fire1") && !mouseOnUI)
        {
            indicator.gameObject.SetActive(true);
        }
        if (Input.GetButtonUp("Fire1") && !mouseOnUI)
        {
            Shoot();
        }
    }

    public void sloMo()
    {
        Time.timeScale = 0.35f;
        aim.gameObject.SetActive(true);
    }
    public void NotsloMo()
    {
        Time.timeScale = 1.0f;
        aim.gameObject.SetActive(false);
    }


}
