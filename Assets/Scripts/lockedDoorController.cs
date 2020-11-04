//Cooper Spring, 11/4/2020, simple script to determine if a door will open when the player holding a key touches it
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedDoorController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if the player holds a key, and if the player is even colliding with the door
        if(collision.gameObject.name == "Player" && PlayerController.heldItemsDatabase[0] == 1)
        {
            Destroy(gameObject);
        }
    }
}
