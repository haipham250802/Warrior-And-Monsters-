using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public int BossID;

    public float hitPoint;
    public float maxHitPoint;
    public float range;
    public float speed;
    public string nameRunning;
    public string nameAttack;
    public float TimeAttack;
    public float CurTimeAttack;

    public Vector3 PosOriginal;
    public Vector3 offset;
    public HeathBarEnemy health;
    public Transform Target;
    public LayerMask playerMask;
    public GameObject FloatingPoint;


    private Animator anim;
    private bool IsFacingRight;
    private bool isAttack;
    private Player m_player;

    private int minXP = 0;
    private int maxXP = 0;


    public GameObject ItemsCoin;
    public GameObject ItemsDiamond;
    public GameObject ItemsExp;
    public GameObject Meteorite;
    public bool IsAttack { get => isAttack; set => isAttack = value; }
    public int MinXP { get => minXP; set => minXP = value; }
    public int MaxXP { get => maxXP; set => maxXP = value; }

    // Start is called before the first frame update
    void Start()
    {
        hitPoint = maxHitPoint;
        health.SetHealth(hitPoint, maxHitPoint);
        anim = GetComponent<Animator>();
        m_player = FindObjectOfType<Player>();

        IsFacingRight = true;
        minXP = BossID * 100;
        maxXP = BossID * 120;

        CurTimeAttack = TimeAttack;

    }
    private void Update()
    {
        FollowPlayer();

        switch(BossID)
        {
            case 1:
                AttackId1();
                break;
            case 2:
                AttackId2();
                break;
            case 3:
                AttackId3();
                break;
        }
    }
    public void TakeHit(float damage)
    {
        hitPoint -= damage;
        if (hitPoint <= 0)
        {
            for (int i = 0; i < 15; i++)
            {
                Instantiate(ItemsCoin, transform.position + offset, Quaternion.identity);
                Instantiate(ItemsDiamond, transform.position, Quaternion.identity);
                Instantiate(ItemsExp, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        health.SetHealth(hitPoint, maxHitPoint);
        Instantiate(FloatingPoint, transform.position + offset, Quaternion.identity);
    }
    void FollowPlayer()
    {
        if (!m_player.IsGameOver)
        {
            Collider2D col = Physics2D.OverlapCircle(transform.position, range, playerMask);
            if (col)
            {
                anim.SetBool(nameRunning, true);
                if (Target.position.x < transform.position.x && IsFacingRight)
                {
                    Flip();
                }
                if (Target.position.x > transform.position.x && !IsFacingRight)
                {
                    Flip();
                }
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Target.position.x + 0.4f, transform.position.y), speed * Time.deltaTime);
            }
            else if (col == null)
            {
                if (transform.position.x < PosOriginal.x && !IsFacingRight)
                {
                    Flip();
                }
                if (transform.position.x > PosOriginal.x && IsFacingRight)
                {
                    Flip();
                }
                transform.position = Vector2.MoveTowards(transform.position, PosOriginal, speed * Time.deltaTime);
                if (transform.position.x == PosOriginal.x)
                {
                    anim.SetBool(nameRunning, false);
                }
            }
           
        }
        else
        {
            anim.SetBool(nameAttack, false);
            anim.SetBool(nameRunning, false);
        }
    }
    void AttackId1()
    {
        if (!m_player.IsGameOver)
        {
            Collider2D col2 = Physics2D.OverlapCircle(transform.position, range / 3, playerMask);
            if (col2)
            {
                if (CurTimeAttack >= TimeAttack)
                {
                    isAttack = true;
                    anim.SetBool(nameAttack, true);
                    CurTimeAttack = 0;
                }
                else if (CurTimeAttack <= 0)
                {
                    CurTimeAttack += Time.deltaTime;
                    anim.SetBool(nameAttack,false);
                }
            }

            else if (col2 == null)
            {
                anim.SetBool(nameAttack, false);
            }
        }
        else
        {
            anim.SetBool(nameAttack, false);
            anim.SetBool(nameRunning, false);
        }
    }
    void AttackId2()
    {
        if (!FindObjectOfType<Player>().IsGameOver)
        {
            Collider2D col = Physics2D.OverlapCircle(transform.position, range, playerMask);
            if (col)
            {
                if (CurTimeAttack >= TimeAttack)
                {
                    isAttack = true;
                    anim.SetBool(nameAttack, true);
                    Instantiate(Meteorite, new Vector3(m_player.transform.position.x, 26, 0), Quaternion.identity);
                    CurTimeAttack = 0;
                }
                else if (CurTimeAttack < TimeAttack)
                {
                    anim.SetBool(nameAttack, false);
                    CurTimeAttack += Time.deltaTime;
                }
            }
        }
        else
        {
            anim.SetBool(nameAttack, false);
            anim.SetBool(nameRunning, false);
            isAttack = false;
        }
    }
    void AttackId3()
    {
        if (!FindObjectOfType<Player>().IsGameOver)
        {
            Collider2D col = Physics2D.OverlapCircle(transform.position, range, playerMask);
            if (col)
            {
                if (CurTimeAttack >= TimeAttack)
                {
                    isAttack = true;
                    anim.SetBool(nameAttack, true);
                    Instantiate(Meteorite, new Vector3(m_player.transform.position.x, 16, 0), Quaternion.identity);
                    CurTimeAttack = 0;
                }
                else if (CurTimeAttack < TimeAttack)
                {
                    CurTimeAttack += Time.deltaTime;
                    anim.SetBool(nameAttack, false);
                }
            }
        }
        else
        {
            anim.SetBool(nameAttack, false);
            anim.SetBool(nameRunning, false);
            isAttack = false;
        }
    }
    void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 TheScale = transform.localScale;
        TheScale.x *= -1;
        transform.localScale = TheScale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawWireSphere(transform.position, range / 2);
    }

}
