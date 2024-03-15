using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseActive : MonoBehaviour
{
    public GameObject Slime;
    private GoblinMovement Goblin;
    private SkeletonMovement Skeleton;
    private ZombieMovement Zombie;

    // Start is called before the first frame update
    void Start()
    {
        Goblin = GetComponent<GoblinMovement>();
        Skeleton = GetComponent<SkeletonMovement>();
        Zombie = GetComponent<ZombieMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SlimeMovement.instance.enemytoPosses[0].active == true)
        {
            //Goblin.enabled = true;
            SlimeMovement.instance.runSpeed = Goblin.runSpeed;
            //SlimeMovement.instance.enabled = false;
        }
        if(SlimeMovement.instance.enemytoPosses[1].activeSelf == true)
        {
            //Skeleton.enabled = true;
            SlimeMovement.instance.runSpeed = Skeleton.runSpeed;
            //SlimeMovement.instance.enabled = false;
        }
        if (SlimeMovement.instance.enemytoPosses[2].activeSelf == true)
        {
            //Zombie.enabled = true;
            SlimeMovement.instance.runSpeed = Zombie.runSpeed;
            //SlimeMovement.instance.enabled = false;
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
