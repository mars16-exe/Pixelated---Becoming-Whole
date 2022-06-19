using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{

    Vector2 wlrdPOS;
    public Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        wlrdPOS = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = wlrdPOS;
    }
}
