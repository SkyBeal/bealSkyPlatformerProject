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
    }
}
