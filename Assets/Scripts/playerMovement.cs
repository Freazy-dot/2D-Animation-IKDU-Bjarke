using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    //Declare Variable for movement input
    private Vector2 movement;
    //Declare Variables for Rigidbody2D and Animator
    private Rigidbody2D myBody;
    private Animator myAnimator;
    //Declare Serialized field for the player speed. Can also be seen in the inspector
    [SerializeField] private int speed = 5;
    // Start is called before the first frame update, is used to get the components for the variables.
    private void Awake()
    {
        //Getting the references to players rigidbody and animator
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    //this method is called whenever theres a movement input
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

        //if theres provided input, this sets the blend tree to "isWalking" to true
        if (movement.x != 0 || movement.y != +0)
        {


            myAnimator.SetFloat("X", movement.x);
            myAnimator.SetFloat("Y", movement.y);

            myAnimator.SetBool("isWalking", true);
            
        }

        else
        //if theres not provided input, this sets the blende tree "isWalking" to false
        {
            myAnimator.SetBool("isWalking", false);
        }
        
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //Sets the players velocity
        myBody.velocity = movement * speed;
    }
}
