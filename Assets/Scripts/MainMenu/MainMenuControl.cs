//Cooper Spring, 11/5/2020, Script to control the main menu's buttons
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    //button bools
    public bool startSelect;
    public bool quitSelect;

    private void OnMouseUp()
    {
        //checks if a button was clicked with the start or quit select variable checked, 
        //which is passed because they have a trigger collider
        if (startSelect)
        {
            //sends to a temp level for testing
            SceneManager.LoadScene("TestLevel1");
        }

        if (quitSelect)
        {
            Application.Quit();
        }
    }

}
