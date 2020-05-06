using System.Collections;
using UnityEngine;

public enum PlayerState
{
    walk, 
    attack,
    interact,
    agility,
    special
}

public class PlayerMovement : MonoBehaviour
{
    // Change these via the Inspector instead of hard-coding.
    [SerializeField] private string horizontalInputAxis = "P1_Horizontal";
    [SerializeField] private string verticalInputAxis = "P1_Vertical";
    [SerializeField] private string attackInput = "P1_Attack";

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
        // change = Vector3.zero;
        // ^ Unnecessary since Input.GetAxisRaw will set x/y
        // to 0 if there is no input anyway.
        change.x = Input.GetAxisRaw(horizontalInputAxis);
        change.y = Input.GetAxisRaw(verticalInputAxis);
        // GetAxisRaw doesn't interpolate but instead goes directly into the value 0 - 1; not floaty, more snappy

        if (Input.GetButtonDown(attackInput) && currentState != PlayerState.attack)
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
}