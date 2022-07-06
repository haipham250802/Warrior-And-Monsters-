using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private Info_Bar m_Info;
    private TimeCountDownSkill m_TimeCountDown;

    [Header("Animator")]
    public Animator anm;

    [Header("Parameters")]
    public float Speed;
    public float JumpForce;
    
    private int ClickCount00 = 0;
    private int ClickCount01 = 0;
    private int ClickCount02 = 0;
    private int ClickCount03 = 0;

    private bool isCanUseSkill00;
    private bool isCanUseSkill01;
    private bool isCanUseSkill02;
    private bool isCanUseSkill03;

    private bool isFacingRight;
    private bool isGrounded;
    private bool IsCanDoubleJump;
    private bool isGameOver;


    public bool IsGameOver { get => isGameOver; private set => isGameOver = value; }
    public int ClickCount001 { get => ClickCount00; set => ClickCount00 = value; }
    public int ClickCount011 { get => ClickCount01; set => ClickCount01 = value; }
    public int ClickCount021 { get => ClickCount02; set => ClickCount02 = value; }
    public int ClickCount031 { get => ClickCount03; set => ClickCount03 = value; }
    public bool IsCanUseSkill00 { get => isCanUseSkill00; set => isCanUseSkill00 = value; }
    public bool IsCanUseSkill01 { get => isCanUseSkill01; set => isCanUseSkill01 = value; }
    public bool IsCanUseSkill02 { get => isCanUseSkill02; set => isCanUseSkill02 = value; }
    public bool IsCanUseSkill03 { get => isCanUseSkill03; set => isCanUseSkill03 = value; }
    public bool IsFacingRight { get => isFacingRight; set => isFacingRight = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();

        m_Info = FindObjectOfType<Info_Bar>();
        m_TimeCountDown = FindObjectOfType<TimeCountDownSkill>();

        isFacingRight = true;
    }

    void Update()
    {
        MainAttack();
        GameOver();
    }
    void MainAttack()
    {
        m_TimeCountDown.SwordAttack();
        m_TimeCountDown.ShieldAttack();
        m_TimeCountDown.Buff01();
        m_TimeCountDown.Buff02();
    }
    void GameOver()
    {

        if (m_Info.getHP() <= 0)
        {
            isGameOver = true;
            anm.SetBool("isDead", true);
            Speed = 0;
            anm.SetFloat("isRun", -1);
        }
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
    public void Sword_Attack()
    {
        ClickCount00++;
        if (ClickCount00 == 1)
        {
            isCanUseSkill00 = true;
        }
    }
    public void Shield_Attack()
    {
        ClickCount01++;
        if (ClickCount01 == 1)
        {
            isCanUseSkill01 = true;
        }
    }
    public void Buff_Damage()
    {
        ClickCount02++;
        if (ClickCount02 == 1)
        {
            isCanUseSkill02 = true;
        }
    }
    public void Buff_Hp()
    {
        ClickCount03++;
        if (ClickCount03 == 1)
        {
            isCanUseSkill03 = true;
        }
    }
    public void JumpBtn()
    {
        Jump();
    }
    public Animator Getanm()
    {
        return anm;
    }
    
}
