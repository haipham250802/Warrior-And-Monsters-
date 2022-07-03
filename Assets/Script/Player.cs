using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    Rigidbody2D rb;
    Animator anm;

    bool isFacingRight;
    bool isGrounded;
    bool IsCanDoubleJump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();

        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        float MoveSpeed = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Speed * MoveSpeed, rb.velocity.y);
        anm.SetFloat("isRun", Mathf.Abs(MoveSpeed));
        if (MoveSpeed > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (MoveSpeed < 0 && isFacingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        Fall();
    }
    void Jump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, JumpForce * Time.deltaTime);
            anm.SetBool("isJump", true);
            IsCanDoubleJump = true;
        }
        if (rb.velocity.y <= 0 && IsCanDoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce * Time.deltaTime);
            anm.SetBool("isJump", true);
            IsCanDoubleJump = false;
        }

    }
    void Fall()
    {
        if (rb.velocity.y < 0 && !isGrounded)
        {
            anm.SetBool("isFall", true);
        }
        if (rb.velocity.y >= 0 && isGrounded)
        {
            anm.SetBool("isFall", false);

        }
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anm.SetBool("isFall", false);
            anm.SetBool("isJump", false);
        }
    }
}
