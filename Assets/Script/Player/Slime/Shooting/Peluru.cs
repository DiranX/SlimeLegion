using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peluru : MonoBehaviour
{
    public Transform pointPeluru;
    public GameObject peluruPrefab;
    public float kecepatanPeluru = 20f;
    


    void Update()
    {
        if (Input.GetButtonDown("Fire1") )
        {
            shoot1();
        }
    }
    void shoot1()
    {
        GameObject bullet = Instantiate(peluruPrefab, pointPeluru.position, pointPeluru.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(pointPeluru.transform.localScale.x, 0.4f);
        rb.AddForce(arah * kecepatanPeluru, ForceMode2D.Impulse);
    }

}
