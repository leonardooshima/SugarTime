using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MusicClass.Instance.gameObject.GetComponent<AudioSource>().Stop();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
