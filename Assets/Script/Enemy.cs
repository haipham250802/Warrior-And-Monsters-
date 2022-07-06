using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Class")]
    public Transform player;
    Animator anm;
    Player m_player;

    [Header("Struct")]
    public Vector3 EnemyOriginPos;
    public LayerMask PlayerLayerMask;

    [Header("Parameters")]
    public float Speed;
    public float range;
    public float TakeDamage;

    private bool isFacingRight;
    private bool isAttack;

    public Animator Anm { get => anm; set => anm = value; }
    public bool IsAttack { get => isAttack; set => isAttack = value; }

    // Start is called before the first frame update
    void Start()
    {
        anm = GetComponent<Animator>();
        m_player = FindObjectOfType<Player>();
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveAttack();
    }
    private void FixedUpdate()
    {

    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void MoveAttack()
    {
        Vector3 thePosition;
        Collider2D col = Physics2D.OverlapCircle(transform.position, range, PlayerLayerMask);
        if (!m_player.IsGameOver)
        {
            if (col != null)
            {
                anm.SetBool("isRunEnemy", true);
                if (player.position.x < transform.position.x && isFacingRight)
                {
                    Flip();
                    isFacingRight = false;
                }
                else if (player.position.x > transform.position.x && !isFacingRight)
                {
                    Flip();
                    isFacingRight = true;
                }
                if (!m_player.IsFacingRight)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x - 0.3f, transform.position.y, player.position.z), Speed * 0.05f * Time.deltaTime);
                }
                if (player.position.x > transform.position.x)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x - 0.3f, transform.position.y, player.position.z), Speed * 0.05f * Time.deltaTime);
                }
                else if (player.position.x < transform.position.x)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x + 0.3f, transform.position.y, player.position.z), Speed * 0.05f * Time.deltaTime);
                }
            }
            else
            {
                anm.SetBool("isRunEnemy", true);
                anm.SetBool("isAttackEnemy", false);

                if (transform.position.x < EnemyOriginPos.x && !isFacingRight)
                {
                    Flip();
                }
                else if (transform.position.x > EnemyOriginPos.x && isFacingRight)
                {
                    Flip();
                }

                transform.position = Vector3.MoveTowards(transform.position, EnemyOriginPos, Speed * 0.1f * Time.deltaTime);
                if (transform.position.x == EnemyOriginPos.x)
                {
                    anm.SetBool("isRunEnemy", false);
                }
            }

            Collider2D col2 = Physics2D.OverlapCircle(transform.position, range / 3, PlayerLayerMask);
            if (col2 != null)
            {
                IsAttack = true;
            }
            else if (col2 == null)
            {
                isAttack = false;
            }
        }
        else
        {
            anm.SetBool("isRunEnemy", false);
            anm.SetBool("isAttackEnemy", false);
        }
    }
    


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawWireSphere(transform.position, range / 3);
    }
}