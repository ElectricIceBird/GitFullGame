using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform grabPoint;
    public Transform holder;
    public float raydist;
    public GameObject penguin;
    public GameObject penguin1;
    public GameObject penguin2;
    public GameObject penguin3;
    public GameObject penguin4;
    public GameObject penguin5;
    public GameObject penguin6;
    public GameObject penguin7;
    public GameObject penguin8;
    public GameObject penguin9;







    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabPoint.position, Vector2.down, raydist);
        if (grabCheck.collider != null && grabCheck.collider.CompareTag("Box"))
        {

            Debug.Log("Hello CheaseS");
            if (Input.GetKey(KeyCode.E))
            {
                grabCheck.collider.gameObject.transform.parent = holder;
                grabCheck.collider.gameObject.transform.position = holder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                if (penguin != null)
                {
                    penguin.GetComponent<PenguinAi>().anim.SetBool("isGrab", true);
                    penguin.GetComponent<PenguinAi>().enabled = false;
                }
                else return;

                if (penguin1 != null)
                {
                    penguin1.GetComponent<PenguinAi>().anim.SetBool("isGrab", true);
                    penguin1.GetComponent<PenguinAi>().enabled = false;
                }
                else return;


                if (penguin2 != null)
                {
                    penguin2.GetComponent<PenguinAi>().anim.SetBool("isGrab", true);
                    penguin2.GetComponent<PenguinAi>().enabled = false;
                }
                else return;

                if (penguin3 != null)
                {
                    penguin3.GetComponent<PenguinAi>().anim.SetBool("isGrab", true);
                    penguin3.GetComponent<PenguinAi>().enabled = false;
                }
                else return;



                if (penguin4 != null)
                {
                    penguin4.GetComponent<PenguinAi>().anim.SetBool("isGrab", true);
                    penguin4.GetComponent<PenguinAi>().enabled = false;
                }
                else return;
                if (penguin5 != null)
                {
                    penguin5.GetComponent<PenguinAi>().anim.SetBool("isGrab", true);
                    penguin5.GetComponent<PenguinAi>().enabled = false;
                }
                else return;


                if (penguin6 != null)
                {
                    penguin6.GetComponent<PenguinAi>().anim.SetBool("isGrab", true);
                    penguin6.GetComponent<PenguinAi>().enabled = false;
                }
                else return;

                if (penguin7 != null)
                {
                    penguin7.GetComponent<PenguinAi>().anim.SetBool("isGrab", true);
                    penguin7.GetComponent<PenguinAi>().enabled = false;
                }
                else return;


                if (penguin8 != null)
                {
                    penguin8.GetComponent<PenguinAi>().anim.SetBool("isGrab", true);
                    penguin8.GetComponent<PenguinAi>().enabled = false;
                }
                else return;

                if (penguin9 != null)
                {
                    penguin9.GetComponent<PenguinAi>().anim.SetBool("isGrab", true);
                    penguin9.GetComponent<PenguinAi>().enabled = false;
                }
                else return;





            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                if (penguin != null)
                {
                    penguin.GetComponent<PenguinAi>().enabled = true;
                    penguin.GetComponent<PenguinAi>().anim.SetBool("isGrab", false);
                }
                else return;

                if (penguin1 != null)
                {
                    penguin1.GetComponent<PenguinAi>().enabled = true;
                    penguin1.GetComponent<PenguinAi>().anim.SetBool("isGrab", false);
                }
                else return;
                if (penguin2 != null)
                {
                    penguin2.GetComponent<PenguinAi>().enabled = true;
                    penguin2.GetComponent<PenguinAi>().anim.SetBool("isGrab", false);
                }
                else return;
                if (penguin3 != null)
                {
                    penguin3.GetComponent<PenguinAi>().enabled = true;
                    penguin3.GetComponent<PenguinAi>().anim.SetBool("isGrab", false);
                }
                else return;
                if (penguin4 != null)
                {
                    penguin4.GetComponent<PenguinAi>().enabled = true;
                    penguin4.GetComponent<PenguinAi>().anim.SetBool("isGrab", false);
                }
                else return;
                if (penguin5 != null)
                {
                    penguin5.GetComponent<PenguinAi>().enabled = true;
                    penguin5.GetComponent<PenguinAi>().anim.SetBool("isGrab", false);
                }
                else return;
                if (penguin6 != null)
                {
                    penguin6.GetComponent<PenguinAi>().enabled = true;
                    penguin6.GetComponent<PenguinAi>().anim.SetBool("isGrab", false);
                }
                else return;
                if (penguin7 != null)
                {
                    penguin7.GetComponent<PenguinAi>().enabled = true;
                    penguin7.GetComponent<PenguinAi>().anim.SetBool("isGrab", false);
                }
                else return;
                if (penguin8 != null)
                {
                    penguin8.GetComponent<PenguinAi>().enabled = true;
                    penguin8.GetComponent<PenguinAi>().anim.SetBool("isGrab", false);
                }
                else return;
                if (penguin9 != null)
                {
                    penguin9.GetComponent<PenguinAi>().enabled = true;
                    penguin9.GetComponent<PenguinAi>().anim.SetBool("isGrab", false);
                }
                else return;
               
            }
        }
    }
}
