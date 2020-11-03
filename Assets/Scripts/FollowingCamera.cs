/////By Cooper Spring
/////Date : 11/3/2020
////This is a camera script that is used to follow specified target

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FollowingCamera : MonoBehaviour
{
    public GameObject Target;
    public float smoothVal = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(Target != null)
        {
            //Determine target location
            Vector3 newPos = Target.transform.position;
            //maintain camera z
            newPos.z = -1f;
            //use linear interpolation to smooth movement to target
            transform.position = Vector3.Lerp(transform.position, newPos, smoothVal);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
