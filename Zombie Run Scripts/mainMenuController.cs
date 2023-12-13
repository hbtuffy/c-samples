 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{

    public void playGame()
    {
        //SceneManager.LoadScene("GamePlay"); 
        int clickedChar = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        gameManager.instance.CharIndex = clickedChar;
        SceneManager.LoadScene("GamePlay");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
