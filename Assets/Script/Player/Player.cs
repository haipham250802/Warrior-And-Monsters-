using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public static Player instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        { Destroy(this); }
    }

    private Rigidbody2D rb;
    private TimeCountDownSkill m_TimeCountDown;
    private UImanager m_UImanager;
    private BossBehavior m_Boss;
    [Header("Animator")]
    public Animator anm;

    [Header("Parameters")]
    public float Speed;
    public float JumpForce;
    public Vector3 StartPosition;

    private int damage1;
    private int damage2;
    [Header("Object")]
    public GameObject SKills;
    public GameObject DeadGameUI;
    public GameObject NextMap;

    private int ClickCount00 = 0;
    private int ClickCount01 = 0;
    private int ClickCount02 = 0;
    private int ClickCount03 = 0;
    private int CurDamage1;
    private int CurDamage2;


    private bool isCanUseSkill00;
    private bool isCanUseSkill01;
    private bool isCanUseSkill02;
    private bool isCanUseSkill03;

    private bool isFacingRight;
    private bool isGrounded;
    private bool IsCanDoubleJump;
    private bool isGameOver;
    private float MoveSpeed;
    private bool isDamagePlus1;
    private bool isDamagePlus2;
    private bool isLevelUp;

    private bool isMovementRight;
    private bool isMovementLeft;

    

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
    public int Damage1 { get => damage1; set => damage1 = value; }
    public int Damage2 { get => damage2; set => damage2 = value; }


    public float MoveSpeed1 { get => MoveSpeed; set => MoveSpeed = value; }
    public int CurDamage11 { get => CurDamage1; set => CurDamage1 = value; }
    public int CurDamage21 { get => CurDamage2; set => CurDamage2 = value; }
    public bool IsLevelUp { get => isLevelUp; set => isLevelUp = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();

        m_TimeCountDown = FindObjectOfType<TimeCountDownSkill>();
        m_UImanager = FindObjectOfType<UImanager>();
        m_Boss = FindObjectOfType<BossBehavior>();

        CurDamage1 = DataPlayer.GetDamage1();
        CurDamage2 = DataPlayer.GetDamage2();

        isFacingRight = true;
        isMovementLeft = false;
        isMovementRight = false;

        int maxhp = DataPlayer.GetMaxHP();
        int maxmp = DataPlayer.GetMaxMP();
        DataPlayer.SetHP(maxhp);
        DataPlayer.SetMP(maxmp);

        NextMap.SetActive(false);
    }

    void Update()
    {
        MainAttack();
        GameOver();
        DamagePlusToWepon();
        LevelUp();
      //  MovementMobile();
    }
    void DamagePlusToWepon()
    {
        if (DataPlayer.IsOwnWeponWithId(1) && !isDamagePlus1)
        {
            CurDamage1 = DataPlayer.GetDamage1();
            isDamagePlus1 = true;
        }
        if (DataPlayer.IsOwnWeponWithId(2) && !isDamagePlus2)
        {
            CurDamage2 = DataPlayer.GetDamage2();
            isDamagePlus2 = true;
        }
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
        if (DataPlayer.GetHP() <= 0)
        {
            isGameOver = true;
            SKills.SetActive(false);
            anm.SetBool("isDead", true);
            m_UImanager.ShowDeadGame();
        }
        else
        {
            isGameOver = false;
            anm.SetBool("isDead", false);
            SKills.SetActive(true);
        }
    }
      private void FixedUpdate()
      {
          if (!isGameOver)
          {
              MoveSpeed = Input.GetAxis("Horizontal");
              rb.velocity = new Vector2(Speed * MoveSpeed * Time.deltaTime, rb.velocity.y);
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
      }
    void MovementMobile()
    {
        if (isMovementLeft)
        {
            Debug.Log("da den1");
            rb.velocity = new Vector2(-Speed * Time.deltaTime, rb.velocity.y);
            if (IsFacingRight)
            {
                Flip();
            }
            anm.SetFloat("isRun", 1f);
        }
        if (isMovementRight)
        {
            Debug.Log("da den2");
            rb.velocity = new Vector2(Speed * Time.deltaTime, rb.velocity.y);
            if (!IsFacingRight)
            {
                Flip();
            }
            anm.SetFloat("isRun", 1f);
        }
    }
    public void JumpBtn()
    {
        Jump();
        Fall();
    }
    public void RunLeftBtn()
    {
        isMovementLeft = true;
    }
    public void RunRightBtn()
    {
        isMovementRight = true;
    }
    public void StopMovement()
    {
        Debug.Log("da thoat");
        isMovementRight = false;
        isMovementLeft = false;
        anm.SetFloat("isRun", 0);
    }
    void Jump()
    {
        if (!isGameOver)
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
        if (collision.gameObject.CompareTag("Coin"))
        {
            int rand = Random.Range(60, 80);
            DataPlayer.AddCoin(rand);
        }
        if (collision.gameObject.CompareTag("Diamond"))
        {
            int rand = Random.Range(20, 30);
            DataPlayer.AddDiamond(rand);
        }
        if (collision.gameObject.CompareTag("XP"))
        {
            int rand = Random.Range(m_Boss.MinXP, m_Boss.MaxXP);
            DataPlayer.AddXP(rand);
        }
        if(collision.gameObject.CompareTag("Water"))
        {
            int hp = 0;
            DataPlayer.SetHP(hp);
        }
    }
    void LevelUp()
    {
        int MaxExp = DataPlayer.GetMaxXP();
        int CurExp = DataPlayer.GetXP();
        if (CurExp >= MaxExp)
        {
            isLevelUp = true;
            DataPlayer.Addlevel(1);

            int curLevel = DataPlayer.GetLevel();

            DataPlayer.AddDamage1(CurDamage1,curLevel);
            DataPlayer.AddDamage2(CurDamage2,curLevel);

            CurDamage2 = DataPlayer.GetDamage2();
            CurDamage1 = DataPlayer.GetDamage1();

            DataPlayer.SetMaxXP(curLevel);

            DataPlayer.AddMaxHP(curLevel * 50);
            int Hp = DataPlayer.GetMaxHP();
            DataPlayer.SetHP(Hp);

            DataPlayer.AddMaxMP(curLevel * 50);
            int Mp = DataPlayer.GetMaxMP();
            DataPlayer.SetMP(Mp);

            DataPlayer.SetXP(0);

            NextMap.SetActive(true);
        }
    }
    public void Sword_Attack()
    {
        ClickCount00++;
        if (ClickCount00 == 1 && DataPlayer.GetMP() >= 2)
        {
            isCanUseSkill00 = true;
            DataPlayer.TakeMP(2);
        }
        if (DataPlayer.GetMP() < 2)
        {
            ClickCount00 = 0;
        }
    }
    public void Shield_Attack()
    {
        ClickCount01++;
        if (ClickCount01 == 1 && DataPlayer.GetMP() >= 10)
        {

            isCanUseSkill01 = true;
            DataPlayer.TakeMP(10);

        }
        if (DataPlayer.GetMP() < 10)
        {
            ClickCount01 = 0;
        }
    }
    public void Buff_Damage()
    {
        ClickCount02++;
        if (ClickCount02 == 1 && DataPlayer.GetMP() >= 15)
        {
            isCanUseSkill02 = true;
            DataPlayer.TakeMP(15);
        }
        if (DataPlayer.GetMP() < 15)
        {
            ClickCount02 = 0;
        }
    }
    public void Buff_Hp()
    {
        ClickCount03++;
        if (ClickCount03 == 1 && DataPlayer.GetMP() >= 20)
        {
            isCanUseSkill03 = true;
            DataPlayer.TakeMP(20);
        }
        if (DataPlayer.GetMP() < 20)
        {
            ClickCount03 = 0;
        }
    }
    public void RevivalGold()
    {
        if (DataPlayer.GetCoin() >= 200)
        {
            DataPlayer.SubCoin(200);

            int maxhp = DataPlayer.GetMaxHP();
            int maxmp = DataPlayer.GetMaxMP();
            DataPlayer.SetHP(maxhp);
            DataPlayer.SetMP(maxmp);

            DeadGameUI.SetActive(false);
            transform.position = StartPosition;
        }
    }
    public void RevivalDiamond()
    {
        if (DataPlayer.GetDiamond() >= 50)
        {
            DataPlayer.SubDiamond(50);

            int maxhp = DataPlayer.GetMaxHP();
            int maxmp = DataPlayer.GetMaxMP();
            DataPlayer.SetHP(maxhp);
            DataPlayer.SetMP(maxmp);

            DeadGameUI.SetActive(false);
            transform.position = StartPosition;
        }
    }

    public Animator Getanm()
    {
        return anm;
    }

}
