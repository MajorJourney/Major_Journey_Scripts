using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public float timer;
    private float timeLeft;
    private int dialogo;

    public GameObject player;
    public GameObject boss;

    // Dialogos Bat
    public GameObject dialogoBat1;
    

    //Dialogos Boss
    public GameObject dialogoBoss1;

   
    

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timer;

        dialogo = 3;
        dialogoBat1.SetActive(true);
      
    }

    // Update is called once per frame
    void Update()
    {



            if (dialogo > 0)
            {
                if (Input.GetButtonDown("Interact"))
                {
                dialogo--;
                }
            }
            

            if (dialogo == 2)
            {
            dialogoBat1.SetActive(false);
            dialogoBoss1.SetActive(true);

            
                
                
            }

            if (dialogo == 1)
            {

            dialogoBoss1.SetActive(false);

            player.GetComponent<PlayerController>().enabled = true;

            boss.GetComponent<FirstBossAi>().enabled = true;

            
            

            }

           /* if (dialogo == 0 && Input.GetButtonDown("Interact"))
            {
                
                player.GetComponent<PlayerController>().enabled = true;

                boss.GetComponent<FirstBossAi>().enabled = true;
            }*/
            
        

        //Debug.Log("Contador: " + timeLeft);
        //Debug.Log("Dialogo: " + dialogo);
    }
}
