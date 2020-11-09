/**************************
 * By: Gryphon Mclaughlin
 * Date created: 11/8/20
 * Desc: Add to objects that will be destroyed by the shark
**************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkDestroy : MonoBehaviour
{
    [Tooltip("How many times the shark has to hit the door")]
    public int SharkHits = 1;
    int TimesHit = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //make sure the object is the shark
        if (collision.gameObject.tag == "Shark")
        {
            //increase the times hit
            ++TimesHit;

            //check if the shark has hit the door enough times
            if (TimesHit >= SharkHits)
            {
                //if so, destroy the door
                Destroy(gameObject);
            }
        }
    }
}
