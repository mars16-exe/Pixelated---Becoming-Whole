using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private float verticalInput;
    private float horizontalInput;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        verticalMovement();
        horizontalMovement();
    }

    private void verticalMovement()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + (verticalInput * speed * Time.deltaTime));
    }

    private void horizontalMovement()
    {
        transform.position = new Vector2(transform.position.x + (horizontalInput * speed * Time.deltaTime), transform.position.y);
    }
    public void upORdown(int value)    //setting Vertical Input
    {
        horizontalInput = 0f;
        verticalInput = value;
    }

    public void rightORleft(int value)  //setting Horizontal Input
    {
        verticalInput = 0f;
        horizontalInput = value;

        //if(horizontalInput != value)
        //{
        //}
        //else
        //{
        //    horizontalInput = 0f;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Level")
        {
            verticalInput = 0f;
            horizontalInput = 0f;
            rigidBody.velocity = Vector2.zero;

        }
    }
}
