using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    public float Speed = 15f;
    public float ReturnSpeed = 5f;
    public Rigidbody2D ARB;
    public GameObject Player;
    public bool GoingBack = false;
    public Vector2 StartingPosition;
    public float MaxDistance = 25;
    public GameObject Enemy;

    public void Start()
    {
         Player = GameObject.FindGameObjectWithTag("Player");
    }
    public enum ArmState
    {
        BeingThrown, 
        ReturnHome, 
    }
    public ArmState MyState; 


    private void Update()
    {
        //off before thrown
        if (MyState == ArmState.ReturnHome)
        {
            transform.position = Vector2.MoveTowards (transform.position, Player.transform.position, ReturnSpeed);
            //GoingBack = false;
        }
        //shoot outward and recall to player
        else if(MyState == ArmState.BeingThrown)
        {
            if (Mathf.Abs(transform.position.x - StartingPosition.x) > MaxDistance)
            {
                ARB.velocity = new Vector2(0f, 0f);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.position = Vector2.MoveTowards (transform.position, Player.transform.position, ReturnSpeed);
                GoingBack = true;
                MyState = ArmState.ReturnHome;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(GoingBack)
            {
             gameObject.SetActive(false);
             MyState = ArmState.ReturnHome;
             GoingBack = false;
            }
        }
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Enemy2")
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Enemy3")
        {
            collision.gameObject.SetActive(false);
        }
    }

    public void StartThrow()
    {
        ARB = GetComponent<Rigidbody2D>();
        ARB.velocity = new Vector2(-50f, 0f) * Player.gameObject.transform.localScale;
        StartingPosition = ARB.position;
        MyState = ArmState.BeingThrown; 
    }
}
