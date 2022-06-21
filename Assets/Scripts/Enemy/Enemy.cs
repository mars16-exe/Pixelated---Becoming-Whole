using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health;
    protected int Health
    {
        get { return health; }
        set { health = value; }
    }

    //private float speed;
    //protected float Speed
    //{
    //    get { return speed; }
    //    set { speed = value; }
    //}
}
