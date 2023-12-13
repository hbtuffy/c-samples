using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    [SerializeField]
   
    public static gameManager instance;
    [SerializeField]
    private GameObject[] characterList;

    private int _CharIndex;
    public int CharIndex 
    {  
        get { return _CharIndex; } 
        set { _CharIndex = value; }
    }
    private void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject); 
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;

    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;

    }

    void OnLevelFinishedLoading(Scene scene,LoadSceneMode mode)
    {
        if(scene.name == "GamePlay")
        {
            Instantiate(characterList[CharIndex]);
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
