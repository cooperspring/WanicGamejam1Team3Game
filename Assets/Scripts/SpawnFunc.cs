/*Cooper Spring, 10/22/2020, programs for a function that spawns things,
 * useable by the unity events of other things*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class SpawnFunc : MonoBehaviour
{
    public GameObject[] ObjectsToSpawn;

    public void Spawn()
    {
        for(int i = 0; i < ObjectsToSpawn.Length; i++)
        {
            Instantiate<GameObject>(ObjectsToSpawn[i], transform.position, transform.rotation);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
