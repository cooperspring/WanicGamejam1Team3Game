//Cooper Spring, 10/26/2020, GameManager Script, stores game data between scenes

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class GameManager
{
    private static int _score = 0;

    public static UnityEvent OnScoreChange = new UnityEvent();
    
    public static int Score 
    {
        get 
        {
            return _score;        
        }
        set
        {
            _score = value;
            OnScoreChange.Invoke();
        }
    }

    
}
