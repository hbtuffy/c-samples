using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    //button controller to start the main menu
    public void startMainMenuLevel()
    {

        SceneManager.LoadScene("mainMenu");
    }


    //button controller to start the intro level
    public void startIntroLevel()
    {
        SceneManager.LoadScene("intro");
    }


    //button controller to start the lab level
    public void startLabLevel()
    {
        SceneManager.LoadScene("lab");
    }


    //button controller to start the mars level
    public void startMarsLevel()
    {

        SceneManager.LoadScene("mars");
    }


    //button controller to quit the application
    public void quitGame()
    {
        Application.Quit();

    }

}
