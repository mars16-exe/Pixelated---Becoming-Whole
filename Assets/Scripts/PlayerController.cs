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
        SwipeControls();

        verticalMovement();
        horizontalMovement();

#if UNITY_EDITOR
        //KeyboardandMouse();
#endif


    }

    private void SwipeControls()
    {
        if(swipeDetection.swipedUp)
        {
            upORdown(1);
        }
        if (swipeDetection.swipedDown)
        {
            upORdown(-1);
        }
        if (swipeDetection.swipedLeft)
        {
            rightORleft(-1);
        }
        if (swipeDetection.swipedRight)
        {
            rightORleft(1);
        }
    }
    private void verticalMovement()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + (verticalInput * speed * Time.deltaTime));
    }

    private void horizontalMovement()
    {
        transform.position = new Vector2(transform.position.x + (horizontalInput * speed * Time.deltaTime), transform.position.y);
    }
    public void upORdown(int value)    //setting Vertical Input for UI
    {
        rigidBody.velocity = Vector2.zero;

        horizontalInput = 0f;
        verticalInput = value;
    }

    public void rightORleft(int value)  //setting Horizontal Input for UI
    {
        rigidBody.velocity = Vector2.zero;

        verticalInput = 0f;
        horizontalInput = value;
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

    private void KeyboardandMouse()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            upORdown(1);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            upORdown(-1);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rightORleft(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightORleft(1);
        }
    }
}
