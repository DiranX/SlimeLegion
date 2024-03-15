using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossesEnemy : MonoBehaviour
{
    public static PossesEnemy instance;
    public int iD;
    public bool isPosses;
    public bool enemyisDead;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        PossesEnemys();
    }

    public void PossesEnemys()
    {
        if (Input.GetKeyDown(KeyCode.E) && enemyisDead == true)
        {
            isPosses = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyStatus>().isdead = true;

            if (collision.gameObject.GetComponent<EnemyStatus>().isdead == true)
            {
                enemyisDead = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyStatus>().isdead = false;
        }
    }
}
