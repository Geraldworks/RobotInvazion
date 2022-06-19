using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint normalTurret;
    public TurretBlueprint AOETurret;
    public TurretBlueprint DOTTurret;
    public TurretBlueprint CCTurret;
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

    public void SelectCCTurret()
    {
        Debug.Log("CC Turret Selected");
        buildManager.SelectTurretToBuild(CCTurret);
    }

    public void SelectSpecialTurret()
    {
        Debug.Log("Special Turret Selected");
        buildManager.SelectTurretToBuild(SpecialTurret);
    }
}
