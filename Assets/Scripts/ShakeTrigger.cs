/*Cooper Spring, 10/23/2020, camera shake trigger*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTrigger : MonoBehaviour
{
    public float duration = .5f;
    public float magnitude = .1f;
    public void Trigger()
    {
        CameraShake.TriggerShake(duration, magnitude);
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
