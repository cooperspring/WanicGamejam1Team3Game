//Cooper Spring, 11/6/2020, script that controls shark behavior

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShark : MonoBehaviour
{
    //bools: is shark actively chasing player, roaming, or should teleport to a holding point and stay still
    public bool activeChase;
    public bool passiveRoam;
    public bool inactiveState;
    public bool inLungeCooldown;
    public bool countDownLunge;
    public bool movingToStoredTarget;
    public bool playerInLOS;
    public float speed = 5f;
    public float startLungeDistance = 6f;
    public float lungeCooldown = 0.4f;
    public float lungeTimer = 0.4f;
    private Transform target;
    public Rigidbody2D sharkRB;
    public PolygonCollider2D sharkViewCone;
    public Vector2 storedTarget;

    // Start is called before the first frame update
    void Start()
    {
        sharkRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check for LOS
        CheckForPlayerLOS();

        if (activeChase)
        {
            //if the booleans here are true, we want to do them every frame that the shark is in chase state 
            //the booleans control timers and determine whether or not the shark should move / change the first boolean to start a new lunge
            if(movingToStoredTarget == true)
            {
                //move towards the stored target
                MoveTowards(storedTarget);
                RotateTowards(storedTarget);
                if((Vector2)transform.position == storedTarget)
                {
                    //signal that we need to start a cooldown and that we stopped moving
                    inLungeCooldown = true;
                    movingToStoredTarget = false;
                }
            }

            if (inLungeCooldown == true)
            {
                lungeCooldown -= Time.deltaTime;
                if (lungeCooldown <= 0)
                {
                    lungeCooldown = 0.4f;
                    //signal that we're ready to move again when possible
                    inLungeCooldown = false;
                }
            }

            if(countDownLunge == true)
            {
                lungeTimer -= Time.deltaTime;
                if(lungeTimer <= 0)
                {
                    lungeTimer = 0.4f;
                    //start to move to stored target
                    movingToStoredTarget = true;
                    //signal that we're not counting down anymore
                    countDownLunge = false;
                }
            }

            //we only want to directly chase a certain distance from the player and when we aren't doing anything lunge related
            //if the player is in range, we record the player's location and let the boolean update loops do the rest
            if (playerInLOS == true && inLungeCooldown == false && movingToStoredTarget == false 
                && countDownLunge == false)
            {
                //if in range away and not in cooldown/lunging, move towards player
                MoveTowards(target.position);
                RotateTowards(target.position);
            }

            if (playerInLOS == true && Vector2.Distance(transform.position, target.position) <= 3f 
                && inLungeCooldown == false && movingToStoredTarget == false)
            {
                SharkLunge();
            }

        }
        
    }

    private void MoveTowards(Vector2 target)
    {
        //allows for movetowards function without inputting many variables when you want to repeat it
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void RotateTowards(Vector2 target)
    {
        //part of code I learned about by searching it up, basically makes the shark look at a target in 2D space.
        var offset = 90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    public void SharkLunge()
    {
        //record the player's position to lunge to
        if (countDownLunge != true)
        {
            storedTarget = target.position;
        }

        //start the lunge timer
        countDownLunge = true;
    }

    public void CheckForPlayerLOS()
    {
        //makes a new line with endpoint player starting from the shark's position
        RaycastHit2D hit = Physics2D.Linecast(transform.position, target.position, 1 << LayerMask.NameToLayer("Action"));

        //checks if the hit's collider is valid and hitting the player, and checks in player is in view cone
        if(hit.collider != null && SharkViewCone.playerInViewCone == true && hit.collider.gameObject.name == "Player")
        {
            playerInLOS = true;
        }
        else
        {
            playerInLOS = false;
        }
    }
}
