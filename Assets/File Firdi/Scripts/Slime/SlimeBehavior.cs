using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehavior : MonoBehaviour
{
    public static SlimeBehavior instance;
    public Animator animator;
    public Rigidbody2D rb;

    public float jumpingPower;
    public float doubleJumpingPower;
    private bool doubleJump;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

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

        if (Input.GetKeyDown(KeyCode.LeftShift) && canSlide)
        {
            StartCoroutine(Sliding());
        }

        if(isSlide == false)
        {
            SlimeMovement.instance.HorizontalMove();
        }

        SlimeMovement.instance.Flip();

    }
    public IEnumerator Sliding()
    {
        isSlide = true;
        canSlide = false;
        animator.SetBool("isSlide", true);
        Physics2D.IgnoreLayerCollision(3, 8, true);
        //Physics2D.IgnoreLayerCollision(3, 8, true);
        rb.velocity = new Vector2(SlimeMovement.instance.transform.localScale.x * slideSpeed, 0);
        yield return new WaitForSeconds(slideTime);
        Physics2D.IgnoreLayerCollision(3, 8, false);
        //Physics2D.IgnoreLayerCollision(3, 8, false);
        isSlide = false;
        yield return new WaitForSeconds(slideCoolDown);
        canSlide = true;
        animator.SetBool("isSlide", false);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        //animator.SetBool("isJumping", false);
    }
}
