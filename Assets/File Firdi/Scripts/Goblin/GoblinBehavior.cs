using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBehavior : MonoBehaviour
{
    public static GoblinBehavior instance;
    [Header("Jump")]
    public float jumpingPower;
    public Animator animator;
    public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [Header("Wall Slide")]
    public bool isWallSliding;
    private float wallSlidingSpeed = 2;
    public Transform wallCheck;
    public LayerMask wallLayer;
    [Header("Wall Jump")]
    private bool isWallJumping;
    private float wallJumpingDirection;
    public float wallJumpingTime;
    public float wallJumpingDuration;
    private float wallJumpingCounter;
    private Vector2 wallJumpingPower = new Vector2(14, 16);
    [Header("Attack")]
    public float goblinDamage;
    public Transform attackPoint;
    public float attackRange;
    public bool isAttacking = false;
    public LayerMask enemylayer;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        AttackInput();
        if (IsGrounded() && !Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            animator.SetBool("isJumping", true);
        }

        if (!isWallJumping)
        {
            //SlimeMovement.instance.Flip();
            SlimeMovement.instance.HorizontalMove();
        }

        WallSlide();
        WallJump();
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        //animator.SetBool("isJumping", false);
    }
    public void AttackInput()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            isAttacking = true;
            //SlimeMovement.instance.runSpeed = 0;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemylayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyController>().TakeDamage(goblinDamage);
            }
        }
        SlimeMovement.instance.HorizontalMove();
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled() && !IsGrounded() && SlimeMovement.instance.horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if(transform.localScale.x != wallJumpingDirection)
            {
                SlimeMovement.instance.isFacingRight = !SlimeMovement.instance.isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }

        Invoke(nameof(StopWallJumping), wallJumpingDuration);
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }
}
