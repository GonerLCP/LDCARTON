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




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //si j'ai touché la facade riche, je peux appuyer sur E pour "pondre" le prefab facade riche, ça détruit l'objet touché aussi 
        //manque zone appuyable que dans la zone de l'objet pour le "manger"
        //manque coordonée pour l'objet instantié.
        if (gotFacadeRiche == true ) 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(objetFacadeRiche);
                gotFacadeRiche = false;
                DestroyImmediate(objetFacadeRiche, true);
            }
            
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //je recup ma variable d'un autre script et je lui donne un nouveau nom
        string facadeActuelle = GameObject.Find("Cube").GetComponent<facadeRamassable>().nomFacade;

        print(facadeActuelle);

        // je passe ma variable "j'ai l'objet" en true
        if (facadeActuelle == "facadeRiche")
        {
            gotFacadeRiche = true;
        }

        else if (facadeActuelle == "facadeGarde")
        {

        }

        else if (facadeActuelle == "facadeBoulanger")
        {

        }
    }
}
