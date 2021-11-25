using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
   public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        
    }
    public void Quit()
    {
        Application.Quit();
    }
}
