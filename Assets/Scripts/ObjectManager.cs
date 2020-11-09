/**************************
 * By: Gryphon Mclaughlin
 * Date created: 11/9/20
 * Desc: Add to an object in the same scene as the objects that will be randomized
**************************/

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    //use a list to add all the search objects together
    List<GameObject> SearchObjects = new List<GameObject>();
    int index;
    public GameObject itemFound;
    
    // Start is called before the first frame update
    void Start()
    {
        //add all the searchobjects to a list
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("SearchObject"))
        {
            SearchObjects.Add(g);
        }
        //determine a random index
        index = Random.Range(0, SearchObjects.Count);

        //give the randomly selected search object a gear
        SearchObjects[index].GetComponent<SearchObject>().searchItem = itemFound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
