using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SLOWMOindicator : MonoBehaviour
{
    private Image image;

    public Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    private void LateUpdate()
    {
        this.transform.position = (Vector2)PlayerShoot.Instance.transform.position + offset;

        image.fillAmount -= 2 * Time.deltaTime;

        if (image.fillAmount == 0)
        {
            PlayerShoot.Instance.NotsloMo();
            this.gameObject.SetActive(false);
            image.fillAmount = 1f;
        }

    }

    private void OnEnable()
    {
        image.fillAmount = 1f;                      //mischief
        PlayerShoot.Instance.sloMo();
    }

    private void OnDisable()
    {
        PlayerShoot.Instance.NotsloMo();
    }
}
