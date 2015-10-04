using UnityEngine;
using System.Collections;

public class footStepSound : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void playSound () {
			GetComponent<AudioSource>().Play();
	
	}
}
