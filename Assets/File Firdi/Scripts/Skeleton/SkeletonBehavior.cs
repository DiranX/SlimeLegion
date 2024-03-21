using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBehavior : MonoBehaviour
{
    public static SkeletonBehavior instance;

    public Rigidbody2D rb;
    [Space]
    [Header("Rolling")]
    public float slideSpeed;
    public float slideTime;
    public float slideCoolDown;
    public bool isSlide;
    public bool canSlide = true;
    [Header("Shoot")]
    public float bulletForce;
    private int ammoAmmount;
    public bool isShoot;
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public GameObject[] ammo;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        //for (int i = 0; i <= 5; i++)
        //{
        //    ammo[i].gameObject.SetActive(true); ;
        //}
        //ammoAmmount = 6;
    }

    // Update is called once per frame
    void Update()
    {
        ShootInput();

        if (Input.GetKeyDown(KeyCode.LeftShift) && canSlide)
        {
            StartCoroutine(BackDash());
        }

        if(isSlide == false)
        {
            SlimeMovement.instance.HorizontalMove();
        }

        SlimeMovement.instance.Flip();
    }
    public void ShootInput()
    {
        if (Input.GetMouseButtonDown(0) && !isShoot)
        {
            isShoot = true;
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(SlimeMovement.instance.transform.localScale.x, 0).normalized * bulletForce;
            //playerAudio.PlayOneShot(gunShoot, PlayerMove.instance.volume);
            //ammoAmmount -= 1;
            //ammo[ammoAmmount].gameObject.SetActive(false);
        }
    }
    public IEnumerator BackDash()
    {
        Vector2 arah = new Vector2(SlimeMovement.instance.transform.localScale.x * -slideSpeed, 30);
        isSlide = true;
        canSlide = false;
        //float gravity = rb.gravityScale;
        //rb.gravityScale = 0;
        animator.SetBool("isBack", true);
        //Physics2D.IgnoreLayerCollision(3, 7, true);
        //Physics2D.IgnoreLayerCollision(3, 8, true);
        rb.AddForce(arah, ForceMode2D.Impulse);
        yield return new WaitForSeconds(slideTime);
        //Physics2D.IgnoreLayerCollision(3, 7, false);
        //Physics2D.IgnoreLayerCollision(3, 8, false);
        //rb.gravityScale = gravity;
        isSlide = false;
        animator.SetBool("isBack", false);
        yield return new WaitForSeconds(slideCoolDown);
        canSlide = true;
    }
}
