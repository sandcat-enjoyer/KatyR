using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playerControl;

    public float speed;
    public float jump;
    public float maxSpeed = 20f;
    
    private Vector3 playerMove;
    private Vector3 playerJump;
    public float realSpeed = 1f;
    [SerializeField] private Animator animator;

    private Vector3 StartingPosition;
    void Start()
    {
        StartingPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame or something like that i do not know :-3
    void Update()
    {
        // Collect player input :3
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        
        // Apply input to player movement :3
        playerMove = (transform.right * xMovement + transform.forward * zMovement) * realSpeed;
        
        // Increase player meows as they go :3
        if (Mathf.Abs(xMovement) + Mathf.Abs(zMovement) > 0)
        {
            realSpeed += Time.deltaTime * speed;
            realSpeed = Mathf.Clamp(realSpeed, 1f, maxSpeed);
            animator.SetBool("isRunning", true);
        }
        else { realSpeed = 1f;
            animator.SetBool("isRunning", false);
        }
        
        // Apply gravity :3
        float yMovement = Physics.gravity.y;
        playerJump.y += yMovement * Time.deltaTime;
        // Jump when grounded :3
        if (Input.GetButtonDown("Jump") && playerControl.isGrounded)
        {
            playerJump.y = Mathf.Sqrt(jump * -2f * yMovement);
        }
        
        //there's probably a million better ways to do this but i'm lazy :3
        playerControl.Move(playerMove * Time.deltaTime + playerJump * Time.deltaTime);
    }
}
