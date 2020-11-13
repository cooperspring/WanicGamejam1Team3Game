/*Cooper Spring , 10/21/2020, Programs for health on objects with health*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth = 100;
    public bool DestroyAtZero = true;
    public UnityEvent OnDeath;
    // Start is called before the first frame update
    void Start()
    {
        if(OnDeath == null)
        {
            OnDeath = new UnityEvent();
        }
    }

    public void ChangeHealth(int change)
    {
        //adjust health
        CurrentHealth += change;
        //if we change playerhealth, change the health bar as well
        if(gameObject.name == "Player")
        {
            PlayerHealthMeter.UpdatePlayerHealth(CurrentHealth.ToString());
        }
        //if overhealed set to max
        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        //if less than zero, handle death
        if(CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            OnDeath.Invoke();
            if(DestroyAtZero)
            {
                Destroy(gameObject);
            }
        }
    }

    
}
