using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //GameObjectInput
    public GameObject slimeObject;
    public GameObject GoblinObject;
    public GameObject SkeletonPlayer;
    public GameObject ZombiePlayer;


    private PlayerSlimeController slimeController;
    private PlayerGoblin goblinController;
    private SkeletonController skeletonControl;
    private ZombieController zombieController;

    void Start()
    {
        slimeController = gameObject.AddComponent<PlayerSlimeController>();
        goblinController = gameObject.AddComponent<PlayerGoblin>();
        skeletonControl = gameObject.AddComponent<SkeletonController>();
        zombieController = gameObject.AddComponent<ZombieController>();
        
        slimeController.enabled = true;
        slimeObject.SetActive(true);
    }

    void Update()
    {



        if (Input.GetKeyDown(KeyCode.F))
        {
            // Aktifkan PlayerSlimeController dan nonaktifkan PlayerGoblinController
            slimeController.enabled = true;
            goblinController.enabled = false;
            skeletonControl.enabled = false;
            zombieController.enabled = false;
            slimeObject.SetActive(true);
            GoblinObject.SetActive(false);
            SkeletonPlayer.SetActive(false);
            ZombiePlayer.SetActive(false) ;
        }
        else if  (Input.GetKeyDown(KeyCode.G))
        {
          
            // Aktifkan PlayerGoblinController dan nonaktifkan PlayerSlimeController
                slimeController.enabled = false;
                goblinController.enabled = true;
                skeletonControl.enabled = false;
                zombieController.enabled = false;
                GoblinObject.SetActive(true);
                slimeObject.SetActive(false);
                SkeletonPlayer.SetActive(false);
                ZombiePlayer.SetActive(false);

        }else if  (Input.GetKeyDown(KeyCode.J))
        {
          
            // Aktifkan PlayerGoblinController dan nonaktifkan PlayerSlimeController
                slimeController.enabled = false;
                goblinController.enabled = false;
                skeletonControl.enabled = false;
                zombieController.enabled = true;

                GoblinObject.SetActive(false);
                slimeObject.SetActive(false);
                SkeletonPlayer.SetActive(false);
                ZombiePlayer.SetActive(true);


        }

         else
        {
            if (Input.GetKeyDown(KeyCode.H))
            {// Aktifkan PlayerGoblinController dan nonaktifkan PlayerSlimeController
                slimeController.enabled = false;
                goblinController.enabled = false;
                skeletonControl.enabled = true;
                zombieController.enabled = false;
                GoblinObject.SetActive(false);
                slimeObject.SetActive(false);
                SkeletonPlayer.SetActive(true);
                ZombiePlayer.SetActive(false);
            }
        }
    }
}
