using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D RB2D;
    public Vector2 jumpForce = new Vector2(0, 300);
    public bool OnGround; 
    public void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.transform.tag == "Ground")
            {
                OnGround = true;
            Debug.Log("wooooo touching ground");
            } 
            if (collision.transform.tag == "Enemy")
            {
            Debug.Log("AHHHHHH I'M DYING");
            }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            OnGround = false;
            Debug.Log("oh my god off the ground");
        }
    }
   
       
    void Update()
    {
        //move left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            float xMove = Input.GetAxis("Horizontal");
            Vector3 newPos = transform.position;
            newPos.x += xMove * Speed * Time.deltaTime;
            transform.position = newPos;
        }
        //move right
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            float xMove = Input.GetAxis("Horizontal");
            Vector3 newPos = transform.position;
            newPos.x += xMove * Speed * Time.deltaTime;
            transform.position = newPos;
        }
        //jump
        bool shouldJump = (Input.GetKeyDown(KeyCode.Space)) || Input.GetKeyDown(KeyCode.W);
        if (shouldJump && OnGround)
        {
            RB2D.velocity = Vector2.zero;
            RB2D.AddForce(jumpForce);
        }
    }
}
    
