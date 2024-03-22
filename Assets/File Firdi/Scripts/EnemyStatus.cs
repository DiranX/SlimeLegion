using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public static EnemyStatus instance;
    public float corpseHealthValue;
    public bool isdead;
    public int iD;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (PossesEnemy.instance.isPosses == true && isdead == true)
        {
            StartCoroutine(Wait());
            //Destroy(gameObject);
            isdead = false;
            SlimeBehavior.instance.animator.SetTrigger("Posses");
            //PossesEnemy.instance.gameObject.SetActive(false);
            PossesEnemy.instance.iD = iD;
            PlayerStatus.instance.corpseHealthValue = PlayerStatus.instance.playerHealth + corpseHealthValue;
        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        DestroyImmediate(gameObject);
    }
}
