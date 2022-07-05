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

        Fade();
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

    private void Fade()
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


}
