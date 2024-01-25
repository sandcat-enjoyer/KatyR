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
    
    private Vector3 playerMove;
    private Vector3 playerJump;
    private float realSpeed = 1f;

    private Vector3 StartingPosition;
  // only used in ip man fight

    void Start()
    {
        StartingPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame or something like that i do not know :-3
    void Update()
    {
        /*
        // Emmm ok I change the things so we DO NOT RESTART scene when we fall we just go back to where we started to avoid CHEATING the SECRETS :-)
        if (transform.position.y < -70f)
        {
            switch (SceneManager.GetActiveScene().buildIndex) 
            {
                case 22: // ip man fight
                    if (ipMan.GetComponent<IPManBoss>().PlayerHealth <= 0) 
                    {
                        IPManStats.PlayerLoseCounter++;
                        SceneManager.LoadScene(21);
                    }
                    else 
                    {
                        // first we wanna find out how many platforms are active -- we need to do this because the STICKY ATTACK disables
                        // certain platforms and we don't want to place the player in a position where there isn't a platform

                        int platformCount = 0;
                        GameObject platforms = GameObject.Find("Platforms");
                        GameObject player = GameObject.Find("Player_Boss");

                        for (int i = 0; i <= 9; i++) 
                        {
                            if (platforms.transform.GetChild(i).gameObject.activeSelf) 
                            {
                                platformCount++;
                            }
                        }

                        // now we use the value of platformCount to determine where to place the player
                        // if it's 10, we know all platforms are enabled and we can place the player anywhere we want
                        // if it's not, it's a safe assumption that an attack is occuring, so loop through each platform until we find an active one
                        // and place the player there.

                        // we move the player based on the position of the platforms, but we force the player up by .6 on the y axis because they
                        // fall through the platform otherwise :3

                        if (platformCount != 10)
                        {
                            bool isDone = false;
                            int count = 0;

                            while (!isDone) 
                            {
                                if (!platforms.transform.GetChild(count).gameObject.activeSelf) 
                                {
                                    count++;
                                }
                                else 
                                {
                                    Transform platform = platforms.transform.GetChild(count);
                                    player.transform.position = new Vector3(platform.position.x, platform.position.y + 0.6f, platform.position.z);
                                    isDone = true;
                                }
                            }
                        }
                        else
                        {
                            int randPlat = Random.Range(0, 9);
                            Transform platform = platforms.transform.GetChild(randPlat);
                            player.transform.position = new Vector3(platform.position.x, platform.position.y + 0.6f, platform.position.z);
                        }

                        Physics.SyncTransforms();

                        ipMan.GetComponent<IPManBoss>().PlayerHealth -= 3;
                        GameObject.Find("KatyHealthCounter").GetComponent<Slider>().value = ipMan.GetComponent<IPManBoss>().PlayerHealth;
                    }

                    break;

                case 21:
                    SceneManager.LoadScene(22);
                    break;
                case 8:
                    SceneManager.LoadScene(11);
                    break;
                default:
                    gameObject.transform.position = StartingPosition;
                    Physics.SyncTransforms();
                    break;
            }
        }
        */
        
        // Collect player input :3
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        
        // Apply input to player movement :3
        playerMove = (transform.right * xMovement + transform.forward * zMovement) * realSpeed;
        
        // Increase player meows as they go :3
        if (Mathf.Abs(xMovement) + Mathf.Abs(zMovement) > 0) { realSpeed += Time.deltaTime * speed; }
        else { realSpeed = 1f; }
        
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
