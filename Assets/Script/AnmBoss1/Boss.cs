using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public float range;
    public float range2;
    public float speed;
    public string nameRunAnm;
    public string nameAttackAnm;
    public Vector2 PosOriginal;
    bool isFacingRight;
    public Transform Target;
    public LayerMask playerMask;
    public GameObject hitbox;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        isFacingRight = true;
        hitbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        Attack();
    }
    void Follow()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, range, playerMask);
        if (col != null)
        {
            FlipFollow();
            animator.SetBool(nameRunAnm, true);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Target.position.x, transform.position.y), speed * Time.deltaTime);
        }
        else
        {
            pending();
        }
    }
    void FlipFollow()
    {
        if (Target.position.x < transform.position.x && isFacingRight)
        {
            Flip();
            isFacingRight = false;
        }
        else if (Target.position.x > transform.position.x && !isFacingRight)
        {
            Flip();
            isFacingRight = true;
        }
    }
    void pending()
    {
        if (transform.position.x < PosOriginal.x && !isFacingRight)
        { 
            Flip();
        }

        else if (transform.position.x > PosOriginal.x && isFacingRight)
        {
            Flip();
        }
        animator.SetBool(nameRunAnm, true);
        transform.position = Vector2.MoveTowards(transform.position, PosOriginal, speed * Time.deltaTime);
        if(transform.position.x == PosOriginal.x)
        {
            animator.SetBool(nameRunAnm, false);
        }
    }
    void Attack()
    {
        Collider2D col2 = Physics2D.OverlapCircle(transform.position, range2,playerMask);
        if (col2 != null)
        {
            hitbox.SetActive(true);
            Debug.Log("da cham");
            animator.SetBool(nameAttackAnm, true);
        }
        else
        {
            hitbox.SetActive(false);
            animator.SetBool(nameAttackAnm, false);
        }
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawWireSphere(transform.position, range2);
    }
}
