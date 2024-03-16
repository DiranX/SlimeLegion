using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public static SlimeMovement instance;

    public GameObject[] enemytoPosses;

    public float runSpeed;
    public float originalSpeed;
    private float horizontalMove = 0f;
    private float horizontal;
    private bool isFacingRight = true;
    private Rigidbody2D rb;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PossesEnemy.instance.gameObject.active == false)
        {
            animator = GetComponentInChildren<Animator>();
            //GetComponent<SlimeMovement>().enabled = false;
            PossesEnemy.instance.isPosses = false;
            PossesEnemy.instance.enemyisDead = false;
            //StartCoroutine(Wait());
            enemytoPosses[PossesEnemy.instance.iD].SetActive(true);
        }
        else if(PossesEnemy.instance.gameObject.activeSelf == true)
        {
            runSpeed = originalSpeed;
        }

        //Player Move
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if(SlimeBehavior.instance.isSlide == false)
        {
            HorizontalMove();
        }
        Flip();
    }
    public void HorizontalMove()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * runSpeed, rb.velocity.y);
    }
    public void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        enemytoPosses[PossesEnemy.instance.iD].SetActive(true);
    }
}
