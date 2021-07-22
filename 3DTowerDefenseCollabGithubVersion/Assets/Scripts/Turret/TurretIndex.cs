using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretIndex : MonoBehaviour
{
    [Header("Error")]
    public Text errormsg;

    [Header("Turret Purchase Costs")]
    [SerializeField]
    public int railgunCost;
    [SerializeField]
    public int flamethrowerCost;
    [SerializeField]
    public int lightningCost;
    [SerializeField]
    public int minigunCost;
    [SerializeField]
    public int shotgunCost;

    private int currentTurretBuilds = 0;

    // Turret Selection UI 
    // I'll change this setup when more turrets are added.

    public void PurchaseRailgun()
    {
        if (CurrencyManager.currency >= railgunCost)
        {
            if (TurretPlacingScript.turretAlreadySelected == false)
            {
                currentTurretBuilds += 1;
                CurrencyManager.currency -= railgunCost;
                TurretPlacingScript.turretIndex = 1;
                Debug.Log("Purchased - Railgun");
                errormsg.text = "";
                TurretPlacingScript.turretAlreadySelected = true;
            }
            else
            {
                errormsg.text = "Turret Already Selected!";
            }
        }
    }

    public void PurchaseFlamethrower()
    {
        if (CurrencyManager.currency >= flamethrowerCost)
        {
            if (TurretPlacingScript.turretAlreadySelected == false)
            {
                currentTurretBuilds += 1;
                CurrencyManager.currency -= flamethrowerCost;
                TurretPlacingScript.turretIndex = 2;
                Debug.Log("Purchased - Flamethrower");
                errormsg.text = "";
                TurretPlacingScript.turretAlreadySelected = true;
            }
            else
            {
                errormsg.text = "Turret Already Selected!";
            }
        }
        else
        {
            errormsg.text = "Not Enough Money To Purchase!";
        }
    }

    public void PurchaseLightning()
    {
        if (CurrencyManager.currency >= lightningCost)
        {
            if (TurretPlacingScript.turretAlreadySelected == false)
            {
                currentTurretBuilds += 1;
                CurrencyManager.currency -= lightningCost;
                TurretPlacingScript.turretIndex = 3;
                Debug.Log("Purchased - Lightning");
                errormsg.text = "";
                TurretPlacingScript.turretAlreadySelected = true;
            }
            else
            {
                errormsg.text = "Turret Already Selected!";
            }
        }
        else
        {
            errormsg.text = "Not Enough Money To Purchase!";
        }
    }

    public void PurchaseMinigun()
    {
        if (CurrencyManager.currency >= minigunCost)
        {
            if (TurretPlacingScript.turretAlreadySelected == false)
            {
                currentTurretBuilds += 1;
                CurrencyManager.currency -= minigunCost;
                TurretPlacingScript.turretIndex = 4;
                Debug.Log("Purchased - Minigun");
                errormsg.text = "";
                TurretPlacingScript.turretAlreadySelected = true;
            }
            else
            {
                errormsg.text = "Turret Already Selected!";
            }
        }
        else
        {
            errormsg.text = "Not Enough Money To Purchase!";
        }
    }

    public void PurchaseShotgun()
    {
        if (CurrencyManager.currency >= shotgunCost)
        {
            if (TurretPlacingScript.turretAlreadySelected == false)
            {
                currentTurretBuilds += 1;
                CurrencyManager.currency -= shotgunCost;
                TurretPlacingScript.turretIndex = 5;
                Debug.Log("Purchased - Shotgun");
                errormsg.text = "";
                TurretPlacingScript.turretAlreadySelected = true;
            }
            else
            {
                errormsg.text = "Turret Already Selected!";
            }
        }
        else
        {
            errormsg.text = "Not Enough Money To Purchase!";
        }
    }

}
