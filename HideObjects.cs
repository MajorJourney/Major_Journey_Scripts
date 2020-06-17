using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObjects : MonoBehaviour
{
    public GameObject obj1 = null;
    public GameObject obj2 = null;
    public GameObject obj3 = null;
    public GameObject obj4 = null;
    public GameObject obj5 = null;

    private bool active = true;

    public Material transparent;

    private Material material1;
    private Material material2;
    private Material material3;
    private Material material4;
    private Material material5;

    private void Start()
    {
        material1 = obj1.GetComponent<Renderer>().material;
        material2 = obj2.GetComponent<Renderer>().material;
        material3 = obj3.GetComponent<Renderer>().material;
        material4 = obj4.GetComponent<Renderer>().material;
        material5 = obj5.GetComponent<Renderer>().material;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            active = !active;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            active = !active;
        }
    }

    private void Update()
    {
        if (active)
        {
            obj1.GetComponent<Renderer>().material = material1;
            obj2.GetComponent<Renderer>().material = material2;
            obj3.GetComponent<Renderer>().material = material3;
            obj4.GetComponent<Renderer>().material = material4;
            obj5.GetComponent<Renderer>().material = material5;
        }
        else
        {
            obj1.GetComponent<Renderer>().material = transparent;
            obj2.GetComponent<Renderer>().material = transparent;
            obj3.GetComponent<Renderer>().material = transparent;
            obj4.GetComponent<Renderer>().material = transparent;
            obj5.GetComponent<Renderer>().material = transparent;
        }
    }
}
