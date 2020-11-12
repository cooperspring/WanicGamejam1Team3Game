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
            Debug.Log("Player Exited View Cone");
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
