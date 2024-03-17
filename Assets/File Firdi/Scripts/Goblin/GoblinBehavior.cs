using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBehavior : MonoBehaviour
{
    public static GoblinBehavior instance;

    public float jumpingPower;
    public Animator animator;
    public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

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
                //enemy.GetComponent<EnemyController>().TakeDamage(swordDamage);
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
}
