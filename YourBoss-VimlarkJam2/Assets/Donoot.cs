using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donoot : MonoBehaviour
{
    private static Donoot instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
