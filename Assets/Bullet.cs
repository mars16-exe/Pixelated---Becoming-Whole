using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rbBODY;
    [SerializeField] private float power = 20f;
    private Vector2 yeah;

    private void Awake()
    {
        rbBODY = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rbBODY.AddForce(yeah * power);
    }

    public void Shoot(Vector2 direction)
    {
        direction = yeah;
    }
}
