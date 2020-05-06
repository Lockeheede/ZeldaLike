using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{
    walk, 
    attack,
    action,
    agility,
    special
}
public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
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

        if(Input.GetButtonDown("P1_Attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }

        else if (currentState == PlayerState.walk)
        {
            //Debug.Log(change); Use to see what happens when you use the Axis
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.20f);
        currentState = PlayerState.walk;
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

    private void SpeedUp()
    {
      
    }

    
}