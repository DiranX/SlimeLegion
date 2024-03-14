using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 0f;
    public float dashForce = 0f;
    public float dashDuration = 0.2f; // Durasi dash dalam detik
    public float dashCooldown = 1f; // Cooldown antara dash dalam detik

    private Rigidbody2D rb;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private float dashCooldownTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        // Mendapatkan input horizontal
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Gerakan horizontal selama tidak sedang dash
        if (!isDashing)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }

        // Loncat jika tombol space ditekan
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Dash jika tombol shift ditekan dan cooldown telah berakhir
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimer <= 0f)
        {
            isDashing = true;
            dashTimer = dashDuration;
            rb.velocity = new Vector2(moveInput * dashForce, rb.velocity.y);
            dashCooldownTimer = dashCooldown;
        }

        // Menghitung durasi dash dan cooldown
        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0f)
            {
                isDashing = false;
            }
        }
        else
        {
            dashCooldownTimer -= Time.deltaTime;
        }
    }
}
