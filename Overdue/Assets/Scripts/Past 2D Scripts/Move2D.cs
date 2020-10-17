using UnityEngine;
using System.Collections;

public enum State {Idle, Walking, Jumping}

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class Move2D : MonoBehaviour
{

    public float speed = 5;
    public float jumpAccelleration = 20;
    public float tempAccelleration = 0;
    public float gAccelleration = 98.1f;
    private bool isGrounded = true;
    private float moveHorizontal = 0;
    private float moveVertical = 0;
    private State state = State.Idle;

    private bool canJump = true;
    private bool canWalk = true;
    private bool canIdle = false;

    private void Start() {
        PlayerController();
    }

    public Boundary boundary;
    void FixedUpdate()
    {
        PlayerController();
    }

    void PlayerMovement(){
        

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        GetComponent<Rigidbody2D>().velocity = movement * speed;

        GetComponent<Rigidbody2D>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax),
                0.0f
                );
        
    }

    void Idle()
    {
        GetComponent<Animator>().SetBool("Idle", true);
    }

    void Walking()
    {
        PlayerMovement();
        SetWalkingAnimations();
    }

    void SetWalkingAnimations()
    {
        //ANIMATIONS
        if (moveVertical > 0)
        {
            GetComponent<Animator>().SetBool("WalkingUp", true);
            Debug.Log("Walking Up");
        }
        else
        {
            GetComponent<Animator>().SetBool("WalkingUp", false);
        }
        if (moveHorizontal < 0)
        {
            GetComponent<Animator>().SetBool("WalkingLeft", true); 
            Debug.Log("Walking Left");           
        }
        else
        {
            GetComponent<Animator>().SetBool("WalkingLeft", false);
        }
        if (moveVertical < 0)
        {
            GetComponent<Animator>().SetBool("WalkingDown", true);            
        }
        else
        {
            GetComponent<Animator>().SetBool("WalkingDown", false);
        }
        if (moveHorizontal > 0)
        {
            GetComponent<Animator>().SetBool("WalkingRight", true);            
        }
        else
        {
            GetComponent<Animator>().SetBool("WalkingRight", false);
        }
    }

    void Jumping()
    {
        if (isGrounded)
        {
            canIdle = true;
            canWalk = true;
            canJump = true;
        }
        else
        {
            transform.position += new Vector3(0,0,tempAccelleration * Time.deltaTime);
            tempAccelleration -= gAccelleration * Time.deltaTime;
            Debug.Log("Temp: " + tempAccelleration + " G: " + gAccelleration);
            if (transform.position.z < 0.5 && tempAccelleration < 0) // failsafe to make zpos 0
            {
                transform.position = new Vector3 (transform.position.x,transform.position.y,Mathf.Abs(transform.position.z - transform.position.z));
                isGrounded = true;    
            }
        }
        PlayerMovement();
    }

    void PlayerController(){
        /* CONTROLS *
         * We are storing the directional input (into two variables) 
         *
         * We use Input.GetAxis() as it works for Arrow Keys, WASD, and even controllers
         *
         * When the Vertical Input Axis is positive (moveVertical > 0) we know that the "joystick" is up
         *
         * ** JOYSTICK Configurations **
         * **UP** (moveVertical > 0)
         * **DOWN** (moveVertical < 0)
         * **RIGHT** (moveHorizontal > 0)
         * **LEFT** (moveHorizontal < 0)
         * 
         * From this, Unity also knows diagonal input as well
         * e.g. **UP+LEFT** (moveVertical > 0) && (moveHorizontal < 0)
         */
        moveHorizontal = Input.GetAxis("Horizontal"); // Represents moving a joystick left/right
        moveVertical = Input.GetAxis("Vertical"); // Represents moving a joystick up/down

        /*
         * Below is a simple state machine, state machines are a great way to avoid bugs*
         * e.g. "Unwanted Double Jumping" or "Moving While Player is Dead"
        */

         /* **STATES** */
        switch  (state)
        {
            case State.Idle:
            {
                Idle();
                break;
            }
            case State.Walking:
            {
                Walking();
                break;
            }
            case State.Jumping:
            {
                Jumping();
                break;
            }
        }
        StateTransiton();
    }

    void StateTransiton(){

        /* ENTER IDLE STATE */
        if (canIdle && (moveHorizontal == 0 && moveVertical == 0))
        {
            state = State.Idle;
            Debug.Log("Entered Idle State");

            /* STATES WHICH THE IDLE STATE CAN GO TO IMMEDIATELY */
            canJump = true;
            canWalk = true;
            canIdle = false;
        }
        /* ENTER JUMPING STATE */
        else if (canJump && Input.GetButton("Jump"))
        {
            state = State.Jumping;
            tempAccelleration = jumpAccelleration;
            isGrounded = false;
            Debug.Log("Entered Jumping State");

            /* STATES WHICH THE JUMPING STATE CAN GO TO IMMEDIATELY */
            canJump = false;
            canIdle = false;
            canWalk = false;
        }
        /* ENTER WALKING STATE */
        else if (canWalk && (moveHorizontal != 0 || moveVertical != 0))
        {
            state = State.Walking;
            Debug.Log("Entered Walking State");

            /* STATES WHICH THE WALKING STATE CAN GO TO IMMEDIATELY */
            canIdle = true;
            canJump = true;
            canWalk = false;
        }
    }

    /// Sent each frame where another object is within a trigger collider
    /// attached to this object (2D physics only).
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag.Equals("DeathPit") && state != State.Jumping)
        {
            Debug.Log("YOU DIED");
        }
    }
}
