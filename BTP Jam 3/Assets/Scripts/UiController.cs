using UnityEngine;
using UnityEngine.SceneManagement;


public class UiController : MonoBehaviour
{

    public void play()
    {
        SceneManager.LoadScene("main2");
    }
    public void exit()
    {
        Application.Quit();
        Debug.Log("QuitNOW");
    }
    public void openABHI(){ 
        Application.OpenURL("https://atg-studio.itch.io/");
    }
    public void openIAMPEN(){ 
        Application.OpenURL("https://suareztom.myportfolio.com/");
    }
    public void openEIB(){ 
        Application.OpenURL("https://electricicebird.itch.io/");
    }
    public void openSaveSte(){ 
        Application.OpenURL("https://savestatecorrupted.itch.io/");
 }

}
