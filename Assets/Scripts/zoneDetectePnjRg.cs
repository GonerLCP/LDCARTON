using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneDetectePnjRg : MonoBehaviour {

    private mouvement persoMainScript;

    // Use this for initialization
    void Start()
    {
        persoMainScript = GameObject.FindObjectOfType<mouvement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.GetComponent<pnjParle>())
        {
            persoMainScript.addPnj(coll.gameObject.GetComponent<pnjParle>());
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.GetComponent<pnjParle>())
        {
            persoMainScript.removePnj(coll.gameObject.GetComponent<pnjParle>());
        }
    }
}
