/**************************
 * By: Gryphon Mclaughlin
 * Date created: 11/8/20
 * Desc: Add to objects that will be searched
**************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestOpen : MonoBehaviour
{
    public GameObject searchItem;
    [Tooltip("The text that will explain how to open the chest")]
    public string InstructionText = "";
    [Tooltip("The text object where the text will show up")]
    public Text instructions;
    public static bool Open = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //notice whensomething collides with the piece
    private void OnCollisionStay2D(Collision2D collision)
    {
        //only reset the instructions if the chest isn't open
        if (!Open)
        {
            instructions.text = InstructionText;
        }

        //open chest with space bar
        if (Input.GetAxisRaw("Jump") > 0)
        {
            //clear instructions and pause the game
            instructions.text = "";
            Open = true;
            //Will wait for pause menu to be used to add the note read here
        }
    }

    //clear text when leaving
    private void OnTriggerExit2D(Collider2D collision)
    {
        instructions.text = "";
    }
}