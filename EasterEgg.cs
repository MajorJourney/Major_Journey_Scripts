using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasterEgg : MonoBehaviour
{

    public GameObject pressF;
    public GameObject apocalipsisImage1;
    public GameObject apocalipsisImage2;
    public GameObject apocalipsisImage3;

    private bool easterBool = false;

    private float timer = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {

        

        Debug.Log(timer);

        if (easterBool)
        {

            pressF.SetActive(false);

            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                apocalipsisImage1.SetActive(false);
                apocalipsisImage2.SetActive(false);
                apocalipsisImage3.SetActive(false);

                

                

                SceneManager.LoadScene("Boss_Fight");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            pressF.SetActive(true);

            if (Input.GetButtonDown("Interact"))
            {
                apocalipsisImage1.SetActive(true);
                apocalipsisImage2.SetActive(true);
                apocalipsisImage3.SetActive(true);

                easterBool = true;

            }
        }
    }

}
