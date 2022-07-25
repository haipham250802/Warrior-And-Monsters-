using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private int iD;
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
    private bool isAttack;
    private bool IsFacingRight;
    private Player m_player;
    public GameObject[] ItemsHealth;


    public GameObject Bullet;
    public GameObject PosBullet;

    public bool IsAttack { get => isAttack; set => isAttack = value; }
    public int ID { get => iD; set => iD = value; }


    // Start is called before the first frame update
    void Start()
    {
        hitPoint = maxHitPoint;
        CurTimeAttack = TimeAttack;
        health.SetHealth(hitPoint, maxHitPoint);
        anim = GetComponent<Animator>();
        m_player = FindObjectOfType<Player>();

        IsFacingRight = true;

    }
    private void Update()
    {
        FollowPlayer();
        if (ID == 1)
        {
            AttackId1();
        }
        if (ID == 2)
        {
            AttackId2();
        }
    }
    public void TakeHit(float damage)
    {
        hitPoint -= damage;
        if (hitPoint <= 0)
        {
            int rand = Random.Range(0,ItemsHealth.Length);
            Instantiate(ItemsHealth[rand],transform.position + offset, Quaternion.identity);
            Destroy(gameObject);
        }
        health.SetHealth(hitPoint, maxHitPoint);
        Instantiate(FloatingPoint, transform.position + offset, Quaternion.identity);
    }
    void FollowPlayer()
    {
        if (!m_player.IsGameOver )
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
                if (CurTimeAttack > 0)
                {
                    CurTimeAttack -= Time.deltaTime;
                    anim.SetBool(nameAttack, false);
                }
                else if (CurTimeAttack <= 0)
                {
                    isAttack = true;
                    anim.SetBool(nameAttack, true);
                    CurTimeAttack = TimeAttack;
                }
            }
            else if (col2 == null)
            {
                anim.SetBool(nameAttack, false);
            }
        }
        else
        {
            isAttack = false;
            anim.SetBool(nameAttack, false);
            anim.SetBool(nameRunning, false);
        }
    }
    void AttackId2()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, range, playerMask);
        if(col)
        {
            if (CurTimeAttack > 0)
            {
                CurTimeAttack -= Time.deltaTime;

            }
            else if (CurTimeAttack <= 0)
            {
                isAttack = true;
                Instantiate(Bullet, PosBullet.transform.position, Quaternion.identity);
                CurTimeAttack = TimeAttack;            }
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
        Gizmos.DrawWireSphere(transform.position, range/2);
    }

}
