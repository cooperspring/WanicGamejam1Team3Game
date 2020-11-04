/*Cooper Spring, 10/23/2020, Camera/Screen shake code*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public class CameraShake : MonoBehaviour
{
    [Tooltip("How long shaking persists")]
    public static float ShakeDuration = 0;
    [Tooltip("How much does the screen shake")]
    public static float ShakeMagnitude = 0.1f;
    [Tooltip("Adjust how fast the duration depletes (higher = faster depletion)")]
    public static float DampingSpeed = 1.0f;
    
    public static void TriggerShake( float duration, float magnitude)
    {
        //handle incoming variables
        if(ShakeDuration <= 0)
        {
            ShakeMagnitude = magnitude;
        }
        else if(magnitude > ShakeMagnitude)
        {
            ShakeMagnitude = magnitude;
        }

        if(duration > ShakeDuration)
        {
            ShakeDuration = duration;
        }

        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //should we shake?
        if(ShakeDuration > 0)
        {
            transform.position += (Vector3)Random.insideUnitCircle * ShakeMagnitude;
            ShakeDuration -= Time.deltaTime * DampingSpeed;
        }
    }
}
