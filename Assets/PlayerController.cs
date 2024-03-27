using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float forceX = 1;
    [SerializeField] float forceY = 1;
    Rigidbody2D rb;
    bool onGround = false;
    Animator animator; //declare variable
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); //declare component
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(forceX * Vector2.right);
                animator.SetBool("Run", true);
                spriteRenderer.flipX = false;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(forceX * Vector2.left);
                animator.SetBool("Run", true);
                spriteRenderer.flipX = true;
            }
            else
            {
                animator.SetBool("Run", false);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(forceY * Vector2.up);
                animator.SetBool("Jump", true);
            }
            else
            {
                animator.SetBool("Jump", false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if we collide with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
        {
        //check if we collide with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;

        }
        }
}
