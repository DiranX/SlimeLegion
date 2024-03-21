using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseActive : MonoBehaviour
{
    public GameObject Slime;
    private GoblinMovement Goblin;
    private SkeletonMovement Skeleton;
    private ZombieMovement Zombie;
    public GameObject[] spawnCorpse;
    public Transform spawnCorpsePos;

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
            //PlayerStatus.instance.corpseHealthValue = Goblin.goblinHealth;
            //SlimeMovement.instance.enabled = false;
        }
        if(SlimeMovement.instance.enemytoPosses[1].activeSelf == true)
        {
            //Skeleton.enabled = true;
            SlimeMovement.instance.runSpeed = Skeleton.runSpeed;
            //PlayerStatus.instance.corpseHealthValue = Skeleton.skeletonHealth;
            //SlimeMovement.instance.enabled = false;
        }
        if (SlimeMovement.instance.enemytoPosses[2].activeSelf == true)
        {
            //Zombie.enabled = true;
            SlimeMovement.instance.runSpeed = Zombie.runSpeed;
            //PlayerStatus.instance.corpseHealthValue = Zombie.zombieHealth;
            //SlimeMovement.instance.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Q) && SlimeMovement.instance.enemytoPosses[PossesEnemy.instance.iD].activeSelf == true)
        {
            SlimeMovement.instance.enemytoPosses[PossesEnemy.instance.iD].SetActive(false);
            Slime.SetActive(true);
            GameObject spawnnewCorpse = Instantiate(spawnCorpse[PossesEnemy.instance.iD],
                spawnCorpsePos.position, spawnCorpsePos.rotation);
            EnemyStatus corpseHealth = spawnnewCorpse.GetComponent<EnemyStatus>();
            corpseHealth.corpseHealthValue = PlayerStatus.instance.corpseHealthValue;
            PlayerStatus.instance.corpseHealthValue = 0;
        }

        if(PlayerStatus.instance.corpseHealthValue <= PlayerStatus.instance.playerHealth)
        {
            SlimeMovement.instance.enemytoPosses[PossesEnemy.instance.iD].SetActive(false);
            Slime.SetActive(true);
            PlayerStatus.instance.corpseHealthValue = 0;
        }
    }
}
