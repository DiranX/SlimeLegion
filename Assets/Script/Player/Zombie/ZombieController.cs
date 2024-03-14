using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float jumpForce = 5f;
    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Mendapatkan input horizontal
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Menggerakkan pemain
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Loncat jika tombol space ditekan
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        

        // Flip sprite jika karakter bergerak ke kiri
        if (moveInput < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 0f);
        }
        else if (moveInput > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 0f);
        }

        // ANIMASI SERANG



    }
}
