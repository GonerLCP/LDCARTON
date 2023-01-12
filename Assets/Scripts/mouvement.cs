using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement : MonoBehaviour
{

    private float inputX;
    private float inputZ;

    public float vitesse = 10;
    public float vitesseRotation = 2;

    public float jumpForce = 5;
    private float mouvementY = 0;
    public float gravity = 0.5f;

    private Rigidbody rg;
    private Vector3 movement;
    private CapsuleCollider coll;
    public LayerMask groundLayer;

    //dialogue
    public pnjParle currentPnj;
    private List<pnjParle> pnjDansZone = new List<pnjParle>();


    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        coll = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Updte()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
            {
            mouvementY = jumpForce;
            }


        // parler
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentPnj != null)
            {
                currentPnj.parle();
            }
        }

    }

    void FixedUpdate()
    {
        if (!IsGrounded())
        {
            mouvementY -= gravity * Time.deltaTime;
        }
        if (IsGrounded() && mouvementY < 0)
        {
            mouvementY = 0;
        }

        rg.rotation = Quaternion.Euler(0, rg.rotation.eulerAngles.y + inputX * vitesseRotation, 0);
        movement = transform.forward * inputZ * vitesse;
        movement = new Vector3(movement.x, mouvementY, movement.z);

        rg.velocity = movement;
    }

    bool IsGrounded()
        {
        return Physics.CheckCapsule(coll.bounds.center, new Vector3(coll.bounds.center.x, coll.bounds.min.y+0.3f, coll.bounds.center.z), coll.radius * 0.9f, groundLayer);
      
    }


    //pour les dialogues
    public void addPnj(pnjParle pnj)
    {
        currentPnj = pnj;
        pnjDansZone.Add(pnj);
        currentPnj.pnjSelected();
    }

    public void removePnj(pnjParle pnj)
    {
        pnj.pnjUnSelected();
        pnjDansZone.Remove(pnj);
        if (pnjDansZone.Count < 1)
        {
            currentPnj = null;
        } else
        {
            currentPnj = pnjDansZone[0];
        }
    }


}
