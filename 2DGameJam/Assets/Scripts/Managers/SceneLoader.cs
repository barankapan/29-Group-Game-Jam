using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadLevel(SceneEnum scene)
    {
        SceneManager.LoadScene((int)scene);
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

public enum SceneEnum { menuScene, attackScene, bossScene,creditScene }
