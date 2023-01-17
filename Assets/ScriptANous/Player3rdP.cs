using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3rdP : MonoBehaviour
{
    float inputX;
    float inputZ;
    CharacterController cc;
    Vector3 mouvement;
    public float vitesse = 0.3f;
    public float vitesseRotation = 0.1f;
    float mouvementY = 0;
    float gravity = 0.09f;
    bool toucheSol = false;
    public float forceSaut = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && toucheSol)
        {
            mouvementY = forceSaut;
        }
    }
    private void FixedUpdate()
    {
        toucheSol = cc.isGrounded;
        if (toucheSol && mouvementY < 0)
        {
            mouvementY = 0;
            print("o");
        }
        transform.Rotate(new Vector3(0, inputX * vitesseRotation, 0));
        mouvement = transform.forward * inputZ * vitesse;
        cc.Move(mouvement);
        mouvementY -= gravity;
        cc.Move(new Vector3(0, mouvementY, 0));
    }
}