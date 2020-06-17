using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class You_win : MonoBehaviour
{
    private float timer = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(timer);

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {

            timer = 0;
            SceneManager.LoadScene("Menu");

        }
    }
}
