using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstBossAi : MonoBehaviour
{

    public GameObject target;
    private PlayerController playercontroller;
    public float moveSpeed;
    

    public GameObject boxcollider;
    private AtackCollider atackcoll;



    private Transform myTransform;

    public Animator bossAnimator;

    public float hurted = -1.0f;
    public bool atacker;

    //sistema ataques
    private int round;

    //sistema dialogos
    public GameObject dialogoBat1;
    public GameObject dialogoBat2;

    public GameObject dialogoBoss1;
    public GameObject dialogoBoss2;

    //Timer
    private float timeleft = 0.0f;
    private float timer = 3.0f;
    public float talking;

    //Texto "Press F"
    public GameObject textF;

    //audioSources
    public GameObject pasos;

    
    
    

    //Switch
    enum State {Move,Atack,Interact,End};

    State state;
    State nextState;


    private void Awake()
    {
        //cache transform data for easy access/performance
        myTransform = this.gameObject.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        atackcoll = boxcollider.GetComponent<AtackCollider>();

        playercontroller = target.gameObject.GetComponent<PlayerController>();

        atacker = false;

        pasos.GetComponent<AudioSource>().enabled = false;


        round = 2;
        talking = 2;

        timeleft = timer;

        state = State.Move;
        nextState = State.Move;
       
       
    }

    // Update is called once per frame
    void Update()
    {

        StateMachine();

        //Debug.Log(state);
        //Debug.Log(timeleft);
        Debug.Log(timeleft);
        

        if (round == 1)
        {
            
            if (talking == 2)
            {
                timeleft -= Time.deltaTime;
                dialogoBat1.SetActive(true);
                
                if(timeleft <= 0)
                {
                    talking--;
                    timeleft = timer;
                }
            }

            if (talking == 1)
            {
    
                timeleft -= Time.deltaTime;
                dialogoBat1.SetActive(false);
                dialogoBoss1.SetActive(true);

                if (timeleft <= 0)
                {
                    
                    timeleft = timer;
                    talking--;
                    dialogoBoss1.SetActive(false);
                    
                }
            }
        }

        if (round == 0)
        {

            if (talking == 2)
            {
                timeleft -= Time.deltaTime;
                dialogoBat2.SetActive(true);

                if (timeleft <= 0)
                {
                    talking--;
                    timeleft = timer;
                }
            }

            if (talking == 1)
            {

                timeleft -= Time.deltaTime;
                dialogoBat2.SetActive(false);
                dialogoBoss2.SetActive(true);

                if (timeleft <= 0)
                {

                    timeleft = timer;
                    dialogoBoss2.SetActive(false);
                    talking--;
                }
            }

            if (talking == 0)
            {
                timeleft -= Time.deltaTime;

                if (timeleft <= 0)
                {
                    SceneManager.LoadScene("You_win");
                }
            }
        }

    }
    private void Move()
    {

        

        Vector3 targetposition = new Vector3(target.transform.position.x, 91.81f, target.transform.position.z);

        myTransform.LookAt(targetposition);

        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

        pasos.GetComponent<AudioSource>().enabled = true;

        if (atackcoll.atack == true)
        {
          nextState = State.Atack;
            pasos.GetComponent<AudioSource>().enabled = false;
        }
    }

    private void Atack()
    {

        bossAnimator.SetTrigger("Atack");

        

        nextState = State.Move;

        if(atackcoll.Atackcount <= 0)
        {
            nextState = State.Interact;
        }
        

    }

    private void Interact()
    {

        textF.SetActive(true);

        if (Input.GetButtonDown("Interact"))
        {
            nextState = State.Move;
            atackcoll.Atackcount = 3;
            round--;
            talking = 2;

            textF.SetActive(false);

        }
        if (round == 0)
        {
            nextState = State.End;
        }


    }

    private void StateMachine(){

       

        switch (state)
        {
            case State.Move:

                Move();
                break;

            case State.Atack:
                Atack();
                break;

            case State.Interact:
                Interact();
                break;

            case State.End:
                //SceneManager.LoadScene("Menu");
                break;

            default:
                break;
        }
        state = nextState;

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
