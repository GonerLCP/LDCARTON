using UnityEngine;
using System.Collections;

public class soundManager : MonoBehaviour {

	public static soundManager instance;

	public AudioSource[] sourcesbruitage;
	public AudioSource sourceMusique;
	
	public float lowPitchRange = 0.85f;
	public float hightPitchRange = 1.15f;


	void Awake(){
		instance = this;
	}
	// Use this for initialization
	void Start () {
		sourcesbruitage = this.gameObject.transform.Find ("sourcesSons").GetComponentsInChildren<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//musique
	public void ChangeMusique(AudioClip Clip){
		sourceMusique.clip = Clip;
		sourceMusique.Play ();
	}

	public void stopMusique (){
		sourceMusique.Stop ();
	}

	public void changeVolumeMusique (float volume){
		sourceMusique.volume = volume;
	}



	//bruitages
	public void PlaySingleSound (AudioClip Clip, int sourceNum = 0, bool changePitch=true, float volume=1){
		if (sourceNum > sourcesbruitage.Length) {
			sourceNum = sourcesbruitage.Length;
		}
		if (changePitch) {
			float randomPitch = Random.Range (lowPitchRange, hightPitchRange);
			sourcesbruitage [sourceNum].pitch = randomPitch;
		} else {
			sourcesbruitage [sourceNum].pitch = 1;
		}
		sourcesbruitage[sourceNum].clip = Clip;
		sourcesbruitage[sourceNum].volume = volume;
		sourcesbruitage[sourceNum].Play ();
	}
	
	public void RandomizeSound ( AudioClip [] Clips, int sourceNum = 0, bool changePitch=true, float volume=1 ) {
			if (sourceNum > sourcesbruitage.Length) sourceNum = sourcesbruitage.Length;
		int randomIndex = Random.Range (0, Clips.Length);
		if (changePitch) {
			float randomPitch = Random.Range (lowPitchRange, hightPitchRange);
			sourcesbruitage [sourceNum].pitch = randomPitch;
		} else {
			sourcesbruitage [sourceNum].pitch = 1;
		}
        if (Clips[randomIndex] != null)
        {
            sourcesbruitage[sourceNum].clip = Clips[randomIndex];
            sourcesbruitage[sourceNum].volume = volume;
            sourcesbruitage[sourceNum].Play();
        }
		
	}

	public void stopSound (int sourceNum = 0){
		sourcesbruitage[sourceNum].Stop ();
	}


}
