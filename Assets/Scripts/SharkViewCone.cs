//Cooper Spring, 11/10/2020, code that checks if the player is in the shark's view cone and changes public static bool
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkViewCone : MonoBehaviour
{
    public static bool playerInViewCone;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerInViewCone = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerInViewCone = false;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerInViewCone = true;
        }
    }
}
