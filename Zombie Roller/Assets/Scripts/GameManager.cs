using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int ZombieSlectedPosition = 0;
    public GameObject selectedZombie;
    public List <GameObject> Zombie;
    public Vector3 defaultScale;
    public Vector3 SeleSize;
    

    // Start is called before the first frame update
    void Start()
    {
        SelectedZombies (selectedZombie); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("left")){
            GetZombieLeft();

        }
        if(Input.GetKeyDown("right")){
             GetZombieRight();

        }
              if(Input.GetKeyDown("up")){
                  PushUp();
               

              }


    }
    void GetZombieLeft()
    {
        if(ZombieSlectedPosition == 0)
        {
            ZombieSlectedPosition = 3;
            SelectedZombies(Zombie[3]);
        }else
        {
            ZombieSlectedPosition = ZombieSlectedPosition -1;
            GameObject newZombie = Zombie [ZombieSlectedPosition];
            SelectedZombies(newZombie);
                       

        }
    }
     void GetZombieRight()
    {
        if(ZombieSlectedPosition == 3)
        {
            ZombieSlectedPosition = 0;

            SelectedZombies(Zombie[0]);
        }else
        {
            ZombieSlectedPosition = ZombieSlectedPosition +1;

            SelectedZombies(Zombie [ZombieSlectedPosition]);
            
                       

        }
    }
    void SelectedZombies(GameObject newZombie)
    { 
        selectedZombie.transform.localScale = defaultScale;

        selectedZombie = newZombie;
        newZombie.transform.localScale = SeleSize;
    }
    void PushUp()
    {
        Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
        rb.AddForce(0,0,10, ForceMode.Impulse);
    }
}
