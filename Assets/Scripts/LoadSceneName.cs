using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneName : MonoBehaviour
{
    public string LevelName;
    public void ChangeLevel()
    {
        SceneManager.LoadScene(LevelName);
    }
}
