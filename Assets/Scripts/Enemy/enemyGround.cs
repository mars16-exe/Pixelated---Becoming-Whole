using UnityEngine;
using UnityEngine.UI;

public class enemyGround : Enemy
{
    private Rigidbody2D body;
    private Slider healthBar;


    [SerializeField] protected float spinSpeed;
    [SerializeField] private float followSpeed = 0.4f;
    [SerializeField] private int attackPower = 40;



    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        healthBar = transform.GetChild(1).GetChild(0).GetComponent<Slider>();
        healthBar.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (playerWithinRange())
        {
            Attack();
        }

    }

    private void Attack()
    {
        Vector2 lookDirection = (PlayerShoot.Instance.transform.position - this.transform.position).normalized;   //calculating look direction

        body.AddForce(lookDirection * followSpeed);//moving in direction of player
    }

    void LateUpdate()     //ROTATING THE ENEMY SPRITE
    {
        transform.GetChild(0).Rotate(0f, 0f, spinSpeed * Time.deltaTime);

        HandleHealth();
        base.Death();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats.Instance.TakeDamage(attackPower);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponentInChildren<Bullet>();
            TakeDamage(bullet.Damage);
        }
    }

    private void HandleHealth()
    {
        healthBar.value = Health;
    }

    protected override void TakeDamage(int value)
    {
        base.TakeDamage(value);
        healthBar.gameObject.SetActive(true);
        Invoke("HandleFade", 1.88f);
    }

    private void HandleFade() //healthbar fade
    {
        healthBar.gameObject.SetActive(false);
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
