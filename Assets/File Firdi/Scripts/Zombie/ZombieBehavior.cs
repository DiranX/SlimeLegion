using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour
{
    public static ZombieBehavior instance;

    public Animator animator;
    public float jumpingPower;
    private bool doubleJump;
    public float doubleJumpingPower;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public Rigidbody2D rb;
    [Header("Attack")]
    public float ZombieDamage;
    public Transform attackPoint;
    public float attackRange;
    public bool isAttacking = false;
    public LayerMask enemylayer;
    [Space]
    [Header("Rolling")]
    public float slideSpeed;
    public float slideTime;
    public float slideCoolDown;
    public bool isSlide;
    public bool canSlide = true;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
            animator.SetBool("isJumping", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, doubleJump ? doubleJumpingPower : jumpingPower);

                doubleJump = !doubleJump;
                animator.SetBool("isJumping", true);
            }
        }
        if (Input.GetMouseButtonDown(1) && canSlide)
        {
            StartCoroutine(JumpForward());
        }

        if (isSlide == false)
        {
            SlimeMovement.instance.HorizontalMove();
        }
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            StartCoroutine(AttackInput());
        }

        SlimeMovement.instance.Flip();
    }
    public IEnumerator AttackInput()
    {
        animator.SetTrigger("Attack");
        //isAttacking = true;
        //SlimeMovement.instance.runSpeed = 0;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemylayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyController>().TakeDamage(ZombieDamage);
        }
        yield return new WaitForSeconds(2.5f);
    }
    public IEnumerator JumpForward()
    {
        Vector2 arah = new Vector2(SlimeMovement.instance.transform.localScale.x * slideSpeed, 30);
        isSlide = true;
        canSlide = false;
        //float gravity = rb.gravityScale;
        //rb.gravityScale = 0;
        animator.SetBool("isJumpForward", true);
        //Physics2D.IgnoreLayerCollision(3, 7, true);
        //Physics2D.IgnoreLayerCollision(3, 8, true);
        rb.AddForce(arah, ForceMode2D.Impulse);
        AttackInput();
        yield return new WaitForSeconds(slideTime);
        //Physics2D.IgnoreLayerCollision(3, 7, false);
        //Physics2D.IgnoreLayerCollision(3, 8, false);
        //rb.gravityScale = gravity;
        isSlide = false;
        yield return new WaitForSeconds(slideCoolDown);
        animator.SetBool("isJumpForward", false);
        canSlide = true;
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        //animator.SetBool("isJumping", false);
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
