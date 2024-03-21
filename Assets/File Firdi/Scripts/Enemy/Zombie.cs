using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float attackRange;
    public float JumpRange;
    public float JumpSpeed;
    public float jumpCoolDown;
    public float jumpTime;
    public bool canJump;
    public bool isJump;
    public Animator anim;
    public Transform attackPoint;
    public Transform JumpDetect;
    private GameObject Hitbox;
    private Rigidbody2D rb;
    public LayerMask playerMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attacking();

        if(isJump != true)
        {
            StartCoroutine(JumpForward());
        }
    }

    void Attacking()
    {
        Collider2D[] detectPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerMask);
        foreach (Collider2D item in detectPlayer)
        {
            anim.SetTrigger("Attack");
            //Debug.Log("Hit Player");
        }
    }

    IEnumerator JumpForward()
    {
        Collider2D[] detectPlayer = Physics2D.OverlapCircleAll(JumpDetect.position, JumpRange/2, playerMask);
        RaycastHit2D DetectPlayer = Physics2D.Raycast(JumpDetect.transform.position, Vector2.left, JumpRange, playerMask);
        yield return new WaitForSeconds(1);
        if (canJump != false)
        {
            StartCoroutine(jump());
        }
        else
        {
            canJump = false;
        }
        if(DetectPlayer.collider == null)
        {
            isJump = false;
        }
        foreach (Collider2D item in detectPlayer)
        {
            canJump = true;
            ////rb.velocity = new Vector2(transform.localScale.x * JumpSpeed, 2);
            //StartCoroutine(BackDash());
            //anim.SetTrigger("backDash");
        }
    }
    public IEnumerator jump()
    {
        //Vector2 arah = new Vector2(transform.localScale.x * JumpSpeed, 1);
        isJump = true;
        canJump = false;
        //float gravity = rb.gravityScale;
        //rb.gravityScale = 0;
        //animator.SetBool("isSlide", true);
        //Physics2D.IgnoreLayerCollision(3, 7, true);
        //Physics2D.IgnoreLayerCollision(3, 8, true);
        rb.velocity = new Vector2(transform.localScale.x * JumpSpeed, 1);
        yield return new WaitForSeconds(jumpTime);
        //Physics2D.IgnoreLayerCollision(3, 7, false);
        //Physics2D.IgnoreLayerCollision(3, 8, false);
        //rb.gravityScale = gravity;
        isJump = true;
        yield return new WaitForSeconds(jumpCoolDown);
        canJump = false;
        //animator.SetBool("isSlide", false);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(JumpDetect.position, JumpRange);
    }
}
