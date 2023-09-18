using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;


// handles and takes movement for the player character 
public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1f;

    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    private float activeMoveSpeed;
    public bool canDash = true;
    public bool isDashing;
    public float dashingTime = 0.2f;
    public float dashingPower = 5f;
    public float dashCooldown = 5f;
    private float dashCounter = 0;
    private float NextDashTime = 0;
    public Logic LogicScript;






    Vector2 movementInput;
    public Rigidbody2D rb;

    Animator animator;

    SpriteRenderer spriteRenderer;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        LogicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();

        //activeMoveSpeed = moveSpeed;
    }





    private void FixedUpdate()
    {
        //if movement inout is NOT zero then try and move.



        if (movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);

            if (!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));

            }

            if (!success)
            {
                success = TryMove(new Vector2(0, movementInput.y));
            }



            animator.SetBool("isMoving", success);

        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }




    }

    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {


            int count = rb.Cast(
                    direction, // x and y values between -1 and 1 that represent the direction from the body to look for collisions
                    movementFilter, // Setting that deteremine where a collison can occur on layers to collide with
                    castCollisions, //List of collisions to store the found collisions into after the cast is finsihed 
                    moveSpeed * Time.fixedDeltaTime + collisionOffset); // the amount of cast equalto the movement plus offset
            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();

    }



}

