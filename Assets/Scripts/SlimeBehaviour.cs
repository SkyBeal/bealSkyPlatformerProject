using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{
    public float Speed;
    public Vector3[] Positions;
    private int index;
    void Update()
    {
        //they move back and forth!!!!
        transform.position = Vector2.MoveTowards(transform.position, Positions[index], Time.deltaTime * Speed);
        if (transform.position == Positions[index])
        {
            
            if (index == Positions.Length -1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
    }
}
