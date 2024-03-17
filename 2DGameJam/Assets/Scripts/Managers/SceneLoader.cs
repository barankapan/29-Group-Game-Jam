using System.Collections;
using System.Collections.Generic;
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

}

public enum SceneEnum { menuScene, escapeScene, attackScene, bossScene }
