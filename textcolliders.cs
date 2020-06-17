using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textcolliders : MonoBehaviour
{
    public GameObject text;
    private float timer = 4;
    private bool isEnter = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(text);

        if (isEnter)
        {

            timer -= Time.deltaTime;
            text.SetActive(true);

        }

        if (timer <= 0)
        {
            text.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isEnter = true;

        }
    }
}
