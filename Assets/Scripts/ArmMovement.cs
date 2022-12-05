using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    public float Speed = 15f;
    public float ReturnSpeed = 5f;
    public Rigidbody2D ARB;
    public PlayerBehaviour Player;
    public bool GoingBack = false;
    public Vector2 StartingPosition;
    public float MaxDistance = 25;
    public GameObject Enemy;
    public float Health;
    public float Damage = 1;
    public Vector2 ShootForce = new Vector2(20, 0);
    public float InputDirection;
    public float GoingRight;

    public Vector2 EndPoint;
    public void Start()
    {

    }
    public enum ArmState
    {
        BeingThrown, 
        ReturnHome, 
        Still,
        Home,
    }
    public ArmState MyState; 


    private void Update()
    {
        //off before thrown
        if (MyState == ArmState.ReturnHome)
        {
            ARB.velocity = new Vector2(0f, 0f);
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, ReturnSpeed);
            GoingBack = false;
        }
        //shoot outward and recall to player
        else if (MyState == ArmState.BeingThrown)
        {
            //Throw until at end point

        }
    }

    public void StartThrow()
    {
        ARB = GetComponent<Rigidbody2D>();
        ARB.velocity = new Vector2(Speed, 0f) * Player.gameObject.transform.localScale;
        StartingPosition = ARB.position;
        MyState = ArmState.BeingThrown;

        EndPoint = StartingPosition + (ShootForce * Player.transform.localScale.x);
    }

    public void CheckDirection()
    {
        InputDirection = Input.GetAxisRaw("Horizontal");

        if (InputDirection > 0)
        {
            gameObject.transform.localScale = new Vector3(-1f, 1f, 1);
            GoingRight = 1;
        }
        else if (InputDirection < 0)
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1);
            GoingRight = -1;
        }
    }
}
