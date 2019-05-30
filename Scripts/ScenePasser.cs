using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePasser : MonoBehaviour
{
    public void LoadTheGame()
    {
        SceneManager.LoadScene("Scenes/GameScene");
    }

    public void ExitTheGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Scenes/StartScreen");
    }

    public void LoadPrepScene()
    {
        SceneManager.LoadScene("Scenes/TeamCompScene");
    }
}
