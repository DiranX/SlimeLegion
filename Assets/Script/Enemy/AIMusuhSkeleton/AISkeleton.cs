using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISkeleton : MonoBehaviour
{
    public static EnemyController instance;

    public float Health;
    public float walkSpeed;
    public bool flip;
    public float detectRange;
    public GameObject detect;
    public Transform playerPos;
    public LayerMask playerlayer;
    public Animator anim;
    private AudioSource enemySound;
    public AudioClip hurt;
    public AudioClip die;
    public float volume;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //instance = this;
    }
    // Update is called once per frame
    void Update()
    {

        enemySound = GetComponent<AudioSource>();
        StartCoroutine(DetectPlayer());

        StartCoroutine(Flip());
        //if (PlayerStatus.instance.isDie)
        //{
        //    anim.enabled = false;
        //    this.enabled = false;
        //}
        //Physics2D.IgnoreLayerCollision(7, 7);
    }
    IEnumerator DetectPlayer()
    {
        //Vector2 Direction = (playerPos.position + transform.position)/2;
        Collider2D[] enemyDetect = Physics2D.OverlapCircleAll(detect.transform.position, detectRange, playerlayer);
        RaycastHit2D DetectPlayer = Physics2D.Raycast(detect.transform.position, Vector2.left, detectRange, playerlayer);

        if (DetectPlayer.collider == null)
        {

        }
        yield return new WaitForSeconds(0.5f);
        foreach (Collider2D player in enemyDetect)
        {
            rb.velocity = new Vector2(transform.localScale.x * -walkSpeed, 3);
            anim.SetTrigger("backDash");
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (detect == null) return;

        Gizmos.DrawWireSphere(detect.transform.position, detectRange);
    }

    IEnumerator Flip()
    {
        Vector2 scale = transform.localScale;
        if (playerPos.position.x > transform.position.x)
        {
            yield return new WaitForSeconds(.1f);
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
        }
        else
        {
            yield return new WaitForSeconds(.1f);
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);


        }
        transform.localScale = scale;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        anim.SetTrigger("Hurt");

        if (Health <= 0)
        {
            Die();
            Health = 0;
        }
        //enemySound.PlayOneShot(hurt, volume);
    }
    void Die()
    {
        anim.SetBool("isDead", true);
        enemySound.PlayOneShot(die, volume);
        this.enabled = false;
        //GetComponent<Collider2D>().enabled = false;
        rb.gravityScale = 1;
        Debug.Log("Musuh Mati");
    }
}
