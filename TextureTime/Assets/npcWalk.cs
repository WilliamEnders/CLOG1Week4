using UnityEngine;
using System.Collections;

public class npcWalk : MonoBehaviour {
	private bool isWalking;
	private Vector3 newPos;
	private bool calcnew;
	private bool once;
	// Use this for initialization
	void Start () {
		once = true;
		calcnew = true;
		isWalking = false;
		newPos = new Vector3(Random.Range(-5f, 5f), 0, transform.position.z);
	
	}
	void getNewPos(){
		newPos = new Vector3(Random.Range(-5.0f, 5.0f), 0, transform.position.z);
		calcnew = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<canBreak> ().broken == false) {
			if (transform.position.x <= newPos.x - 0.01f || transform.position.x >= newPos.x + 0.01f) {
				isWalking = true;
				transform.position = Vector3.MoveTowards (transform.position, newPos, 0.01f);
			} else {
				isWalking = false;
			}

			if (isWalking) {
				transform.GetChild (1).GetComponent<Animator> ().Play ("bottomwalk");

			} else {
				if (calcnew) {
					transform.GetChild (1).GetComponent<Animator> ().Play ("bottomidle");
					Invoke ("getNewPos", Random.Range (2f, 10f));
					calcnew = false;
				}
			}

			if (newPos.x > transform.position.x) {
				transform.rotation = new Quaternion (0, 0, 0, 0);
			} else {
				transform.rotation = new Quaternion (0, 180, 0, 0);
			}
		} else {
			if(once){
			transform.GetChild(1).GetComponent<Animator> ().Play ("bottomidle");
			GetComponent<AudioSource>().Play ();
				once=false;
			}
		}
	}
}
