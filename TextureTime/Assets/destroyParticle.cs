using UnityEngine;
using System.Collections;

public class destroyParticle : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		Destroy (gameObject, gameObject.GetComponent<ParticleSystem>().duration + 3f);
		Destroy (gameObject.GetComponent<AudioSource> (), gameObject.GetComponent<ParticleSystem> ().duration);
	}
}