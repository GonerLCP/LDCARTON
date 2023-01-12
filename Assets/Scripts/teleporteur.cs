using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporteur: MonoBehaviour
{

    public Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider coll) //quand un objet rentre dans la zone de collision
    {
        if (coll.gameObject.tag == "Player") //si l'objet est le player
        {
            if (destination != null) // si la destination a été définie
            {
                coll.gameObject.transform.position = destination.position; // la position de l'objet est égale à la position de la destination
            }
        }
    }
    
}
