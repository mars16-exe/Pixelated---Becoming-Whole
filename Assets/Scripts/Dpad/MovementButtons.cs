using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementButtons : MonoBehaviour
{
    public void mouseYES()
    {
        PlayerShoot.Instance.mouseOnUI = true;
    }
    public void mouseNO()
    {
        PlayerShoot.Instance.mouseOnUI = true;
        Invoke("falsify", 0.1f);
    }

    public void falsify()
    {
        PlayerShoot.Instance.mouseOnUI = false;
    }
}
