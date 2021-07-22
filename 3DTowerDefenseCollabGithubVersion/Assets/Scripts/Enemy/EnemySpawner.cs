using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner ES;

    [Header("VersionConfig")]
    public static float standardVersionNum = 0.03f;

    [Header("Enemies")]
    public Transform enemyPrefab; // 1
    public Transform fastenemyPrefab; // 2
    public Transform weakenemyPrefab; // 3
    public Transform slowenemyPrefab; // 4
    public Transform bruteenemyPrefab; // 5

    [Header("Transform")]
    public Transform FastenemySpawner;
    public Transform MediumenemySpawner;
    public Transform SlowenemySpawner;

    public Vector3 enemyOffset;
    public float spawnOffset;

    public bool isX;
    public bool isY;
    public bool isZ;

    [Header("Variables")]
    [SerializeField]
    public float timeBetweenWaves = 7f;
    public float countdown = 5.5f;
    public int maxAllowedToEnter = 10;
    public static int currentEntered = 0;
    public int currentWave;
    [SerializeField]
    public int wavesToWin;
    private int enemyToSpawn = 0;
    private int enemyToSpawnRandomizer;

    private int LoadedScene;

    private int waveIndex = 0;

    [Header("UI")]
    public Text EnemiesEnteredCounter;
    public Text WaveCounter;
    public GameObject gameOverScreen;
    public GameObject gameWonScreen;

    void Update()
    {
        GameOverCheck();

        LoadedScene = SceneManager.GetActiveScene().buildIndex;

        EnemiesEnteredCounter.text = "Invaded:" + (currentEntered);
        WaveCounter.text = "Wave:" + (currentWave);

        if (standardVersionNum >= 0.02f)
        {
            GameWonCheck();
        }

        if (countdown <= 0f && maxAllowedToEnter > currentEntered)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
            Debug.Log("Wave " + currentWave);
        }

        if (ButtonUI.gameStarted == true)
        {
            countdown -= Time.deltaTime;
        }
    }

    public void SpawnWave()
    {
        waveIndex++;
        currentWave += 1;
        countdown++;
        MainMenuInteractions.WavesPlayedCount += 1;

        for (int i = 0; i < waveIndex; i++)
        {
            EnemySpawning();
        }
    }

    void EnemySpawning()
    {
        if (standardVersionNum == 0.01f)
        {
            enemyToSpawn = 1;
            SpawnEnemy();
        }

        if (standardVersionNum >= 0.02f)
        {
            spawnOffset = Random.Range(-0f, -15f);

            if (isZ == true)
            {
                enemyOffset = new Vector3(0f, 0f, -(spawnOffset));
            }
            if (isY == true)
            {
                enemyOffset = new Vector3(0f, -(spawnOffset), 0f);
            }
            if (isX == true)
            {
                enemyOffset = new Vector3(-(spawnOffset), 0f, 0f);
            }

            enemyToSpawnRandomizer = Random.Range(0, 100);

            if (enemyToSpawnRandomizer >= 0 && enemyToSpawnRandomizer <= 50)
            {
                enemyToSpawn = 1;
            }
            else if (enemyToSpawnRandomizer >= 51 && enemyToSpawnRandomizer <= 55)
            {
                enemyToSpawn = 2;
            }
            else if (enemyToSpawnRandomizer >= 56 && enemyToSpawnRandomizer <= 70)
            {
                enemyToSpawn = 3;
            }
            else if (enemyToSpawnRandomizer >= 71 && enemyToSpawnRandomizer <= 90)
            {
                enemyToSpawn = 4;
            }
            else if (enemyToSpawnRandomizer >= 91 && enemyToSpawnRandomizer <= 100)
            {
                enemyToSpawn = 5;
            }

            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (enemyToSpawn == 1)
        {
            Instantiate(enemyPrefab, MediumenemySpawner.position - enemyOffset, MediumenemySpawner.rotation);
        }
        if (enemyToSpawn == 2)
        {
            Instantiate(fastenemyPrefab, FastenemySpawner.position - enemyOffset, FastenemySpawner.rotation);
        }
        if (enemyToSpawn == 3)
        {
            Instantiate(weakenemyPrefab, MediumenemySpawner.position - enemyOffset, MediumenemySpawner.rotation);
        }
        if (enemyToSpawn == 4)
        {
            Instantiate(slowenemyPrefab, SlowenemySpawner.position - enemyOffset, SlowenemySpawner.rotation);
        }
        if (enemyToSpawn == 5)
        {
            Instantiate(bruteenemyPrefab, SlowenemySpawner.position - enemyOffset, SlowenemySpawner.rotation);
        }
    }

     // 

    public void GameOverCheck() 
    {
        if (currentEntered >= maxAllowedToEnter)
        {
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
            Enemy.GameOver = true;
        }
    }

    public void GameWonCheck()
    {
        if (currentWave == wavesToWin)
        {
            Time.timeScale = 0f;
            gameWonScreen.SetActive(true);
            Enemy.GameWon = true;
            MainMenuInteractions.level2unlocked = true;
        }

        if (LoadedScene == 4)
        {
            MainMenuInteractions.level3unlocked = true;
        }
    }



    public void Reset()
    {
        currentEntered = 0;
        gameOverScreen.SetActive(false);
        ButtonUI.gameStarted = false;
        Enemy.GameOver = false;
        countdown = 5.5f;
        CurrencyManager.currency = 1400;
    }
}