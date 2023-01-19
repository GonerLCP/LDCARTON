using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreFacade : MonoBehaviour
{
    //var emplacement des facade a instantier
    public GameObject objetFacadeRiche;
    public GameObject objetFacadeBoulanger;
    public GameObject objetFacadeGarde;

    // var est-ce que j'ai une facade ou pas ?
    bool gotFacadeRiche;
    bool gotFacadeBoulanger;
    bool gotFacadeGarde;
    bool jeSuisDansUneFacade;

    public GameObject facadeActuelleToDestroy;
    string facadeActuelle;

    void Start()
    {
        
    }

 
    void Update()
    {
        


       

        //si j'ai touche la facade riche, je peux appuyer sur E pour détruire l'object touche
        //manque zone appuyable que dans la zone de l'objet pour le "manger"
        //manque coordonee pour l'objet instantie.
        if (jeSuisDansUneFacade == true)
        {
            if (gotFacadeRiche == true && Input.GetKeyDown(KeyCode.E))
            {
                //Instantiate(objetFacadeRiche);
                gotFacadeRiche = false;
                Destroy(facadeActuelleToDestroy);
                

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

            print(facadeActuelle);

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
         }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<facadeRamassable>() != null)
        {

        
            //je lui dis de recup la var facade actuelle sur le scirpt du cube

            facadeActuelleToDestroy = null;

            print(facadeActuelle);

            jeSuisDansUneFacade = false;

            // quand je rentre dans la zone de la facade,je passe ma variable "j'ai l'objet" en true
            if (facadeActuelle == "facadeRiche")
            {
                gotFacadeRiche = false;
            }

            else if (facadeActuelle == "facadeGarde")
            {
                gotFacadeGarde = false;
            }

            else if (facadeActuelle == "facadeBoulanger")
            {
                gotFacadeBoulanger = false;
            }
        }
    }
}
