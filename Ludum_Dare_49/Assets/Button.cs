using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour
{
   public void Reload()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void MainMenu()
    {
        Debug.Log("Working");
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Tut()
    {
        SceneManager.LoadScene("Tut");
    }
}
