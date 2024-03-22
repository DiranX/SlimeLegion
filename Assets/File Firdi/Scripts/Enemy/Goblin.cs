using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
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
        if (EnemyController.instance.isStun == true)
        {
            return;
        }

        StartCoroutine(Attacking());
    }

    IEnumerator Attacking()
    {
        Collider2D[] detectPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerMask);
        foreach (Collider2D item in detectPlayer)
        {
            yield return new WaitForSeconds(1f);
            anim.SetTrigger("Attack");
            //Debug.Log("Hit Player");
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
