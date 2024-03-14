using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSkeleton : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public float waktu;

    //public GameObject destrotEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + -180);

    }

    // Update is called once per frame
    void Update()
    {
        waktu += Time.deltaTime;
        if (waktu > 10)
        {
            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<SlimeHealth>().health -= 20;
            DestroyPeluru();
            
        }
    }
    void DestroyPeluru()
    {
        //Instantiate(destrotEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
