using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    GameState state;
    int currentSceneIndex;


    private void Start()
    {
        state = FindObjectOfType<GameState>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    //Yes, I know this part is horrible
    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene(5);
    }


    public void GameOverScene()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings-1);
        state.StatusDestroy();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
