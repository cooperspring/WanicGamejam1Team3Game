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
    List<GameObject> SearchObjects = new List<GameObject>();
    int index;
    public GameObject itemFound;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("SearchObject"))
        {
            SearchObjects.Add(g);
        }
        index = Random.Range(0, SearchObjects.Count);

        SearchObjects[index].GetComponent<SearchObject>().searchItem = itemFound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
