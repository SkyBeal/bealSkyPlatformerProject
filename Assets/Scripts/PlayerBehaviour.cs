using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float XMove;
    public ArmMovement RightArm;
    public float ReturnSpeed;
    public GameObject LoseScreen;
    public AudioClip DefeatSound;
    public GameObject WinScreen;
    public AudioClip NextLevelSound;

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
            if (collision.transform.tag == "Door1")
            {
            SceneManager.LoadScene(2);
            AudioSource.PlayClipAtPoint(NextLevelSound, Camera.main.transform.position);
             }
            if (collision.transform.tag == "Door2")
            {
            SceneManager.LoadScene(3);
            AudioSource.PlayClipAtPoint(NextLevelSound, Camera.main.transform.position);
              }
            if (collision.transform.tag == "Door3")
            {
            WinGame();
            AudioSource.PlayClipAtPoint(NextLevelSound, Camera.main.transform.position);
              }
            if (collision.transform.tag == "Enemy2")
            {
            KillPlayer();
            }
            if (collision.transform.tag == "Enemy3")
            {
            KillPlayer();
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
        //move
        XMove = Input.GetAxis("Horizontal");
        Vector3 newPos = transform.position;
        
        //jump
        bool shouldJump = (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow));
        if (shouldJump && OnGround)
        {
            RB2D.velocity = Vector2.zero;
            RB2D.AddForce(jumpForce);
        }

        //change arm direction
        CheckDirection();
        ARB.velocity = new Vector2(50f, 0f) * gameObject.transform.localScale.x;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (RightArm.MyState == ArmMovement.ArmState.ReturnHome)
            {
                RightArm.transform.position = gameObject.transform.position;
                RightArm.gameObject.SetActive(true);
                RightArm.StartThrow();
            }
            if (RightArm.MyState ==  ArmMovement.ArmState.BeingThrown)
            {

            }

        }
    }

    private void FixedUpdate()
    {
        RB2D.velocity = new Vector2(XMove * Speed * Time.deltaTime, RB2D.velocity.y);
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
        AudioSource.PlayClipAtPoint(DefeatSound, Camera.main.transform.position);
        LoseScreen.SetActive(true);
        Destroy(gameObject);
    }
    public void WinGame()
    {
        Destroy(gameObject);
        WinScreen.SetActive(true);
    }
   
}
    
