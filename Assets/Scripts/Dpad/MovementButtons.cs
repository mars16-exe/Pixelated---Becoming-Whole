using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementButtons : MonoBehaviour
{
    public void mouseYES()
    {
        PlayerShoot.Instance.mouseOnUI = true;
        Invoke("mouseNO", 0.1f);
    }
    public void mouseNO()
    {
        PlayerShoot.Instance.mouseOnUI = false;

    }
}
