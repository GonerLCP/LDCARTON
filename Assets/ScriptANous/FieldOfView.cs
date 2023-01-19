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
    public bool touchalt144;
    public bool JoueurRammene;

    Vector3 mouvement;
    Vector3 rotation;
    Vector3 directionToTarget;

    public float vitesse = 0.3f;

    Rigidbody rb;
    public Transform atlook;
    public Transform rammener;
    public Transform grab;
    public Transform spawnPoint;
    public List<Transform> PositionRonde;
    Transform PositionProchaineRonde;

    public GameObject Player;

    int y =0;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
       // StartCoroutine(RondeRoutine());
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

    private IEnumerator RondeRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            Ronde();
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
        bool unefois = false;

        if (canSeePlayer == true && touchalt144 == false && JoueurRammene == false && GameObject.Find("Player").tag =="Player") //Si le perso est dans sa "ronde" et qu'il voit le perso , alors lui fonce dessus
        {
            rb.velocity = mouvement*vitesse;
            transform.LookAt(rotation);
            unefois = true;
        }
        else if(unefois == true) //Dans le cas ou on sort de sa vision pour qu'il regarde devant lui, on le fait une fois pour �viter qu'il coto
        {
            transform.LookAt(atlook.position);
            unefois = false;
        }

        if (touchalt144) //S'il � touch� le perso, il l'enmenne � la position rammenner (game object dans la sc�ne) 
        {
            Vector3 destination = new Vector3(rammener.position.x - transform.position.x, 0, rammener.position.z - transform.position.z)*vitesse;
            rb.velocity = destination.normalized*vitesse;
            transform.LookAt(rammener.position);
            Player.transform.position = grab.transform.position;
        }

        if (JoueurRammene)//Quand guard arriv� � point de rammennage, alors il retourne � sa position de base
        {
            Vector3 Spawn = new Vector3(spawnPoint.position.x - transform.position.x, 0, spawnPoint.position.z - transform.position.z) * vitesse;
            rb.velocity = Spawn.normalized * vitesse;
            transform.LookAt(spawnPoint.position);
        }

        if ((canSeePlayer && touchalt144 && JoueurRammene) == false)
        {
            Vector3 destination = new Vector3(PositionProchaineRonde.position.x - transform.position.x, 1, PositionProchaineRonde.position.z - transform.position.z) * vitesse;
            rb.velocity = destination.normalized * vitesse;
            transform.LookAt(PositionProchaineRonde.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            touchalt144 = true;
            canSeePlayer = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PointRammener") //Si arriv� � destination de rammenage
        {
            canSeePlayer = false;
            touchalt144 = false;
            JoueurRammene = true;
        }

        if (other.tag == "PointSpawnGuard") //Si arriv� � position de base
        {
            canSeePlayer = false;
            touchalt144 = false;
            JoueurRammene = false;
            rb.velocity = new Vector3(0,0,0);
            transform.LookAt(new Vector3(0,1,0));
            Transform PositionProchaineRonde = PositionRonde[0];
        }

        if (other.tag == "PointRondeGuard") //Si arriv� � position de base
        {
            if (y==PositionRonde.Capacity)
            {
                y = 0;
            }
            else { y++; }
            Transform PositionProchaineRonde = PositionRonde[y];
        }
    }

    private void Ronde()
    {


    }
}