using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TurretUI : MonoBehaviour
{
    [SerializeField] private GameObject turretCanvasUI;
    private Platform target;
    [SerializeField] private TMP_Text upgradeCostText;
    [SerializeField] private TMP_Text sellAmoutText;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button sellButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTarget(Platform targetUse)
    {
        target = targetUse;

        transform.position = target.GetBuildPosition();


        if (!target.isUpgraded)
        { 
            upgradeCostText.text = "$" + target.upgradedTurretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCostText.text = "Max";
            upgradeButton.interactable = false;
        }

        sellAmoutText.text = "$" + target.upgradedTurretBlueprint.GetSellCost();    

        turretCanvasUI.SetActive(true);
    }
    
    public void HideTurretUI()
    {
        turretCanvasUI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectPlatform();
    }

    public void Sell()
    {
        target.SellTorret();
        BuildManager.instance.DeselectPlatform();
    }
}
