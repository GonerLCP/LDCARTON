using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMaterial : MonoBehaviour
{

    public Material[] materials;
    private int num = 0;
    private int coolDownLimit = 25;
    private int coolDown = 0;
    private bool peutChanger = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (!peutChanger)
        {
            coolDown += 1;
            if (coolDown >= coolDownLimit)
            {
                peutChanger = true;
                coolDown = 0;
            }
        }
    }

    void OnCollisionEnter (Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            changeMat();
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            changeMat();
        }
    }


    void changeMat()
    {
        if (peutChanger == true)
        {
            GetComponent<MeshRenderer>().material = materials[num];
            num += 1;
            if (num >= materials.Length)
            {
                num = 0;
            }
            peutChanger = false;
        }
    }


}
