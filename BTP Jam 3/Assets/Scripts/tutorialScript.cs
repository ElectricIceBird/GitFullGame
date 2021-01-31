using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialScript : MonoBehaviour
{
    public Animator animator;
    public Animator transitionAnim;

    public SpriteRenderer currentSprite;
    public Sprite[] tutsImages;
    
    int i = 0;

    public float timeDelay = .4f;

    private void Update() {
        if(Input.GetButtonDown("Jump"))
        {
            currentSprite.sprite = tutsImages[i += 1];
            animator.SetTrigger("spaceClicked");
            StartCoroutine(disableAnimatorAgain());
        }
    }
    IEnumerator disableAnimatorAgain()
    {
        yield return new WaitForSeconds(timeDelay);
        if(i >= 5)
        {
            transitionAnim.SetTrigger("End");
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("main2");
        }
    }
}
