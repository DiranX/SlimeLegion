using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peluru : MonoBehaviour
{
    public Transform pointPeluru;
    public GameObject peluruPrefab;
    public float kecepatanPeluru;
    


    void Update()
    {
        if (Input.GetButtonDown("Fire1") )
        {
            shoot1();
            SlimeBehavior.instance.animator.Play("Shoot");
        }
    }
    void shoot1()
    {
        GameObject bullet = Instantiate(peluruPrefab, pointPeluru.position, pointPeluru.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(SlimeMovement.instance.transform.localScale.x * kecepatanPeluru, 8f);
        rb.AddForce(arah , ForceMode2D.Impulse);
    }

}
