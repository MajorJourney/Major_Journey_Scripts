using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput;

    private CharacterController player;

    public float playerSpeed;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    public float fallVelocity;
    public float jumpForce;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 CamRight;

    private Animator playerAnimatorController;

    public bool palanca;

    public GameObject spawn_danger_zone;

    public float life = 3.0f;
    

    //Life System
    public GameObject heart1;

    public GameObject heart2;

    public GameObject heart3;

    //Audio System
    public AudioClip clips;
    public AudioClip jump;

    public AudioSource audioManager;

    // Start is called before the first frame update
    void Start()
    {

        
        player = GetComponent<CharacterController>();
        playerAnimatorController = GetComponent<Animator>();

        life = 3.0f;

        heart1.SetActive(true);
        heart1.SetActive(true);
        heart1.SetActive(true);

        

    }

    // Update is called once per frame
    void Update()
    {

        

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        playerAnimatorController.SetFloat("PlayerWalkVelocity", playerInput.magnitude * playerSpeed);

        camDirection();

        movePlayer = playerInput.x * CamRight + playerInput.z * camForward;

        movePlayer = movePlayer * playerSpeed;

        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();

        PlayerSkills();

        player.Move(movePlayer * Time.deltaTime);

        Palanca();

        LifeSystem();

        //Debug.Log(life);

        /*if(player.isGrounded == true && player.velocity.magnitude < 2f)
        {
            Step();
        }*/

    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        CamRight = mainCamera.transform.right;

        camForward.y = 0;
        CamRight.y = 0;

        camForward = camForward.normalized;
        CamRight = CamRight.normalized;
    }

    void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
            playerAnimatorController.SetTrigger("PlayerJump");
        }
    }

    void SetGravity()
    {
        
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
            playerAnimatorController.SetFloat("PlayerVerticalVelocity", player.velocity.y);
        }
        playerAnimatorController.SetBool("IsGrounded", player.isGrounded);
    }


    void Palanca()
    {
        if (Input.GetButtonDown("Interact"))
        {
            palanca = true;
            
        }
        else
        {
            palanca = false;
        }

    }

    void LifeSystem()
    {
        if (life == 2)
        {
            heart3.SetActive(false);
        }

        if (life == 1)
        {
            heart2.SetActive(false);
        }
        if (life <= 0)
        {
            heart1.SetActive(false);
            SceneManager.LoadScene("Boss_Fight");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Palanca" && palanca == true)
        {
            playerAnimatorController.SetTrigger("PlayerPalanca");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Danger_Zone")
        {

            this.transform.position = spawn_danger_zone.transform.position;

        }
    }

    public void Step()
    {

        audioManager.clip = clips;

        audioManager.Play();

    }

    public void JumpSound()
    {
        audioManager.clip = jump;

        audioManager.Play();
    }


}
