using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDesactive : MonoBehaviour
{
    public bool desactive = true;
    public bool active = false;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            activeDesacive();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            activeDesacive();
        }
    }

    private void activeDesacive()
    {
        if (active && !desactive)
        {
            target.SetActive(true);
        }
        else if (desactive && !active)
        {
            target.SetActive(false);
        }
        else if (active && desactive)
        {
            target.SetActive(!target.activeInHierarchy);
        }
    }
}
