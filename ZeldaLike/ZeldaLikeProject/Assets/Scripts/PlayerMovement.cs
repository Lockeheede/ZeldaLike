using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidBody;
    private Animator animator;
    private Vector3 change;
    

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        UpdateAnimationAndMove();
    }

    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("P1_Horizontal");
        change.y = Input.GetAxisRaw("P1_Vertical");
        //GetAxisRaw doesn't interpolate but instead goes directly into the value 0 - 1; not floaty, more snappy

        //Debug.Log(change); Use to see what happens when you use the Axis
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter(); //Don't forget to call your methods
            animator.SetBool("moving", true);
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    private void OnMovement(InputValue value)
    {

    }
    private void OnMoveUp()
    {
        transform.Translate(transform.up);
    }
    private void OnMoveDown()
    {
        transform.Translate(-transform.up);
    }
    private void OnMoveRight()
    {
        transform.Translate(transform.right);
    }
    private void OnMoveLeft()
    {
        transform.Translate(-transform.right);
    }

    
}