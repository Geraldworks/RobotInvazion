using UnityEngine;

public class Shop : MonoBehaviour
{
    /// <summary>
    /// This script enables the user to interact with the shop system,
    /// where he is able to spend money to purchase turrets that can be
    /// placed on the nodes in the game scene
    /// </summary>

    public TurretBlueprint normalTurret;
    public TurretBlueprint AOETurret;
    public TurretBlueprint DOTTurret;
    public TurretBlueprint SpecialTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectNormalTurret()
    {
        Debug.Log("Normal Turret Selected");
        buildManager.SelectTurretToBuild(normalTurret);
    }

    public void SelectAOETurret()
    {
        Debug.Log("AOE Turret Selected");
        buildManager.SelectTurretToBuild(AOETurret);
    }

    public void SelectDOTTurret()
    {
        Debug.Log("DOT Turret Selected");
        buildManager.SelectTurretToBuild(DOTTurret);
    }

    public void SelectSpecialTurret()
    {
        Debug.Log("Special Turret Selected");
        buildManager.SelectTurretToBuild(SpecialTurret);
    }
}
