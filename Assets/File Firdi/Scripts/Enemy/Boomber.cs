using UnityEngine;

public class Boomber : MonoBehaviour
{
    public float chaseSpeed = 5f;
    public float patrolSpeed = 2f;
    public float detectionRange = 5f;

    private Transform player;
    private bool isChasing = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Cek jarak antara musuh dan pemain
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Jika pemain berada dalam jarak deteksi, mulai mengejar
        if (distanceToPlayer <= detectionRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        // Jika sedang mengejar, gerakkan musuh ke arah pemain
        if (isChasing)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 movement = direction * chaseSpeed * Time.deltaTime;
            transform.Translate(new Vector3(movement.x, 0f, 0f));
        }
        else
        {
            // Jika tidak mengejar pemain, gerakkan musuh secara otomatis ke kiri dan kanan
            transform.Translate(Vector3.right * Mathf.Sin(Time.time) * patrolSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Jika terjadi tabrakan dengan objek yang memiliki tag "Batasboomber", balik arah gerakan otomatis
        if (collision.gameObject.CompareTag("Batasboomber"))
        {
            patrolSpeed *= -1; // Balik arah gerakan otomatis
        }
    }
}
