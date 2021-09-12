using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float fowardspeed;
    [SerializeField] private int diseredlane = 1;
    public float laneDistance = 4;
    public float jumpForce;
    public float Gravity = -20;
    public Animator animator;
    private bool isSilding;
    public static int numbersofCoim;
    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float maxSpeed;
    public TextMeshProUGUI coinText;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        numbersofCoim = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coin:" + numbersofCoim;

        direction.z = fowardspeed;
        if (controller.isGrounded)
        {
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
            targetPosition += Vector3.left * laneDistance;
        }
        else if(diseredlane == 2)
        {
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

        direction.y = jumpForce;

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
