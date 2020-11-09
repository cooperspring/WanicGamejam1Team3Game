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
    Collider2D SearchObjectCollider;
    bool Searched = false;
    [Tooltip("Time in seconds it takes to search")]
    public int SearchTime;
    [Tooltip("The text that will explain how to search")]
    public string InstructionText = "";
    [Tooltip("The text that will display while searching")]
    public string SearchingText = "";
    [Tooltip("The text that will display once the object has been searched")]
    public string FinishedText = "";
    [Tooltip("The text object where the text will show up")]
    public Text instructions;

    // Start is called before the first frame update
    void Start()
    {
        SearchObjectCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Search()
    {
        if (!IsSearching)
        {
            instructions.text = InstructionText;
        }
        if (Input.GetAxisRaw("Jump") > 0)
        {
            IsSearching = true;
            instructions.text = SearchingText;
            StartCoroutine(SearchWait());
        }
    }

    //pause for the character to search
    IEnumerator SearchWait()
    {
        yield return new WaitForSeconds(SearchTime);
        Searched = true;
        IsSearching = false;
        instructions.text = FinishedText;
        Instantiate<GameObject>(searchItem, transform.position, Quaternion.identity);
    }

    //notice when a trigger hits the piece
    private void OnTriggerStay2D(Collider2D collision)
    {
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

    ////allow for the player to hit space whenever
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (!Searched)
    //    {
    //        Search(collision);
    //    }
    //    else
    //    {
    //        instructions.text = FinishedText;
    //    }
    //}

    ////clear text when leaveing
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    instructions.text = "";
    //}
}
