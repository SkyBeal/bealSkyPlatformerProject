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
    public AudioClip WhooshSound;
    public float GoingRight;
    public bool Moving;
    public static bool IsPlayerDead;
    public Animator GuyAnimator;
    public GameObject BGMusic;

    public void Start()
    {
      GuyAnimator = gameObject.GetComponent<Animator>(); 
    }
    

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
            KillPlayer();
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

        //bools for animation
        if ((!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) || IsPlayerDead)
        {
            GuyAnimator.SetBool("Moving", false);
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && !IsPlayerDead)
        {
            GuyAnimator.SetBool("Moving", true);
        }

            //jump
        bool shouldJump = (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && IsPlayerDead == false);
        if (shouldJump && OnGround)
        {
            RB2D.velocity = Vector2.zero;
            RB2D.AddForce(jumpForce);
        }

        //change arm direction
        CheckDirection();


        if (Input.GetKeyDown(KeyCode.Space) && IsPlayerDead == false)
        {

            if (RightArm.MyState==ArmMovement.ArmState.BeingThrown|| RightArm.MyState == ArmMovement.ArmState.Still)
            {
                RightArm.MyState = ArmMovement.ArmState.ReturnHome;
            }
            else if (RightArm.MyState == ArmMovement.ArmState.Home|| RightArm.MyState == ArmMovement.ArmState.ReturnHome)
            {
                RightArm.MyState = ArmMovement.ArmState.BeingThrown;
                RightArm.gameObject.SetActive(true);
                RightArm.transform.position = gameObject.transform.position;
                RightArm.StartThrow();
                AudioSource.PlayClipAtPoint(WhooshSound, Camera.main.transform.position);
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
            gameObject.transform.localScale = new Vector3 (1.5f, 1.5f, 1);
            GoingRight = 1;
        }
        else if (InputDirection < 0)
        {
            gameObject.transform.localScale = new Vector3 (-1.5f, 1.5f, 1);
            GoingRight = -1;
        }
    }
    public void KillPlayer()
    {
        AudioSource.PlayClipAtPoint(DefeatSound, Camera.main.transform.position);
        LoseScreen.SetActive(true);
        gameObject.SetActive(false);
        IsPlayerDead = true;
    }
    public void WinGame()
    {
        gameObject.SetActive(false);
        IsPlayerDead = true;
        WinScreen.SetActive(true);
        Destroy(BGMusic);
    }
   
}
    
