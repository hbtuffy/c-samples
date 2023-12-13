using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cornerButtons : MonoBehaviour
{
    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void playMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
