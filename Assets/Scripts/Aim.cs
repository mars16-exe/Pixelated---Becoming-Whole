using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{

    Vector2 wlrdPOS;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        wlrdPOS = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = wlrdPOS;
    }
}
