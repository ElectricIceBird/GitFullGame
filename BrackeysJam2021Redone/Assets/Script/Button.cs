using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour
{
    public string Scenename;
    public void play() 
    {
        SceneManager.LoadScene(Scenename);
    }
    public void exit()
    {
        Application.Quit();
        Debug.Log("Ok");
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
