using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform Player;

    public void Update()
    {
        Vector3 CameraPosition = new Vector3(Player.position.x, Player.position.y, -10f);
        transform.position = CameraPosition;

        //trying to stop the camera from getting transform from the player after they die
        if (PlayerBehaviour.IsPlayerDead == true)
        {
            //Destroy(this);
            Debug.Log("dude");
        }
}
}
