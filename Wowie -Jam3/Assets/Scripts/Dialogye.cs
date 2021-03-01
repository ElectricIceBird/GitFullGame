using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogye : MonoBehaviour
{
    public TextMeshProUGUI textdisplay;
    public string[] sentences;
    private int index;
    public float typing;
    public GameObject button;
    public Animator anim;
    public void Start()
    {
        StartCoroutine(Type());
    }
    void Update()
    {
        if(textdisplay.text == sentences[index])
        {
            button.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textdisplay.text += letter;
        yield return new WaitForSeconds(typing);  
        }
    }
    public void NextSentence()
    {
        anim.SetTrigger("Change");
        button.SetActive(false);

        if (index < sentences.Length - 1)
        {


            index++;
            textdisplay.text = "";

            StartCoroutine(Type());

        }
        else
        {
            textdisplay.text = "";
        }
    }
}
