using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Peluru : MonoBehaviour
{
    public Transform pointPeluru;
    public GameObject peluruPrefab;
    public float kecepatanPeluru;
    public float jumlahPeluru;
    public TextMeshProUGUI JumlahPeluruUI;

    void Update()
    {
        JumlahPeluruUI.text = "" + jumlahPeluru;

        if (Input.GetButtonDown("Fire1"))
        {
            jumlahPeluru -= 1;
            if (jumlahPeluru >= 0)
            {
                shoot1();
            }
            SlimeBehavior.instance.animator.Play("Shoot");
        }

        if(jumlahPeluru <= 0)
        {
            jumlahPeluru = 0;
            StartCoroutine(RestorePeluru());
        }
    }
    IEnumerator RestorePeluru()
    {
        yield return new WaitForSeconds(1);

        jumlahPeluru = 3;
    }
    void shoot1()
    {
        GameObject bullet = Instantiate(peluruPrefab, pointPeluru.position, pointPeluru.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(SlimeMovement.instance.transform.localScale.x * kecepatanPeluru, 8f);
        rb.AddForce(arah , ForceMode2D.Impulse);
    }

}
