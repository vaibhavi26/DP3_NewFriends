using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour {
	public PlayableDirector playableDirector;

	// Use this for initialization

	public void animPlay () {
		playableDirector.Play ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
