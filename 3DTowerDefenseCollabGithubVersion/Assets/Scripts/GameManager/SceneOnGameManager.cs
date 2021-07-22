using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOnGameManager : MonoBehaviour
{
    public int SceneIndexM = 3;

    public void LoadNextSceneInOrder()
    {
        SceneIndexM += 1;
        LoadScene();
    }

    public void PutMeOutOfMySufferingAndLoadLevel3ForFlipSake()
    {
        SceneManager.LoadScene("v0.03 (3)");
    }

    private void LoadScene()
    {
        SceneManager.LoadScene((SceneIndexM));
        EnemySpawner.ES.Reset();
    }
}
