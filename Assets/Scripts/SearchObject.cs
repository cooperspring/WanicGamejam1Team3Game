/**************************
 * By: Gryphon Mclaughlin
 * Date created: 11/8/20
 * Desc: Add to objects that will be searched
**************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchObject : MonoBehaviour
{
    public GameObject searchItem;
    public static bool IsSearching;
    bool Searched = false;
    [Tooltip("Time in seconds it takes to search")]
    public int SearchTime;
    [Tooltip("The text that will explain how to search")]
    public string InstructionText = "";
    [Tooltip("The text that will display whiile searching")]
    public string SearchingText = "";
    [Tooltip("The text that will display once the object has been searched")]
    public string FinishedText = "";
    [Tooltip("The text object where the text will show up")]
    public Text instructions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Search()
    {
        if (!IsSearching)
        {
            //update text to tell player how to search
            instructions.text = InstructionText;
        }

        //when the player hits space, it will start searching
        if (Input.GetAxisRaw("Jump") > 0)
        {
            //tell player that they are searching and then set the wait time
            IsSearching = true;
            instructions.text = SearchingText;
            StartCoroutine(SearchWait());
        }
    }

    //pause for the character to search
    IEnumerator SearchWait()
    {
        //wait for the specified amount of time
        yield return new WaitForSeconds(SearchTime);
        Searched = true;
        IsSearching = false;
        instructions.text = FinishedText;
        //create the gameobject if there is one
        Instantiate<GameObject>(searchItem, transform.position, Quaternion.identity);
    }

    //notice when a trigger hits the piece
    private void OnTriggerStay2D(Collider2D collision)
    {
        //only activate if they haven't already searched
        if(!Searched)
        {
            Search();
        }
        else
        {
            instructions.text = FinishedText;
        }
    }

    //clear text when leaving
    private void OnTriggerExit2D(Collider2D collision)
    {
        instructions.text = "";
    }
}
