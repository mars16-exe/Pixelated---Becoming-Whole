using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : Singleton<PlayerStats>
{
    public Slider HealthBar;

    [Range(0,100)]private int health = 100;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    private int damage;
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    private void LateUpdate()
    {
        HealthBar.value = Health;
    }

    public void TakeDamage(int value)
    {
        Health -= value;
    }

}
