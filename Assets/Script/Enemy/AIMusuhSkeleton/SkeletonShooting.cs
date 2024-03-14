using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player object not found!");
        }
    }

    void Update()
    {
        // Pengecekan apakah objek pemain masih ada sebelum menggunakan transformasinya
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < 10)
            {
                timer += Time.deltaTime;

                if (timer > 2)
                {
                    timer = 0;
                    Shoot();
                }
            }
        }
    }

    void Shoot()
    {
        // Pengecekan apakah objek peluru dan posisi peluru sudah ditetapkan
        if (bullet != null && bulletPos != null)
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Bullet object or bullet position is not assigned!");
        }
    }
}
