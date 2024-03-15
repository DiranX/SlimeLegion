using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterType : MonoBehaviour
{

    private MonsterType monsterType;

    // Start is called before the first frame update
    void Start()
    {
        monsterType = new Slime();
    }

    // Update is called once per frame
    void Update()
    {
        monsterType.Start();
        monsterType.Update();
        monsterType.Move();
        monsterType.Flip();
    }
    public virtual void Move()
    {

    }

    public virtual void Flip()
    {

    }
}

[SerializeField]
public class Slime : MonsterType
{
    private float horizontal;
    private bool isFacingRight = true;
    public float runSpeed;
    private float horizontalMove = 0f;
    private Animator animator;
    public Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    public override void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * runSpeed, rb.velocity.y);
    }
    public override void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
