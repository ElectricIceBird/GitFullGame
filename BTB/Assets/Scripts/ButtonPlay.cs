using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonPlay : MonoBehaviour
{
     public Animator transitionAnim;
    public string sceneName;
    public void play()
    {
        StartCoroutine(LoadScene());
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
      Application.OpenURL("https://savestatecorrupted.bandcamp.com/");
 }
   IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(2);
            SceneManager.LoadScene(sceneName);

    }
  
   

    
    
}
