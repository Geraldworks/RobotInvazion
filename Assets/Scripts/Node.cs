using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColer;
    public Vector3 positionOffSet;

    private GameObject turret;
    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build here(Display on screen later)");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuilt();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffSet, transform.rotation);


    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColer;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    
}
