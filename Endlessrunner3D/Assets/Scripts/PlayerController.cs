using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Vector3 transformXYZ;
    [SerializeField] ParticleSystem SlideL,SlideR,Ju;
    [SerializeField] GameObject GroundP;
    private CharacterController controller;
    private Vector3 direction;
    public float fowardspeed;
    [SerializeField] private int diseredlane = 1;
    public float laneDistance = 4;
    public float jumpForce;
    public float Gravity = -20;
    private Animator animator;
    private bool isSilding;
    public static int numbersofCoin;
    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float maxSpeed;
    public TextMeshProUGUI coinText;
    public Carselector cs;
    public GameObject DH1;
    public GameObject DH2;
    public GameObject DH3;


    void Start()
    {
        controller = GetComponent<CharacterController>();

        /*if (cs.currentShopIndex == 0)
        {
            animator = DH1.GetComponent<Animator>();
        }
        else if (cs.currentShopIndex == 1) 
        {
            animator = DH2.GetComponent<Animator>();

        }
        else 
        {
            animator = DH3.GetComponent<Animator>();

        }*/
        switch (cs.currentdonutIndex) 
        {
            case 1:
                {
                    animator = DH2.GetComponent<Animator>();
                    break;
                }
            case 2:
                {
                    animator = DH3.GetComponent<Animator>();
                    break;
                }
            default:
                {
                    animator = DH1.GetComponent<Animator>();
                    break;
                }
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        transformXYZ = transform.localPosition;
        numbersofCoin = PlayerPrefs.GetInt("NumberOfCoins");
        coinText.text = "Coin:" + numbersofCoin;

        direction.z = fowardspeed;
        if (controller.isGrounded)
        {
            GroundP.SetActive(true);
            direction.y = -1;
            if (SwipeManager.swipeUp)
            {

                Jump();

            }
            
        }
        else
        {
            
            direction.y += Gravity * Time.deltaTime;

        }
        if (SwipeManager.swipeDown && !isSilding)
        {
            StartCoroutine(Slide());
           
        }
        if (SwipeManager.swipeRight)
        {
            diseredlane++; 
            if(diseredlane == 3)
            {
                diseredlane = 2;
            }
            

        }
        if (SwipeManager.swipeLeft)
        {
            diseredlane--;
            if (diseredlane == -1)
            {
                diseredlane = 0;
            }
           

        }
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (diseredlane == 0)
        {
           Instantiate(SlideL,transformXYZ,Quaternion.identity);
            targetPosition += Vector3.left * laneDistance;
        }
        else if(diseredlane == 2)
        {
           Instantiate(SlideR,transformXYZ,Quaternion.identity);
            

            targetPosition += Vector3.right * laneDistance;
        }
        transform.position = Vector3.Lerp(transform.position,targetPosition,80f * Time.fixedDeltaTime );
        controller.center = controller.center;
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.20f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        if (!DisplayManager.isStarted)
            return;
        animator.SetBool("isGameStarted", true);

        controller.Move(direction * Time.deltaTime);
        if (fowardspeed < maxSpeed)
            fowardspeed += 0.1f * Time.deltaTime;
        animator.speed += 0.001f;
    }
   
    void Jump()
    {
        FindObjectOfType<AudioManager>().Playsound("Jump");
                  GroundP.SetActive(false);

        direction.y = jumpForce;

        Instantiate(Ju,transformXYZ,Quaternion.identity);

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("Enemy"))
        {
            FindObjectOfType<AudioManager>().Playsound("Hurt");
            DisplayManager.gameover = true;
        }
    }
    private IEnumerator Slide()
    {
        isSilding = true;
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0f, -0.5f, 0f);
        controller.height = 1;

        yield return new WaitForSeconds(1.3f);
        controller.center = new Vector3(0f, 0f, 0f);
        controller.height = 2;
        animator.SetBool("isSliding", false);
        isSilding = false;

    }
}
