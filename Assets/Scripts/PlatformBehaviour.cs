using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    public GameObject Platform;
    public ArmMovement RightArm;
    public GameObject BoneArm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Platform.SetActive(true);
            RightArm.MyState = ArmMovement.ArmState.ReturnHome;
            BoneArm.SetActive(true);
        }
    }
}
