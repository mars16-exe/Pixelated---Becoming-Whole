using System.Collections;
using UnityEngine;
using TMPro;

public class GunMechanics : MonoBehaviour
{
    private TextMeshProUGUI bulletCounter;


    private int revolverMag = 27;
    private int revolverAmmo = 6;
    public int ammo = 0;
    public int mag = 0;

    private Color32 ActiveSign = new Color32(255,255,255,255);
    private Color32 DeactiveSign = new Color32(255,255,255,255/2);

    public bool gunLoaded = true;

    private void Awake()
    {
        ammo = revolverAmmo;
        mag = revolverMag;

        bulletCounter = GameObject.FindGameObjectWithTag("BulletCounter").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        bulletCounter.text = ammo + "/" + mag;

        if (ammo == 0 && mag != 0)
        {
            gunLoaded = false;
            Reload();
            StartCoroutine(ReloadTime(1.8f));
        }
        else if(ammo == 0 && mag == 0)
        {
            gunLoaded = false;
        }

        ReloadFade();
    }

    private void Reload()
    {
        if(mag < revolverAmmo)
        {
            ammo = mag;
            mag -= mag;
        }
        else
        {
            ammo = revolverAmmo;
            mag -= revolverAmmo;
        }
    }

    private IEnumerator ReloadTime(float value)
    {
        yield return new WaitForSeconds(value);
        gunLoaded = true;
    }

    private void ReloadFade()
    {
        if (gunLoaded)
        {
            bulletCounter.color = ActiveSign;
        }
        else if(!gunLoaded)
        {
            bulletCounter.color = DeactiveSign;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ammoRevolver")
        {
            ammoPickup(collision.gameObject);
        }
    }

    private void ammoPickup(GameObject ammoCrate)
    {
        ammo pickedAmmo = ammoCrate.gameObject.GetComponent<ammo>();
        mag += pickedAmmo.value;

        Destroy(ammoCrate.gameObject);
    }
}
