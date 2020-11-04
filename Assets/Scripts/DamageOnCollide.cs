/*Cooper Spring , 10/21/2020, Add to gameobjects meant to deal damage*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageOnCollide : MonoBehaviour
{
    //set amount of damage to deal
    public int Damage = 10;
    //set variable to determine if it should self destroy on collide
    public bool DestroyOnCollide = true;
    //set up an event to trigger on death
    public UnityEvent OnDeath;
    
    // Start is called before the first frame update
    void Start()
    {
        //makes a new unity event just in case it hasn't been set
        if(OnDeath == null)
        {
            OnDeath = new UnityEvent();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check for health on other objects, if so, apply damage
        //make a new instance of health class and assign it to the damaged object
        Health otherHealth = collision.gameObject.GetComponent<Health>();
        //if the assigned object's health is not 0 (null), deal damage
        if(otherHealth != null)
        {
            otherHealth.ChangeHealth(-Damage);
        }

        //if we destroy self, do that
        if(DestroyOnCollide)
        {
            //invoke the on death event
            OnDeath.Invoke();
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
