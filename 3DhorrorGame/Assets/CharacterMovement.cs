using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController c;
    public float speed;
    public float gravity = -9.8f;
    Vector3 velocity;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        c.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        c.Move(velocity * Time.deltaTime);

    }
}
