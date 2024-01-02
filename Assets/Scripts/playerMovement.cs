using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    private Vector2 movement;
    private Rigidbody2D myBody;
    private Animator myAnimator;

    [SerializeField] private int speed = 5;
    // Start is called before the first frame update
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

        if (movement.x != 0 || movement.y != +0)
        {


            myAnimator.SetFloat("X", movement.x);
            myAnimator.SetFloat("Y", movement.y);

            myAnimator.SetBool("isWalking", true);
        }

        else
        {
            myAnimator.SetBool("isWalking", false);
        }
        
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        myBody.velocity = movement * speed;
    }
}
