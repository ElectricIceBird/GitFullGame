using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour
{
    public string Scenename;
  public void Play()
    {
        SceneManager.LoadScene(Scenename);
    }
    public void exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
  
}
