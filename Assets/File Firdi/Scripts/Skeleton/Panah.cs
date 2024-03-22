using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panah : MonoBehaviour
{
    public float arrowDamage;
    SpriteRenderer sprite;
    public bool flip;
    //public Transform playerPos;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Flip();
    }

    void Flip()
    {
        Vector2 scale = transform.localScale;
        if (SlimeMovement.instance.transform.position.x <= transform.position.x)
        {
            sprite.flipX = false;
        }
        else if(SlimeMovement.instance.transform.position.x >= transform.position.x)
        {
            sprite.flipX = true;
        }
        transform.localScale = scale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && collision.gameObject.GetComponent<EnemyController>().Health > 0)
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(arrowDamage);
        }
        if (collision.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
