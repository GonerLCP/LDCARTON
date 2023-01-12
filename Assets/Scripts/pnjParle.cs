using UnityEngine;
using System.Collections;

public class pnjParle : MonoBehaviour {

	private GameObject feedBackSelected;

	public string[] dialogues;
	private int dialogueNum = 0;

	private bool textActivated = false;
	private GameObject bulleTexte;
	private TextMesh texte;

	private int nbreCorroutinesPersoParti = 0;

    private Camera cam;

	// Use this for initialization
	void Start () {
		feedBackSelected = transform.Find("persoSelected").gameObject;
		feedBackSelected.SetActive (false);

		bulleTexte = transform.Find ("fondTexte").gameObject;
		texte = bulleTexte.transform.GetComponentInChildren<TextMesh> ();

        cam = Camera.main;

        endParle ();
	}
	
	// Update is called once per frame
	void Update () {
	    if (dialogueNum != -1)
        {
            //float rotY = Quaternion.FromToRotation(bulleTexte.transform.position, cam.transform.position).eulerAngles.y;
            //bulleTexte.transform.localRotation = Quaternion.Euler(bulleTexte.transform.localRotation.x, rotY, bulleTexte.transform.localRotation.z);
            bulleTexte.transform.localRotation = Quaternion.LookRotation(new Vector3( cam.transform.position.x - bulleTexte.transform.position.x, 0, cam.transform.position.z - bulleTexte.transform.position.z), Vector3.zero);
        }
    }

	public void pnjSelected(){
		feedBackSelected.SetActive (true);
	}
	public void pnjUnSelected(){
		feedBackSelected.SetActive (false);
		if (textActivated) {
			StartCoroutine (persoPartiTimer ());
		}
	}

	public void parle(){
		if (dialogueNum == -1) {
			startParle ();
		} else if (dialogueNum >= dialogues.Length-1) {
			endParle ();
		} else {
			nextText ();
		}
	}

	private void startParle(){
		textActivated = true;
		dialogueNum = 0;
		bulleTexte.SetActive (true);
		texte.gameObject.SetActive (true);
		if (dialogues.Length != 0) texte.text = dialogues[0];
	}
	private void nextText(){
		dialogueNum += 1;
		texte.text = dialogues[dialogueNum];
	}
	private void endParle(){
		bulleTexte.SetActive (false);
		texte.gameObject.SetActive (false);
		dialogueNum = -1;
		textActivated = false;
	}


	public void persoParti(){
		endParle ();
	}
	IEnumerator persoPartiTimer(){
		nbreCorroutinesPersoParti += 1;
		yield return new WaitForSeconds (3);
		if (!feedBackSelected.activeInHierarchy && nbreCorroutinesPersoParti <= 1 ){ //si le perso n'est pas revenu entre temps
			persoParti();
		}
		nbreCorroutinesPersoParti-=1;
	}
}
