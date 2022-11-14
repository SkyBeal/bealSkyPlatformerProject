using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBehaviour : MonoBehaviour
{
    public bool GoingBack = false;
    public float Health;
    public float Damage = 1;
    public ArmMovement RightArm;
    public AudioClip HurtSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (RightArm.MyState==ArmMovement.ArmState.ReturnHome)
            {
                Debug.Log("home");
                RightArm.MyState = ArmMovement.ArmState.Home;
                RightArm.gameObject.SetActive(false);
            }
        }
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(HurtSound, Camera.main.transform.position);
            Debug.Log("i hate coding");
        }
        if (collision.gameObject.tag == "Enemy2")
        {
            collision.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(HurtSound, Camera.main.transform.position);
        }
        if (collision.gameObject.tag == "Enemy3")
        {
            collision.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(HurtSound, Camera.main.transform.position);
        }
        if (collision.gameObject.tag == "Boss")
        {
            Health -= Damage;
            if (Health <= 0)
            {
                collision.gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(HurtSound, Camera.main.transform.position);
            }
        }
    }
}
