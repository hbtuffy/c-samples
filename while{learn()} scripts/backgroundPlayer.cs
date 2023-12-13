using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class backgroundPlayer : MonoBehaviour
{
    private static backgroundPlayer _instance;

    void Awake()
    {
        //if we don't have an [_instance] set yet
        if (!_instance)
            _instance = this;
         //otherwise, destroy this gameobject
         else
            Destroy(this.gameObject);


        DontDestroyOnLoad(this.gameObject);
    }

}
