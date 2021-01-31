using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public Slider taskBar;

    public AudioSource bossSource;

    public GameObject Boss;
    public GameObject InsectCounter;
    public static GameManager instance;

    public GameObject insectsSpawner;

    public Transform Web;
    public Vector3 increadWebSize;

    public webFluid fluid_script;

    public TMP_Text ladyBugsText;
    public TMP_Text flyText;
    public TMP_Text beetlesText;
    public TMP_Text butterflyText;
    public TMP_Text mosquitosText;

    public int ladyBugs;
    public int mosquitos;
    public int fly;
    public int butterfly;
    public int beetles;

    int totalInsects;
    int taskbarProgress = 0;

    public bool tasksDone = false;
 
    void Awake()
    {
        instance = this;


        //Real

        // ladyBugs = Random.Range(10,15);
        // mosquitos = Random.Range(17,23);
        // beetles = Random.Range(5,12);
        // butterfly = Random.Range(13,20); 
        // fly = Random.Range(7,13); 

        //Test

        ladyBugs = 0;
        mosquitos = 1;
        beetles = 0;
        butterfly = 0; 
        fly = 0; 

        totalInsects = ladyBugs + beetles + mosquitos + butterfly + fly;
        taskBar.maxValue = totalInsects;
        taskbarProgress = totalInsects;

        updateUI();
    }

    void LateUpdate()
    {
        if(ladyBugs < 0)
        {
            ladyBugs = 0;
        }
        if(fly < 0)
        {
            fly = 0;
        }
        if(beetles < 0)
        {
            beetles = 0;
        }
        if(mosquitos < 0)
        {
            mosquitos = 0;
        }
        if(butterfly < 0)
        {
            butterfly = 0;
        }
        taskbarProgress = ladyBugs + fly + beetles + mosquitos + butterfly;
        updateUI();
    }
    void updateUI()
    {
        taskBar.value = totalInsects - taskbarProgress;

        ladyBugsText.text = ladyBugs.ToString();
        mosquitosText.text = mosquitos.ToString();
        flyText.text = fly.ToString();
        beetlesText.text = beetles.ToString();
        butterflyText.text = butterfly.ToString();
    }

    public void checkTaskDoneOrNot()
    {
        if(ladyBugs <= 0 && mosquitos <= 0 && fly <= 0 && butterfly <= 0 && beetles <= 0)
        {
            tasksDone = true;
            if(Web.localScale.x <= 3.3f)
            {
                fluid_script.increaseWeb(increadWebSize);

                //Disable Insect Spawner
                insectsSpawner.SetActive(false);

                //Delete all insects for scene
                GameObject[] insects = GameObject.FindGameObjectsWithTag("Insect");
                FindObjectOfType<cameraController>().SetOrthographicSize(7.5f);
                for (int i = 0; i < insects.Length; i++)
                {
                    Destroy(insects[i]);
                }

                //Disable Insect Counter
                InsectCounter.GetComponent<Animator>().enabled = true;
                StartCoroutine(destroyInsectCounter());

                //Play Boss BGM & Stop Current BGM
                bossSource.Play();
                AudioManager.instance.GetComponent<AudioSource>().enabled = false;

                //On Boss
                Boss.SetActive(true);

            }
        }
    }

    IEnumerator destroyInsectCounter()
    {
        yield return new WaitForSeconds(1.5f);
        InsectCounter.SetActive(false);
    }
}
