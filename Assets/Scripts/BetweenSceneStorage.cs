using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BetweenSceneStorage : MonoBehaviour
{
    public static BetweenSceneStorage instance;
    public string storedName = "Unknown player";

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
                return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
