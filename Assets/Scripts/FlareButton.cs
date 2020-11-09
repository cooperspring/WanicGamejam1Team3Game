/**************************
 * By: Gryphon Mclaughlin
 * Date created: 11/8/20
 * Desc: Controls the buttons that shoot flares at specific points
**************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareButton : MonoBehaviour
{
    public ParticleSystem flareEffect;
    public Vector3 particlePosition;
    [Tooltip("The normal color of the button")]
    public Color normalColor;
    [Tooltip("The color of the button when pressed")]
    public Color pressedColor;
    public float Cooldown;
    float Timer;
    SpriteRenderer mySR;
    
    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
        Timer = Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused && !SearchObject.IsSearching && !ChestOpen.Open)
        {
            Timer += Time.deltaTime;
        }
    }

    //trigger when the player overlaps the button
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //change sprite color slightly to show that the button was pressed
        mySR.color = pressedColor;

        //only shoot when the button is off cooldown
        if (Timer >= Cooldown)
        {
            //create the flare effect and reset timer
            Instantiate<ParticleSystem>(flareEffect, particlePosition, Quaternion.identity);
            Timer = 0;
        }
    }

    //change color back when the player leaves the button
    private void OnTriggerExit2D(Collider2D collision)
    {
        mySR.color = normalColor;
    }
}
