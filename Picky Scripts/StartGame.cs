using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex*0);
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
