using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    [Header("General")]
    public GameObject gameManager;
    public GameObject infoScreen;
    public static bool gameStarted;
    public bool panelonoff; // false = off , true = on //

    [Header("Turret Selection")]
    private GameObject currentlyOpenedPanel;
    public GameObject railgunPanel;
    public GameObject flamethrowerPanel;
    public GameObject lightningPanel;
    public GameObject minigunPanel;
    public GameObject shotgunPanel;

    public GameObject panelNum1;
    public GameObject panelNum2;

    private bool TurretpanelAlreadyOpened;

    void Start()
    {
        TurretpanelAlreadyOpened = false;
        Time.timeScale = 0;
        gameStarted = false;
        panelonoff = false;

        panelNum1.SetActive(true);
        panelNum2.SetActive(false);
    }

    public void StartButton()
    {
       if (Enemy.GameOver == false)
        {
            Time.timeScale = 1;
            gameStarted = true;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void ResetButton()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        gameManager.GetComponent<EnemySpawner>().Reset();
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
    }

    public void InfoButton()
    {
        // Lazy code I might fix later
        if (panelonoff == false)
        {
            panelonoff = true;
        }
        else
        {
            panelonoff = false;  
        }

        if(panelonoff == false)
        {
            infoScreen.SetActive(false);
        }
        else if (panelonoff == true)
        {
            infoScreen.SetActive(true);
        }
        
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Non-General

    public void CloseTurretPanel()
    {
        Time.timeScale = 1;
        currentlyOpenedPanel.SetActive(false);
        TurretpanelAlreadyOpened = false;
    }

    public void OpenRailgunTurretPanel()
    {
        if(!TurretpanelAlreadyOpened)
        {
            Time.timeScale = 0;
            railgunPanel.SetActive(true);
            currentlyOpenedPanel = railgunPanel;
            TurretpanelAlreadyOpened = true;
        }
    }
    public void OpenFlamethrowerTurretPanel()
    {
        if (!TurretpanelAlreadyOpened)
        {
            Time.timeScale = 0;
            flamethrowerPanel.SetActive(true);
            currentlyOpenedPanel = flamethrowerPanel;
            TurretpanelAlreadyOpened = true;
        }
    }
    public void OpenLightningTurretPanel()
    {
        if (!TurretpanelAlreadyOpened)
        {
            Time.timeScale = 0;
            lightningPanel.SetActive(true);
            currentlyOpenedPanel = lightningPanel;
            TurretpanelAlreadyOpened = true;
        }
    }
    public void OpenMinigunTurretPanel()
    {
        if (!TurretpanelAlreadyOpened)
        {
            Time.timeScale = 0;
            minigunPanel.SetActive(true);
            currentlyOpenedPanel = minigunPanel;
            TurretpanelAlreadyOpened = true;
        }
    }
    public void OpenShotgunTurretPanel()
    {
        if (!TurretpanelAlreadyOpened)
        {
            Time.timeScale = 0;
            shotgunPanel.SetActive(true);
            currentlyOpenedPanel = shotgunPanel;
            TurretpanelAlreadyOpened = true;
        }
    }

    public void Prev1()
    {
        panelNum1.SetActive(true);
        panelNum2.SetActive(false);
    }
    public void Next2()
    {
        panelNum1.SetActive(false);
        panelNum2.SetActive(true);
    }


}
