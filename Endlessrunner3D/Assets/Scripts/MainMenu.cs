using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void playGame()
    {
        SceneManager.LoadScene("SampleScene");
        FindObjectOfType<AudioManager>().Playsound("Click");
    }
    public void Shop()
    {
        FindObjectOfType<AudioManager>().Playsound("Click");
        Time.timeScale= 1;
        SceneManager.LoadScene("Shop");
        
    }
    
}
