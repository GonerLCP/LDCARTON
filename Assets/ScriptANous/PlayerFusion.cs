using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFusion : MonoBehaviour
{
    float inputX;
    float inputZ;

    CharacterController cc;
    public FieldOfView Field;

    float mouvementY = 0;
    float gravity = 0.09f;

    bool toucheSol = false;
    public float forceSaut = 1.5f;

    Vector3 mouvement;

    public float vitesse = 0.3f;

    public Transform grab;

    string[] taglist = { "Player", "Carton" };
    int x = 1;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        GameObject.Find("PlayerCarton").GetComponent<MeshRenderer>().enabled = false;
    }
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.A))
        {

            this.tag = taglist[x];
            if (x == 1) //si tag carton atm alors prochaine sera tag player
            {
                x = x - 1;
                GameObject.Find("PlayerBonhomme").GetComponent<MeshRenderer>().enabled = false;
                GameObject.Find("PlayerBonhommeCylinder").GetComponent<MeshRenderer>().enabled = false;
                GameObject.Find("PlayerCarton").GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                x++;
                GameObject.Find("PlayerBonhomme").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("PlayerBonhommeCylinder").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("PlayerCarton").GetComponent<MeshRenderer>().enabled = false;
            }

        }
    }
    private void FixedUpdate()
    {
        if (Field.touchalt144 == false)
        {
            toucheSol = cc.isGrounded;
            if (toucheSol && mouvementY < 0)
            {
                mouvementY = 0;
            }
            mouvement = Quaternion.Euler(new Vector3(0, 45, 0)) * new Vector3(inputX, 0, inputZ) * vitesse;
            cc.Move(mouvement);
            mouvementY -= gravity;
            cc.Move(new Vector3(0, mouvementY, 0));
        }
    }
}
