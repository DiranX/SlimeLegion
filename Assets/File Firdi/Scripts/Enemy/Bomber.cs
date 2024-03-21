using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    public float attackRange;
    public Animator anim;
    public Transform attackPoint;
    private GameObject Hitbox;
    public LayerMask playerMask;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Attacking());

        if(GetComponent<EnemyController>().Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Attacking()
    {
        Collider2D[] detectPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerMask);
        foreach (Collider2D item in detectPlayer)
        {
            yield return new WaitForSeconds(1f);
            anim.SetTrigger("Attack");
            StartCoroutine(DestroyObject());
            //Debug.Log("Hit Player");
        }
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
