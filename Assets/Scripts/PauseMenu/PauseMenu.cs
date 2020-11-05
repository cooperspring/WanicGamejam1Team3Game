//Cooper Spring, 11/5/2020, Script to control in-game pausing.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //public variables to be used by functions
    public static bool isPaused;
    public static GameObject pauseMenu;
    public static CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        //set the canvas group to the menu's component
        canvasGroup = GetComponent<CanvasGroup>();
        //make sure the menu doesn't open when the game starts
        isPaused = false;
        ClosePauseMenu();
    }

    private void PauseGame()
    {
        //check if the game is paused, call a function and set timescale
        if (isPaused)
        {
            Time.timeScale = 0f;
            ShowPauseMenu();
        }
        else
        {
            Time.timeScale = 1;
            ClosePauseMenu();
        }
    }

    private void ShowPauseMenu()
    {
        //make pause menu visible and prevent inputs from passing
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }
    private void ClosePauseMenu()
    {
        //make pause menu invisible and allow inputs to pass
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0f;
    }

    private void Update()
    {
        //check for esc key input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //set pause bool to whatever its opposite is
            isPaused = !isPaused;
            PauseGame();
        }
        if (PauseMenuButtons.buttonPressed == true)
        {
            PauseGame();
            PauseMenuButtons.buttonPressed = false;
        }
    }

}
