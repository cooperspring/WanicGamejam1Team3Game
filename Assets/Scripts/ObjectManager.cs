using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    List<GameObject> SearchObjects = new List<GameObject>();
    int index; /*= Random.Range(0, SearchObjects.Length);*/
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
