using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerMovement : MonoBehaviour
{
    Vector2 movement;
    public float speed;
    private Rigidbody2D rb;
    bool isright;
    private SpriteRenderer sr;
    [SerializeField]
    Transform bulletspawn;
    private bool isShooting;
    public float shootDelay;
    public GameObject bullet;
    public static bool isfacingleft;
    float StableChipCount;
    public GameObject panel;
    public TextMeshProUGUI tm;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = 0;

      
        if (movement.x < 0 )
        {
            isfacingleft = true;
            anim.SetBool("isMoving", true);

            transform.localScale = new Vector3(-1, 1, 1);

           bulletspawn.localScale = new Vector3(-1, 1, 1);


        }
        else if(movement.x > 0)
        {

            isfacingleft = false;
            anim.SetBool("isMoving", true);


            transform.localScale = new Vector3(1, 1, 1);
            bulletspawn.localScale = new Vector3(1, 1, 1);



        }
        else
        {
            anim.SetBool("isMoving", false);

        }


        if (Input.GetKey(KeyCode.Space))
        {
            if (isShooting == true)
            {
                return;
            }
            else
            {
                
                isShooting = true;
                //instantie and shoot
                AudioManager.ad.Playsound("Shoot");
                GameObject b = Instantiate(bullet);
                b.GetComponent<bulletScript>().Startshooting(isfacingleft);
                b.transform.position = bulletspawn.transform.position;

                Invoke("ResetShoot",shootDelay);
            }
        }
    }
    private void ResetShoot()
    {
        isShooting = false;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            panel.SetActive(true);
            Destroy(this.gameObject); 
            
        }
        if (collision.CompareTag("Chip"))
        {
            StableChipCount++;
            tm.text = "X" + StableChipCount ;
        }
        if (StableChipCount == 0)
        {
            return;
        }
        else
        {
            if (collision.CompareTag("Machine"))
            {

                    StableChipCount -= 1;
                    tm.text = "X" + StableChipCount;


                    Reactor.currentstablelity += 10;
                
            }
        }
    }
}
