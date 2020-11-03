using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // to make joystick
    public Joystick joystick;
    public float joystickSensitivity;
    public float horizontalSpeed;
    public float jumpForce;
    public bool isGrounded;

    private Rigidbody2D rigidBody2D;

    // to flip the animation
    private SpriteRenderer spriteRenderer;

    private Animator animator;

    // to change animation
    

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // only can move if player is on the ground
        if (isGrounded)
        {
            if (joystick.Horizontal > joystickSensitivity)
            {
                // move to right
                rigidBody2D.AddForce(Vector2.right * horizontalSpeed * Time.deltaTime);

                // to flip
                spriteRenderer.flipX = false;

                // to set walk animation
                animator.SetInteger("AnimState", 1);
            }
            else if (joystick.Horizontal < -joystickSensitivity)
            {
                // move to left
                rigidBody2D.AddForce(Vector2.left * horizontalSpeed * Time.deltaTime);

                // to flip
                spriteRenderer.flipX = true;

                // to set walk animation
                animator.SetInteger("AnimState", 1);
            }
            else if (joystick.Vertical > joystickSensitivity)
            {
                // jump
                rigidBody2D.AddForce(Vector2.up * jumpForce * Time.deltaTime);
            }
            else
            {
                // to set idle animation from walk animation
                animator.SetInteger("AnimState", 0);
            }
        }// isGrounded
    }


    // to jump
     void OnCollisionEnter2D(Collision2D collision)
     {
        isGrounded = true;
     }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
