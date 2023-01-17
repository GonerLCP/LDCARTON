using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    Vector3 mouvement;
    Vector3 rotation;
    Vector3 directionToTarget;

    public float vitesse = 0.3f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
        rb = GetComponent<Rigidbody>();
    }

    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;

                    print("PLAYER !");
                    mouvement = new Vector3((target.position.x -transform.position.x), 0, (target.position.z - transform.position.z));
                    mouvement = mouvement.normalized;
                    rotation = new Vector3(target.position.x, 1, target.position.z);
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }

    private void FixedUpdate()
    {
        if (canSeePlayer == true)
        {
            rb.velocity = mouvement*vitesse;
            transform.LookAt(rotation);
        }
        else
        {
            transform.LookAt(new Vector3(0, 0, 0));
        }
    }
}