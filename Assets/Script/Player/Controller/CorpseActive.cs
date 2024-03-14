using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseActive : MonoBehaviour
{
    public GameObject Slime;
    private SkeletonMovement Skeleton;

    // Start is called before the first frame update
    void Start()
    {
        Skeleton = GetComponent<SkeletonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SlimeMovement.instance.enemytoPosses[1].activeSelf == true)
        {
            Skeleton.enabled = true;
            SlimeMovement.instance.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SlimeMovement.instance.enemytoPosses[PossesEnemy.instance.iD].SetActive(false);
            Slime.SetActive(true);
            SlimeMovement.instance.enabled = true;
            Skeleton.enabled = false;
        }
    }
}
