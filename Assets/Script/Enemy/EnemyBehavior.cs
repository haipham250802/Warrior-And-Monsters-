using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float hitPoint;
    public float maxHitPoint;
    public float range;
    public float speed;
    public float limit;
    public string nameRunning;
    public string nameAttack;
  
    public Vector3 PosOriginal;
    public Vector3 offset;
    public HeathBarEnemy health;
    public Transform Target;
    public LayerMask playerMask;
    public GameObject FloatingPoint;
   
   
    private Animator anim;
    private bool IsFacingRight;
    private Player m_player;
    public GameObject[] Items;
    // Start is called before the first frame update
    void Start()
    {
        hitPoint = maxHitPoint;
        health.SetHealth(hitPoint, maxHitPoint);
        anim = GetComponent<Animator>();
        m_player = FindObjectOfType<Player>();

        IsFacingRight = true;

    }
    private void Update()
    {
        FollowPlayer();
    }
    public void TakeHit(float damage)
    {
        hitPoint -= damage;
        if (hitPoint <= 0)
        {
            int rand = Random.Range(0,Items.Length);
            Instantiate(Items[rand],transform.position + offset, Quaternion.identity);
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
            Collider2D col2 = Physics2D.OverlapCircle(transform.position, range / 3, playerMask);
            if (col2)
            {
                anim.SetBool(nameAttack, true);
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
