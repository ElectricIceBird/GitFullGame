using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderPlayer : MonoBehaviour
{
    Animator animator;

    public Camera cam;

    Rigidbody2D rb;

    [Header("Speed Controller")]
    public float speed = 10f;
    public float RotationSpeed;

    Vector2 Movement;

    public Transform mouseCursor;

    webFluid webfluid;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        webfluid = FindObjectOfType<webFluid>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer(); //to rotate the player from the mouse input

        //movement using WASD
        Movement.x = Input.GetAxis("Horizontal");
        Movement.y = Input.GetAxis("Vertical");

        if (Movement.y != 0f || Movement.x != 0f)
        {
            animator.SetBool("moving",true);
            webfluid.increaseFluidBy = 1f;
        }
        else
        {
            animator.SetBool("moving",false);
            webfluid.increaseFluidBy = 3.5f;
        }


    }
    void RotatePlayer()
    {
        // For Movement through keyborad
        // Angle.z = Input.GetAxisRaw("Horizontal") * RotationSpeed;
        // transform.Rotate(Angle);

        //For Rotation with Mouse
        Vector3 MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        MousePos.z = 0f;

        mouseCursor.position = Vector3.Lerp(mouseCursor.position,MousePos,Time.deltaTime * 25f);

        Vector2 Dir = MousePos - transform.position;
        float Angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = Angle;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Movement * speed * Time.fixedDeltaTime);
    }
}
