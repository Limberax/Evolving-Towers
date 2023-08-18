using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Platform : MonoBehaviour
{

    [Header("Attributes")]
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color startColor;
    [SerializeField] private Color notEnoughtMoney;
    private Renderer render;

    [Header("Requires Fields")]
    [SerializeField] private Vector3 offSetTower;
    [SerializeField] private Quaternion towerRotation;
    

    public GameObject turret;
    public TurretBlueprints upgradedTurretBlueprint;
    public bool isUpgraded = false;
    private Quaternion newRotation;

    
    public Vector3 GetBuildPosition()
    {
        return transform.position + offSetTower;
    }
    

    BuildManager buildManager;

    void Start()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;
        towerRotation = transform.rotation;
        newRotation = towerRotation * Quaternion.Euler(-90f, 0f, 0f);

        buildManager = BuildManager.instance;
    }

    

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            render.material.color = hoverColor;
        }
        else
        {
            render.material.color = notEnoughtMoney;
        }    
    }

    private void OnMouseExit()
    {
        render.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;



        if (turret != null)
        {
            buildManager.SelectPlatform(this);


            return;
        }
            

        if (!buildManager.CanBuild)
            return;

        //buildManager.BuildTurretOn(this);
        BuildTurret(buildManager.GetTurretToBuild());
    }

    public void BuildTurret(TurretBlueprints blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        GameObject _turret = Instantiate(blueprint.prefab, GetBuildPosition(), blueprint.prefab.transform.rotation);
        turret = _turret;
        upgradedTurretBlueprint = blueprint;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < upgradedTurretBlueprint.upgradeCost)
        {
            return;
        }
        //Destroy old turret
        Destroy(turret);

        //Instantiate the upgrade turret
        PlayerStats.Money -= upgradedTurretBlueprint.upgradeCost;
        GameObject _turret = Instantiate(upgradedTurretBlueprint.upgradedPrefab, GetBuildPosition(), upgradedTurretBlueprint.upgradedPrefab.transform.rotation);
        turret = _turret;
        

        isUpgraded = true;
    }

    public void SellTorret()
    {
        PlayerStats.Money += upgradedTurretBlueprint.GetSellCost();

        Destroy(turret);
        upgradedTurretBlueprint = null;
    }
        
}
