using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
   public void ReplayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ApplicationQuit()
    {
        Application.Quit();
        Debug.Log("working");
    }
}
