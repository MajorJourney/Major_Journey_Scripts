using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCinematica : MonoBehaviour
{

    private float timer = 23.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer);

        timer -= Time.deltaTime;

        if (timer <= 0f || Input.GetButtonDown("Interact"))
        {

            timer = 0;
            SceneManager.LoadScene("Main_Level");

        }
    }
}
