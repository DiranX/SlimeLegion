using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public static EnemyStatus instance;
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
            DestroyImmediate(gameObject);
            isdead = false;
            PossesEnemy.instance.gameObject.SetActive(false);
            PossesEnemy.instance.iD = iD;
        }
    }
}
