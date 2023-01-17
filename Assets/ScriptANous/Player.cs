using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float inputX;
    float inputZ;
    CharacterController cc;
    public Transform empty;

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
        mouvement = new Vector3(inputX * vitesse, empty.transform.position.y, inputZ * vitesse);
        cc.Move(mouvement);
    }
}