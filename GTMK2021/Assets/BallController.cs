using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Rigidbody rb;
    public float rollspeed;
    public AudioSource ads;
    public AudioClip pop;
    public GameObject particle;
    public TextMeshProUGUI sizetext;
    public GameObject portal;
    private int Combo = 1;
    
    [SerializeField]private float size = 1;
    public float WinValue;



    void Start()
    {

        ads.clip = pop;
       
    }


    void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));
        Vector3 movement = (input.z * cameraTransform.forward) + (input.x * cameraTransform.right);
        rb.AddForce(movement * rollspeed * Time.fixedDeltaTime * size );
        if (size >= WinValue)
        {

            portal.SetActive(true);

            Win();
        }


        sizetext.text = "Size:" + size + "/" + WinValue;

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Prop") && collision.transform.localScale.magnitude <= size)
        {
            collision.transform.parent = transform;
            collision.gameObject.tag = "Win";
            ads.Play();
            size += collision.transform.localScale.magnitude;
            Instantiate(particle, transform.position, transform.rotation);
            Combo += 1;

        }
       

    }
    public void Win()
    {
        Debug.Log("Win");
        
    }
}
