using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rammenner : MonoBehaviour
{
    public FieldOfView Field;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ennemy")
        {
            Field.touchalt144 = false;
            Field.JoueurRammene = true;
        }
    }
}
