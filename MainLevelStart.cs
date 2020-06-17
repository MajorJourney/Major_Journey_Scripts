using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLevelStart : MonoBehaviour
{

    public GameObject text1;
    public GameObject pressF;
    public GameObject player;

     public GameObject gameplay_menu;
     private bool menu_active = false;

    // Start is called before the first frame update
    void Start()
    {
        text1.SetActive(true);
        gameplay_menu.SetActive(false);
        pressF.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       
        //Debug.Log(menu_active);


        if(Input.GetKeyDown(KeyCode.Escape)){

            menu_active = !menu_active;

        }

        if(menu_active) {

            gameplay_menu.SetActive(true);

        } else {

            gameplay_menu.SetActive(false);
         }
        

        if (Input.GetButtonDown("Interact"))
        {
            player.GetComponent<PlayerController>().enabled = true;

            pressF.SetActive(false);

            text1.SetActive(false);
        }

    }


    public void GoToGame(){

        menu_active = false;


    }
}
