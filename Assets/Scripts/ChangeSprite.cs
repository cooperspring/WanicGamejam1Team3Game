/**************************
 * By: Gryphon Mclaughlin
 * Date created: 11/12/20
 * Desc: Will change the sprite on the current object when another object tells it to
 * made to make a permanent sprite change for the rest of the game
**************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public bool changeSprite;
    public Sprite newSprite;
    SpriteRenderer mySR;
    
    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (changeSprite)
        {
            mySR.sprite = newSprite;
            changeSprite = false;
        }
    }
}
