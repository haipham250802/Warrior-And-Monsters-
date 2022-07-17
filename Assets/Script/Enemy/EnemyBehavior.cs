using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float hitPoint;
    public float maxHitPoint;
    public float range;
    public float speed;
    public Vector3 PosOriginal;
    public HeathBarEnemy health;
    public Transform Target;
    public LayerMask playerMask;
    private Animator anim;
    private bool IsFacingRight;
    // Start is called before the first frame update
    void Start()
    {
        hitPoint = maxHitPoint;
        health.SetHealth(hitPoint, maxHitPoint);
        anim = GetComponent<Animator>();

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
            Destroy(gameObject);
        }
        health.SetHealth(hitPoint, maxHitPoint);
    }
    void FollowPlayer()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, range, playerMask);
        if (col)
        {
            anim.SetBool("isRunning", true);
            if (Target.position.x < transform.position.x && IsFacingRight)
            {
                Flip();
            }
            if (Target.position.x > transform.position.x && !IsFacingRight)
            {
                Flip();
            }
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Target.position.x, transform.position.y), speed * Time.deltaTime);
        }
        else if(col == null)
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
                anim.SetBool("isRunning", false);
            }
        }
        Collider2D col2 = Physics2D.OverlapCircle(transform.position, range/3, playerMask);
        if(col2)
        {
            anim.SetBool("isAttack", true);
        }
        else if(col2 == null)
        {
            anim.SetBool("isAttack", false);
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
