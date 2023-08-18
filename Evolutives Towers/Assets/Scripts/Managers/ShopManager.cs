using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprints archerTurret;
    public TurretBlueprints missilLauncher;
    public TurretBlueprints magicTower;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectArcherTurret()
    {
        buildManager.SelectTurretToBuild(archerTurret);
    }
    public void SelectMissilLauncher()
    {
        buildManager.SelectTurretToBuild(missilLauncher);
    }

    public void SelectMagicTower()
    {
        buildManager.SelectTurretToBuild(magicTower);
    }
}
