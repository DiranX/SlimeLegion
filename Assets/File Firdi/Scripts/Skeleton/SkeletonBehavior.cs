using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBehavior : MonoBehaviour
{
    public static SkeletonBehavior instance;

    public Rigidbody2D rb;
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
        if (Input.GetKeyDown(KeyCode.LeftShift) && canSlide)
        {
            StartCoroutine(BackDash());
        }

        if(isSlide == false)
        {
            SlimeMovement.instance.HorizontalMove();
        }

        SlimeMovement.instance.Flip();
    }
    public IEnumerator BackDash()
    {
        Vector2 arah = new Vector2(SlimeMovement.instance.transform.localScale.x * -slideSpeed, 30);
        isSlide = true;
        canSlide = false;
        //float gravity = rb.gravityScale;
        //rb.gravityScale = 0;
        //animator.SetBool("isSlide", true);
        //Physics2D.IgnoreLayerCollision(3, 7, true);
        //Physics2D.IgnoreLayerCollision(3, 8, true);
        rb.AddForce(arah, ForceMode2D.Impulse);
        yield return new WaitForSeconds(slideTime);
        //Physics2D.IgnoreLayerCollision(3, 7, false);
        //Physics2D.IgnoreLayerCollision(3, 8, false);
        //rb.gravityScale = gravity;
        isSlide = false;
        yield return new WaitForSeconds(slideCoolDown);
        canSlide = true;
        //animator.SetBool("isSlide", false);
    }
}
