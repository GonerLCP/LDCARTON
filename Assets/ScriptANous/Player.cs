using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float inputX;
    float inputZ;
    CharacterController cc;

    float mouvementY = 0;
    float gravity = 0.09f;
    bool toucheSol = false;
    public float forceSaut = 1.5f;

    Vector3 mouvement;
    public float vitesse = 0.3f;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
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