using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hurt : MonoBehaviour
{
    public GameObject player;
    private PlayerController playercontroller;

    public float hurted = -1.0f;
    public bool atacker;

    public GameObject atack;
    public AudioSource sound;
    public AudioClip atackClip;


    // Start is called before the first frame update
    void Start()
    {
        playercontroller = player.gameObject.GetComponent<PlayerController>();

        atacker = false;

        sound = atack.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (atacker == true)
        {
            Hurter();
            atacker = false;
            //atack.GetComponent<AudioSource>().enabled = true;
            sound.PlayOneShot(atackClip);
        }
        else
        {
            //atack.GetComponent<AudioSource>().enabled = false;
        }
    }

    void Hurter()
    {
        playercontroller.life = playercontroller.life + hurted;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            atacker = true;
          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            atacker = false;
        }
    }
}
