using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int delayInSeconds = 3; //for load time
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadTime());
        }
    }
    IEnumerator LoadTime()
    {
        yield return new WaitForSeconds(delayInSeconds);
        LoadNextScene();
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }
    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Option Screen");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LostGameScreen()
    {
        SceneManager.LoadScene("Lose Screen");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
