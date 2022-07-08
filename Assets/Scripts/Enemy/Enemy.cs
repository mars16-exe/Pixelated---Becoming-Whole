using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 100;
    protected int Health
    {
        get { return health; }
        set { health = value; }
    }

    [SerializeField] protected float range = 6.66f;

    //private float speed;
    //protected float Speed
    //{
    //    get { return speed; }
    //    set { speed = value; }
    //}

    protected virtual void TakeDamage(int value)
    {
        Health -= value;
    }

    protected virtual void Death()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }

        //Death Effects
    }

    protected bool playerWithinRange()
    {
        float distance = Vector3.Distance(transform.position, PlayerShoot.Instance.transform.position);     //finding distance

        if (distance <= range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
