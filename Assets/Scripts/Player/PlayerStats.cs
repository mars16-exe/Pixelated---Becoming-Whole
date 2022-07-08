using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : Singleton<PlayerStats>
{
    public Slider HealthBar;

    [Range(0,100)]private int health = 100;

    public int Health
    {
        get { return health; }
        set { health = value; 
            if (health > 100)
            { health = 100; } 
            }
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

    public void Heal(int value)
    {
        Health += value;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Health" && Health != 100)
        {
            Heal(60);
            Destroy(collision.gameObject);
        }
    }

}
