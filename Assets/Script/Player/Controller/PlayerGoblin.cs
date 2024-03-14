using UnityEngine;

public class PlayerGoblin : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
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

        // ANIMASI LARI
        if (moveInput != 0f)
        {
            // Jika karakter bergerak, atur parameter Run menjadi true
            anim.SetBool("Run", true);
        }
        else
        {
            // Jika tidak, atur parameter Run menjadi false
            anim.SetBool("Run", false);
        }

        // Flip sprite jika karakter bergerak ke kiri
        if (moveInput < 0f)
        {
            transform.localScale = new Vector3(-3f, 3f, 0f);
        }
        else if (moveInput > 0f)
        {
            transform.localScale = new Vector3(3f, 3f, 0f);
        }

        // ANIMASI SERANG



    }
}
