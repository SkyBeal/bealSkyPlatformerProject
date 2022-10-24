using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    public float Speed = 15f;
    public float ReturnSpeed = 0.5f;
    public Rigidbody2D ARB;
    public GameObject Player;
    public bool GoingBack = false;
    public Vector2 StartingPosition;
    public float MaxDistance = 25;

    void Start()
    {
        Player = GameObject.FindWithTag ("Player");
        ARB = GetComponent<Rigidbody2D>();
        ARB.velocity = new Vector2 (-50f, 0f) * Player.gameObject.transform.localScale;
        StartingPosition = ARB.position;
    }
    private void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            GoingBack = true;
        }

        if (GoingBack)
        {
            transform.position = Vector2.MoveTowards (transform.position, Player.transform.position, ReturnSpeed);
        }
        
        else if(Mathf.Abs (transform.position.x-StartingPosition.x) > MaxDistance)
        {
            ARB.velocity = new Vector2(0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(GoingBack)
            {
                Destroy(gameObject);
            }
        }
    }
}
