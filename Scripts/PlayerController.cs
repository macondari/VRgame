using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerBody; // control of players rigidbody
    public float jumpForceA = 10f;
    public float jumpForceB = 10f;
    public float gravityChanger;
    public bool onGround = true;
    public bool gameOver = false;
    private Animator playerAnimate;
    public ParticleSystem explosionPart;
    public ParticleSystem dirtPart;
    public float speed = 2;
    public bool isRotate = false;
    public FinalTimeDisplay finalTimeDisplayScript;
    public StopWatch stopWatchScript;
    public MoveLeft moveLeftScript;
    public ParticleSystem endEffect;
    public ParticleSystem endGlow;


    // Start is called before the first frame update
    void Start()
    {
       playerBody = GetComponent<Rigidbody>(); // initializes playerbody as the rigid body
                                               // component applied to the character in unity
        playerAnimate = GetComponent<Animator>();
        Physics.gravity *= gravityChanger; // changes the gravity on the player
        playerBody.constraints = RigidbodyConstraints.FreezePositionX; //stops player from                                                                   
        playerBody.constraints = RigidbodyConstraints.FreezePositionY; //rotating and falling over
        playerBody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //not rotated and a bit after rotation
        OVRInput.Update();
        if (transform.position.x < 40 && !isRotate)
        {
            
            if(OVRInput.GetDown(OVRInput.Button.One) && onGround && !gameOver) // player jumps 
            //if (Input.GetKeyDown(KeyCode.N) && onGround && !gameOver)
            {
                playerBody.AddForce((Vector3.up + Vector3.right) * jumpForceA, ForceMode.Impulse); // moves player up with force 500
                                                                                                   //types of force mode: Impulse = imediately, type ForceMode.
                                                                                                   //and wait for suggestions list, hover over to see options w/ a description
                onGround = false;
                playerAnimate.SetTrigger("Jump_trig");
                dirtPart.Stop();
                
            }
            else if (OVRInput.GetDown(OVRInput.Button.Two) && onGround && !gameOver) // player jumps 
            //else if (Input.GetKeyDown(KeyCode.M) && onGround && !gameOver)
            {
                playerBody.AddForce((Vector3.up + Vector3.right) * jumpForceB, ForceMode.Impulse); // moves player up with force 500
                                                                                                   //types of force mode: Impulse = imediately, type ForceMode.
                                                                                                   //and wait for suggestions list, hover over to see options w/ a description
                onGround = false;
                playerAnimate.SetTrigger("Jump_trig");
                dirtPart.Stop();
            }
        }
        else if (transform.position.x < 12 && isRotate) // end game
        {
            gameOver = true;

            dirtPart.Stop();
            endEffect.Play();
            endGlow.Play();
            
            playerAnimate.Play("Idle");
            stopWatchScript.isRunning = false;
            finalTimeDisplayScript.DisplayTime();
            finalTimeDisplayScript.timeDisplayText.text += " You Won The Game!!";
        }
        else //during rotation
        {
            
            isRotate = true;
            gameObject.transform.rotation = Quaternion.Euler(0f, 268, 0f);

            if(OVRInput.GetDown(OVRInput.Button.One) && onGround && !gameOver) // player jumps 
            //if (Input.GetKeyDown(KeyCode.N) && onGround && !gameOver)
            {
                playerBody.AddForce((Vector3.up + Vector3.right) * jumpForceA, ForceMode.Impulse); // moves player up with force 500
                                                                                                   //types of force mode: Impulse = imediately, type ForceMode.
                                                                                                  //and wait for suggestions list, hover over to see options w/ a description
                onGround = false;
                playerAnimate.SetTrigger("Jump_trig");
                dirtPart.Stop();
                

               
            }
            else if (OVRInput.GetDown(OVRInput.Button.Two) && onGround  && !gameOver) // player jumps 
            //else if (Input.GetKeyDown(KeyCode.M) && onGround && !gameOver)
            {
                playerBody.AddForce((Vector3.up + Vector3.right) * jumpForceB, ForceMode.Impulse); // moves player up with force 500
                                                                                                   //types of force mode: Impulse = imediately, type ForceMode.
                                                                                                   //and wait for suggestions list, hover over to see options w/ a description
                onGround = false;
                playerAnimate.SetTrigger("Jump_trig");
                dirtPart.Stop();
            }
        }

        

    }

    private void OnCollisionEnter(Collision collision) // is called when two colliders come in contact
    {

        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            Debug.Log("ground");
            dirtPart.Play();
            //ground collider and collider of object which script is applied to are in contact
            onGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle")) //collides with obstacle
        {
            dirtPart.Stop();
            explosionPart.Play();
           
            string timeDisplay = finalTimeDisplayScript.FormatTime(stopWatchScript.GetElapsedTime());
            finalTimeDisplayScript.ActivateObject();
            stopWatchScript.StopStopwatch();
            finalTimeDisplayScript.timeDisplayText.text = timeDisplay + " You Lost The Game";

            //calls play function on something of type particle
            // death animation occurs here
            playerAnimate.SetBool("Death_b", true); // sets to death state
            playerAnimate.SetInteger("DeathType_int", 1); // selects death type 1
            gameOver = true;

        }
        
        
    }

   

}
