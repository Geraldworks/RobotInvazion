using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    /// <summary>
    /// This script provides all the functionality for a node in the game.
    /// The node enables the player to purchases towers and place them into
    /// the game scene
    /// </summary>

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffSet;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffSet;
    }

    void OnMouseDown()
    {
        // May cause bugs
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("Can't build here(Display on screen later)");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        // May cause bugs
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    
}
