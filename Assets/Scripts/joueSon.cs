using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joueSon : MonoBehaviour
{

    public AudioClip son;
    private soundManager sm;
    public bool randomPitch = false;

    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.FindObjectOfType<soundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            sm.PlaySingleSound(son,0,randomPitch);
            
        }
    }
}
