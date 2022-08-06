using UnityEngine;

public class BuildManager : MonoBehaviour
{
    /// <summary>
	/// This script helps to create an interface for turrets to be built in the game
	/// </summary>
	
    public static BuildManager instance;
    public GameObject NormalTurretPrefab;
    public GameObject AOETurretPrefab;
    public GameObject DOTTurretPrefab;
    public GameObject CCTurretPrefab;
    public GameObject SpecialTurretPrefab;

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    // Retrive AudioSource
    private AudioSource buildingSound;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    void Start()
    {
        buildingSound = GetComponents<AudioSource>()[0]; 
    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not Enough Money to build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject) Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);

        buildingSound.Play();

        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }

}
