using UnityEngine;
using System.Collections;

public class screenShaker : MonoBehaviour {

	public float shakeAmount = 2f;
	public float shakeTime = 1.5f;
	private bool isShaking = false;
	private Vector3 originalLocation;
	public bool startShake = false;


	// Update is called once per frame
	void Update () {
		if(startShake && !isShaking){
			originalLocation = transform.position;
			StartCoroutine("shakeScreen");
		}
		if(isShaking){
			transform.position += Random.insideUnitSphere * shakeAmount * Time.deltaTime;
		}
	}

	IEnumerator shakeScreen(){
		isShaking = true;
		yield return new WaitForSeconds (shakeTime);
		isShaking = false;
		transform.position = originalLocation;
		startShake = false;
	}

}
