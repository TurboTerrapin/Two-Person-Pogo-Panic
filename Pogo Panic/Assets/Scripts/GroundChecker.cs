using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{

    [SerializeField]
    private PlayerMovement player;

    private void OnTriggerStay2D(Collider2D collision)
    {

        //Debug.Log("Colliding");

        if(!collision.CompareTag("Player"))
        {
            player.isGrounded = true;
        }
    }
}
