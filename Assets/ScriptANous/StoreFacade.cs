using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreFacade : MonoBehaviour
{
    //var emplacement des facade a instantier
    public GameObject objetFacadeRiche;
    public GameObject objetFacadeBoulanger;
    public GameObject objetFacadeGarde;

    // var est-ce que touche cette facade ?
    public bool gotFacadeRiche;
    public bool gotFacadeBoulanger;
    public bool gotFacadeGarde;

    // oui-non, je suis dans le trigger d'un objet qui est une facade
    public bool jeSuisDansUneFacade;

    public GameObject facadeActuelleToDestroy;
    public string facadeActuelle;
    public bool objetEstDetruit = false;

    public Transform spawner;

    void Start()
    {
        
    }

 
    void Update()
    {
        // instancier l'objet
        if (gotFacadeRiche == true && Input.GetKeyDown(KeyCode.E) && objetEstDetruit == true)
        {
            objetEstDetruit = false;
            Instantiate(objetFacadeRiche,spawner.position,spawner.rotation);
            gotFacadeRiche = false;
        }

        if (gotFacadeBoulanger == true && Input.GetKeyDown(KeyCode.E) && objetEstDetruit == true)
        {
            objetEstDetruit = false;
            Instantiate(objetFacadeBoulanger, spawner.position, spawner.rotation);
            gotFacadeBoulanger = false;
        }

        if (gotFacadeGarde == true && Input.GetKeyDown(KeyCode.E) && objetEstDetruit == true)
        {
            objetEstDetruit = false;
            Instantiate(objetFacadeGarde, spawner.position, spawner.rotation);
            gotFacadeGarde = false;
        }

        
        // detruire l'objet
        if (jeSuisDansUneFacade == true)
        {
            if (facadeActuelle == "facadeRiche" && Input.GetKeyDown(KeyCode.E))
            {
                
                Destroy(facadeActuelleToDestroy);
                objetEstDetruit = true;
                gotFacadeRiche = true;
                jeSuisDansUneFacade = false;
                facadeActuelle = null;

            }

            else if (facadeActuelle == "facadeBoulanger" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(facadeActuelleToDestroy);
                objetEstDetruit = true;
                gotFacadeBoulanger = true;
                jeSuisDansUneFacade = false;
                facadeActuelle = null;
            }

            else if (facadeActuelle == "facadeGarde" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(facadeActuelleToDestroy);
                objetEstDetruit = true;
                gotFacadeGarde = true;
                jeSuisDansUneFacade = false;
                facadeActuelle = null;
            }
        }

        



    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<facadeRamassable>() != null)
        {
            
            jeSuisDansUneFacade = true;
            

            //je recup ma variable d'un autre script et je lui donne un nouveau nom
            facadeActuelle = collision.gameObject.GetComponent<facadeRamassable>().nomFacade;
            facadeActuelleToDestroy = collision.gameObject;

            /*
            // quand je rentre dans la zone de la facade,je passe ma variable "j'ai l'objet" en true
            if (facadeActuelle == "facadeRiche")
            {
                gotFacadeRiche = true;
            }

            else if (facadeActuelle == "facadeGarde")
            {
                gotFacadeGarde = true;
            }

            else if (facadeActuelle == "facadeBoulanger")
            {
                gotFacadeBoulanger = true;
            }
            */
         }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<facadeRamassable>() != null)
        {

        
            //je lui dis de recup la var facade actuelle sur le scirpt du cube

            facadeActuelleToDestroy = null;
            facadeActuelle = null;


            jeSuisDansUneFacade = false;

            

            
        }
    }
}
