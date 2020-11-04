/////By Cooper Spring
/////Date : 10/21/2020
////Add script to objects not meant to last forever
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DestroyAtTime : MonoBehaviour
{
    [Tooltip("This is how long the object will exist in seconds")]
    public float DeathTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SlowDeath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SlowDeath()
    {
        yield return new WaitForSeconds(DeathTime);
        Destroy(gameObject);
    }
}
