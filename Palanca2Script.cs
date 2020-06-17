using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Palanca2Script : MonoBehaviour
{
    public GameObject player = null;
    public GameObject text4;
    private PlayerController playercontroller;
    private Animator palancaAnimatorController;

    public Animator fallingBoxes;
    public GameObject boxes;

    public GameObject caja1 = null;
    public GameObject caja2 = null;
    public GameObject colliderSecret = null;

    public GameObject textPressF;

    private bool isActivated;

    //Timer
    private float timeleft;
    private bool starttimer = false;

    public bool isOpen;

    //AudioSource
    
    public AudioSource audioManager;

    // Start is called before the first frame update
    void Start()
    {

        playercontroller = player.gameObject.GetComponent<PlayerController>();
        palancaAnimatorController = GetComponent<Animator>();

        isActivated = true;

        isOpen = false;

        timeleft = 1.5f;

        //audioManager.clip = Waterplof;

        
    }

    private void Update()
    {
        //Debug.Log(timeleft);

        if (starttimer)
        {
            timeleft -= Time.deltaTime;
        }

        if (timeleft <= 0.3f)
        {
            isOpen = true;
        }

        if (timeleft <= 0)
        {

            fallingBoxes.SetTrigger("Fall");   

        }

        if (timeleft <= -0.2f)
        {

            isOpen = false;
            //audioManager.Play();

            


        }

        if (timeleft <= -2.0f)
        {
            this.GetComponent<AudioSource>().enabled = true;
        }

        if (timeleft <= -3.0f)
        {
            text4.SetActive(true);
            
        }

        if (timeleft <= -7.0f)
        {
            text4.SetActive(false);
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && playercontroller.palanca == true && isActivated)
        {
            palancaAnimatorController.SetTrigger("PalancaTrue");

            starttimer = true;
            
            caja1.SetActive(true);

            caja2.SetActive(true);

            colliderSecret.SetActive(false);

            isActivated = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            textPressF.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            textPressF.SetActive(false);
        }
    }
}
