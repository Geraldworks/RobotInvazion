using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseNormalTurret()
    {
        Debug.Log("Normal Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.NormalTurretPrefab);
    }

    public void PurchaseAOETurret()
    {
        Debug.Log("AOE Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.AOETurretPrefab);
    }

    public void PurchaseDOTTurret()
    {
        Debug.Log("DOT Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.DOTTurretPrefab);
    }

    public void PurchaseCCTurret()
    {
        Debug.Log("CC Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.CCTurretPrefab);
    }

    public void PurchaseSpecialTurret()
    {
        Debug.Log("Special Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.SpecialTurretPrefab);
    }
}
