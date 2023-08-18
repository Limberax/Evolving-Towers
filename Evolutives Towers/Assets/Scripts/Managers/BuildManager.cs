using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [SerializeField] private TurretBlueprints turretToBuild;
    private Platform selectedPlatform;
    [SerializeField] private TurretUI turretUI;
    

    public bool CanBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }
    public bool HasMoney
    {
        get
        {
            return PlayerStats.Money >= turretToBuild.cost;
        }
    }
    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    public void SelectPlatform(Platform platform)
    {
        if(selectedPlatform == platform)
        {
            DeselectPlatform();
            return;
        }

        selectedPlatform = platform;
        turretToBuild = null;

        turretUI.SetTarget(platform);
    }

    public void DeselectPlatform()
    {
        selectedPlatform = null;
        turretUI.HideTurretUI();
    }

    public void SelectTurretToBuild(TurretBlueprints turretBP)
    {
        turretToBuild = turretBP;
        DeselectPlatform();
    }

    public TurretBlueprints GetTurretToBuild() 
    {
        return turretToBuild;
    }

   /* public void BuildTurretOn(Platform platform)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = Instantiate(turretToBuild.prefab, platform.GetBuildPosition(), turretToBuild.prefab.transform.rotation);
        platform.turret = turret;
    }
   */

}
