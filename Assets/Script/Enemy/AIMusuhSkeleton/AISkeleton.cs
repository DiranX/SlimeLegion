using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISkeleton : MonoBehaviour
{
    public string targetTag = "Player";
    public float moveSpeed = 5f; // Kecepatan bergerak musuh
    public float stoppingDistance = 2f;
    public float followDistance = 5f; // Jarak di mana musuh mulai mengikuti pemain
    private Transform target;
    private bool facingRight = true;
    private bool isFollowing = false; // Menentukan apakah musuh sedang mengikuti pemain
    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag(targetTag).transform;
        anim = GetComponent<Animator>(); // Inisialisasi Animator
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            Vector3 directionToTarget = target.position - transform.position;

            // Cek apakah musuh harus mulai mengikuti pemain
            if (distanceToTarget <= followDistance)
            {
                isFollowing = true;
            }

            if (isFollowing)
            {
                //anim.SetBool("Running", true);
                if (distanceToTarget > stoppingDistance)
                {
                    Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
                    rb.MovePosition(newPosition);
                }
                else
                {
                    anim.SetBool("Running", false); // Berhenti berlari ketika mencapai stoppingDistance
                    // Tambahan perilaku di sini jika diperlukan (mis. animasi serangan atau perilaku spesifik)
                }

                // Flip musuh jika diperlukan
                if (directionToTarget.x < 0 && facingRight)
                {
                    Flip();
                }
                else if (directionToTarget.x > 0 && !facingRight)
                {
                    Flip();
                }
            }
            else
            {
                // Musuh diam jika pemain belum mendekat
                //anim.SetBool("Running", false);
            }
        }
        else
        {
            // Handle kasus di mana target tidak ditemukan (mis., pemain telah dihancurkan)
            //anim.SetBool("Running", false);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
