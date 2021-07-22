using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuInteractions : MonoBehaviour
{
    public GameObject startup;
    public GameObject menu;
    public GameObject menuScreen;

    [Header("Credits")]
    private bool creditsloaded;
    public GameObject gameCredits;

    [Header("Version Selector")]
    public float currentVersion;
    public float mostRecentVersion;
    private bool versionPanelloaded;
    public GameObject versionSelectionPanel;
    public GameObject v001;
    public GameObject v002;
    public GameObject v003;
    public GameObject v004;

    [Header("Stats Selector")]
    private bool StatsPanelLoaded;
    private int TurretsPlacedCount;
    public static int EnemiesKilledCount2;
    private int EnemiesKilledCount;
    public static int MoneyEarnedCount;
    public static int WavesPlayedCount;
    public Text TurretsPlaced;
    public Text EnemiesKilled;
    public Text MoneyEarned;
    public Text WavesPlayed;
    public GameObject statsPanel;

    [Header("Level Selector")]
    private bool levelSelectPanelOpened;
    public GameObject levelSelectPanel;

    public Button level2Button;
    public Button level3Button;

    // LVL 2
    public static bool level2unlocked;
    // LVL 3
    public static bool level3unlocked;

    [Header("Settings Panel")]
    private bool settingsPanelOpened;
    public GameObject settingsPanel;

    [Header("Stats Panel")]
    private string username;
    public GameObject inputField;
    public GameObject usernameDisplay;

    void Start()
    {
        creditsloaded = false;
        versionPanelloaded = false;
        StatsPanelLoaded = false;
        levelSelectPanelOpened = false;
        settingsPanelOpened = false;

        level2Button.interactable = false;
        level3Button.interactable = false;
    }

    void Update()
    {
        if (AudioManager.begun == false)
        {
            menu.SetActive(false);
            startup.SetActive(true);
        }
        if (AudioManager.begun == true)
        {
            menu.SetActive(true);
            startup.SetActive(false);
        }

        TurretsPlacedCount = TurretPlacingScript.totalTurretBuilds;
        EnemiesKilledCount = EnemiesKilledCount2; 

        TurretsPlaced.text = "Turrets Placed:" + (TurretsPlacedCount);
        EnemiesKilled.text = "Enemies Killed:" + (EnemiesKilledCount);
        MoneyEarned.text = "Money Earned:" + (MoneyEarnedCount);
        WavesPlayed.text = "Waves Played:" + (WavesPlayedCount);

        //LVL 2
        if (level2unlocked == false)
        {
            level2Button.interactable = false;
        }
        if (level2unlocked == true)
        {
            level2Button.interactable = true;
        }

        //LVL 3
        if (level3unlocked == false)
        {
            level3Button.interactable = false;
        }
        if (level3unlocked == true)
        {
            level3Button.interactable = true;
        }

        if (currentVersion == 0.01f)
        {
            v001.SetActive(true);
            v002.SetActive(false);
            v003.SetActive(false);
            v004.SetActive(false);
        }
        if (currentVersion == 0.02f)
        {
            v001.SetActive(false);
            v002.SetActive(true);
            v003.SetActive(false);
            v004.SetActive(false);
        }
        if (currentVersion == 0.03f)
        {
            v001.SetActive(false);
            v002.SetActive(false);
            v003.SetActive(true);
            v004.SetActive(false);
        }
        if (currentVersion == 0.04f)
        {
            v001.SetActive(false);
            v002.SetActive(false);
            v003.SetActive(false);
            v004.SetActive(true);
        }
    }

    // PLAY BUTTON 

    public void PlaySelectedVersion()
    {
        if (currentVersion == 0.01f)
        {
            SceneManager.LoadScene("v0.01");
        }
        if (currentVersion == 0.02f)
        {
            SceneManager.LoadScene("v0.02");
            EnemySpawner.ES.Reset();
        }
        if (currentVersion == 0.03f)
        {
            SceneManager.LoadScene("v0.03");
            EnemySpawner.ES.Reset();
        }
        if (currentVersion == 0.04f)
        {
            SceneManager.LoadScene("v0.04");
            EnemySpawner.ES.Reset();
        }
    }

    public void LevelSelect()
    {
        if (levelSelectPanelOpened == false)
        {
            levelSelectPanelOpened = true;
            levelSelectPanel.SetActive(true);
            menuScreen.SetActive(false);
        }
        else
        {
            levelSelectPanelOpened = false;
            levelSelectPanel.SetActive(false);
            menuScreen.SetActive(true);
            buttonhover.bhinstance.deflateManual();
        }
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("v0.04");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("v0.04 (2)");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("v0.04 (3)");
    }

    // CREDITS 

    public void Credits()
    {
        if (creditsloaded == false)
        {
            creditsloaded = true;
            gameCredits.SetActive(true);
            menuScreen.SetActive(false);
        }
        else
        {
            creditsloaded = false;
            gameCredits.SetActive(false);
            menuScreen.SetActive(true);
            buttonhover.bhinstance.deflateManual();
        }
    }

    // VERSIONS

    public void Versions()
    {
        if (versionPanelloaded == false)
        {
            versionPanelloaded = true;
            versionSelectionPanel.SetActive(true);
            menuScreen.SetActive(false);
        }
        else
        {
            versionPanelloaded = false;
            versionSelectionPanel.SetActive(false);
            menuScreen.SetActive(true);
            buttonhover.bhinstance.deflateManual();
        }
    }

    public void PreviousVersion()
    {
        if (currentVersion >= 0.02f) // DO NOT CHANGE!
        {
            currentVersion -= 0.01f;
        }
    }

    public void NextVersion()
    {
        if (currentVersion < mostRecentVersion)
        {
            currentVersion += 0.01f;
        }
    }

    // QUIT

    public void CloseApplication()
    {
        Application.Quit();
        Debug.Log("Quit Application");
    }

    // STATS 

    public void Stats()
    {
        if (StatsPanelLoaded == false)
        {
            StatsPanelLoaded = true;
            statsPanel.SetActive(true);
            menuScreen.SetActive(false);
        }
        else
        {
            StatsPanelLoaded = false;
            statsPanel.SetActive(false);
            menuScreen.SetActive(true);
            buttonhover.bhinstance.deflateManual();
        }
    }

    // SOCIALS

    public void nathukadevYOUTUBE()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCZ9FLemb4cmGbZlCtuIkwpQ");
    }
    public void nathukadevDISCORD()
    {
        Application.OpenURL("https://discord.gg/CauTpgBckc");
    }
    public void imvo1tzTWITCH()
    {
        Application.OpenURL("https://www.twitch.tv/imvo1tz");
    }

    // SETTINGS

    public void Settings()
    {
        if (settingsPanelOpened == false)
        {
            settingsPanelOpened = true;
            settingsPanel.SetActive(true);
            menuScreen.SetActive(false);
        }
        else
        {
            settingsPanelOpened = false;
            settingsPanel.SetActive(false);
            menuScreen.SetActive(true);
            buttonhover.bhinstance.deflateManual();
        }
    }

    // ------------------------------------------------------------------------------------------------------------------- BREAK

    public void runM()
    {
        AudioManager.begun = true;
    }

    public void EnterUsername()
    {
        username = inputField.GetComponent<Text>().text;
        usernameDisplay.GetComponent<Text>().text = "" + username;
    }
}
