//Cooper Spring, 11/5/2020, Script to control the pause menu's buttons
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    //button bools
    public bool resumeSelect;
    public bool quitSelect;
    public static bool buttonPressed;

    private void OnMouseUp()
    {
        //checks if a button(the text specifically, put this on the text)
        //was clicked with the start or quit select variable checked, 
        //which is passed because they have a trigger collider
        if (resumeSelect)
        {
            //tell the pause menu that we need to unpause
            Debug.Log("resume pressed");
            PauseMenu.isPaused = false;
        }

        if (quitSelect)
        {
            Application.Quit();
        }

        buttonPressed = true;
    }
}
