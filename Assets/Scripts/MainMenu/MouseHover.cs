//Cooper Spring, 11/5/2020, script to control the color of selected text
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       GetComponent<TextMesh>().color  = Color.white;
    }

    public void OnMouseEnter()
    {
        GetComponent<TextMesh>().color = Color.yellow;
    }
    
    public void OnMouseExit()
    {
        GetComponent<TextMesh>().color = Color.white;
    }
}
