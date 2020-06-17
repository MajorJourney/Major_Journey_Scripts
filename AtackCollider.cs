using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackCollider : MonoBehaviour
{

    public bool atack = false;
    public int Atackcount;

    private void Start()
    {
        Atackcount = 3;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            atack = true;
            Atackcount--;
            
        } 
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            atack = false;
            //Atackcount--;
        }
        
    }



}
