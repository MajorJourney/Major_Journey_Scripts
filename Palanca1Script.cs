using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca1Script : MonoBehaviour
{

    public GameObject player = null;
    private PlayerController playercontroller;
    private Animator palancaAnimatorController;

    private bool isactivated;

    public GameObject puentelevantado = null;
    public GameObject puentebajado = null;

    public GameObject textPressF;

    private float timeleft;
    private bool starttimer = false;

    public bool secondDoor;

    // Start is called before the first frame update
    void Start()
    {

        playercontroller = player.gameObject.GetComponent<PlayerController>();
        palancaAnimatorController = GetComponent<Animator>();

        isactivated = true;

        timeleft = 1.5f;
    }

    private void Update()
    {
        if (starttimer)
        {
            timeleft -= Time.deltaTime;
        }

        if (timeleft <= 0.2f)
        {
            secondDoor = true;
        }

        if (timeleft <= -0.2f)
        {

            secondDoor = false;
            this.GetComponent<AudioSource>().enabled = true;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && playercontroller.palanca == true && isactivated)
        {
            palancaAnimatorController.SetTrigger("PalancaTrue");

            puentebajado.SetActive(true);

            puentelevantado.SetActive(false);

            isactivated = false;

            starttimer = true;
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
