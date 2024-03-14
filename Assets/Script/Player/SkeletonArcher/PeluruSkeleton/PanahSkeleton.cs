using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanahSkeleton : MonoBehaviour
{
    public Transform pointpanah;
    public GameObject panahPrefab;
    public float kecepatanPeluru = 20f;



    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            panahSkeleton();


        }


    }






    void panahSkeleton()
    {


        GameObject bullet = Instantiate(panahPrefab, pointpanah.position, pointpanah.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(pointpanah.right * kecepatanPeluru, ForceMode2D.Impulse);


    }
}
