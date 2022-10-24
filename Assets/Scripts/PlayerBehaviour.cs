using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D RB2D;
    public Vector2 jumpForce = new Vector2(0, 300);
    public bool OnGround;
    public bool FaceLeft;
    public bool FaceRight;
    public float InputDirection;
    public Rigidbody2D ARB;
    public bool ArmOut = false; 
    public Transform FirePoint;
    public GameObject ArmShot;

    public void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.transform.tag == "Ground")
            {
                OnGround = true;
            } 
            if (collision.transform.tag == "Enemy")
            {
            KillPlayer();
            }
            if (collision.transform.tag == "Boss")
            {
            Debug.Log("wahoo new level time");
            }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            OnGround = false;
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
        bool shouldJump = (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow));
        if (shouldJump && OnGround)
        {
            RB2D.velocity = Vector2.zero;
            RB2D.AddForce(jumpForce);
        }
        CheckDirection();
        ARB.velocity = new Vector2(50f, 0f) * gameObject.transform.localScale.x;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    public void CheckDirection()
    {
        InputDirection = Input.GetAxisRaw("Horizontal");

        if (InputDirection > 0)
        {
            gameObject.transform.localScale = new Vector3 (-0.6331808f, 0.6258141f, 1);
        }
        else if (InputDirection < 0)
        {
            gameObject.transform.localScale = new Vector3 (0.6331808f, 0.6258141f, 1);
        }
    }
    public void KillPlayer()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void Shoot()
    {
        Instantiate(ArmShot, FirePoint.position, Quaternion.identity);
    }
}
    
