using UnityEngine;
using System.Collections;

public class Highlander : MonoBehaviour {

    public static GameObject instance;

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = gameObject;
        }

        DontDestroyOnLoad(gameObject);
    }
}
