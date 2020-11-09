/////By Cooper Spring
/////Date : 10/20/2020
////This is a script that allows for player shooting from attached gameobject
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerShoot : MonoBehaviour
{
    [Tooltip("Make sure projectile to be fired has a RigidBody2D!")]
    public GameObject ProjectileFlareGun;
    public GameObject ProjectileHarpoonGun;
    public GameObject MuzzleFlashEffect;
    public Rigidbody2D myRb;
    //track the current weapon
    public static int currentWeapon = 0;
    public float ProjectileSpeed = 70;
    public float Cooldown = 0.5f;
    public float Timer = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPaused == false && SearchObject.IsSearching == false)
        {
            Timer += Time.deltaTime;
            //spacebar fires
            if (Input.GetAxisRaw("Jump") > 0)
            {
                //check if player even has a weapon
                if (currentWeapon != 0)
                {
                    if (Timer >= Cooldown)
                    {
                        Timer = 0;
                        CameraShake.TriggerShake(0.2f, 0.02f);
                        Fire(transform.position, transform.up);
                    }
                }
            }
        }

    }
    //fires one projectile at given position with given direction
    void Fire(Vector3 position, Vector3 direction)
    {
        //make bullet and flash, handle different cases depending on current weapon
        switch (currentWeapon)
        {
            case 1:
                GameObject projFlareGun = Instantiate<GameObject>(ProjectileFlareGun, position, transform.rotation);
                //set bullet velocity
                projFlareGun.GetComponent<Rigidbody2D>().velocity = (direction * ProjectileSpeed) + (Vector3)myRb.velocity;
                //move bullet
                projFlareGun.transform.Translate(Vector3.up * 0.90f, Space.Self);
                projFlareGun.transform.Translate(Vector3.right * 0.235f, Space.Self);
                AudioManage.PlaySound("flareShot");

                break;
            case 2:
                GameObject projHarpoonGun = Instantiate<GameObject>(ProjectileHarpoonGun, position, transform.rotation);
                //set bullet velocity
                projHarpoonGun.GetComponent<Rigidbody2D>().velocity = (direction * ProjectileSpeed) + (Vector3)myRb.velocity;
                //move bullet
                projHarpoonGun.transform.Translate(Vector3.up * 0.90f, Space.Self);
                projHarpoonGun.transform.Translate(Vector3.right * 0.235f, Space.Self);
                break;
        }
        
        GameObject newMuzzleFlash = Instantiate<GameObject>(MuzzleFlashEffect, position, transform.rotation);
        //move flash
        newMuzzleFlash.transform.Translate(Vector3.up * 0.69f, Space.Self);
        newMuzzleFlash.transform.Translate(Vector3.right * 0.235f, Space.Self);
        
        
        
    }
}
