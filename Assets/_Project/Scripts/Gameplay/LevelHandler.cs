using System.Collections.Generic;
using UnityEngine;



public class LevelHandler : MonoBehaviour
{
    [Header("Character Selection")]
    public Transform VehiclespawnPoint;
    //public Transform EndvehicleSpawnPoint;
    //public GameObject endCamera;
    public GameObject Fireworks;
    //public GameObject CharacterModel;

    //[Header("Character Selection")]
    //public List<GameObject> CharacterspawnPoint;
    //public List<Transform> CheckPoints;

    //public List<GameObject> Finalvehicleslist;
    //public List<GameObject> Custcene;
    [Tooltip("This is used for skybox")]
    public Material Skybox;

    //public List<GameObject> ListofProsOptmization;
    //public AudioClip Soundsforspecificlevel;
    private GameObject character;
    //[Tooltip("This is only used in level 1 for tutorial")]
     //public GameObject EndLookAtCamera;

    private void Start()
    {


        GameplayController.Instance.Levelhandler = this;
        LevelStartHandling();
        RenderSettings.skybox = Skybox;
    }
  

    public void LevelStartHandling()
    {


        //if (Soundsforspecificlevel)
        //    SoundsManager.Instance.PlayMusic_Game(Soundsforspecificlevel);

        SpawnVehicle();

    }
    private void SpawnVehicle()
    {
        print("Path :"+ Constants.folderPath_Prefabs + Constants.folderPath_Prefabs_PlayerVehicles + Constants.Getprefs(Constants.LastSelectedVehicle));
        GameplayController.Instance.SelectedVehiclePrefab = Resources.Load<GameObject>(Constants.folderPath_Prefabs + Constants.folderPath_Prefabs_PlayerVehicles + Constants.Getprefs(Constants.LastSelectedVehicle));
        GameplayController.Instance.VehicleSpawnPoint = VehiclespawnPoint;
        GameplayController.Instance.Gamestart();
    }
   

}