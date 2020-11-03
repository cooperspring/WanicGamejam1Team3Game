/////By Cooper Spring
/////Date : 11/3/2020
////This is a movement script to move the player with input, using tank controls for now

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEditor;


public class PlayerController : MonoBehaviour
{
    public float Speed = 200;
    public float TurnSpeed = 10f;
    Rigidbody2D myRB;
    //Vector3 startingUp;
    //Vector3 startingRight;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        //startingUp = transform.up;
        //startingRight = transform.right;
    }

    
    // Update is called once per frame
    void Update()
    {
        //set up stored variable for movement
        Vector2 movement = new Vector2();
        
        //check for input and use that to move 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //get mouse position as world point
        //Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //get pointer direction
        //Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;

        //set player up vector to smoothed direction
        //transform.up += Vector3.Lerp(transform.up, direction, TurnSpeed);
        
        //Set forward and backward speeds
        myRB.AddForce(transform.up * movement.y * Speed * Time.deltaTime);
        myRB.AddTorque((-movement.x) * TurnSpeed * Time.deltaTime);

        //myRB.AddForce(startingRight * movement.x * Speed * Time.deltaTime);

        
    }
}
