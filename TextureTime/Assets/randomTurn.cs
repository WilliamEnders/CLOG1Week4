using UnityEngine;
using System.Collections;

public class randomTurn : MonoBehaviour {

	private bool newTurn;

	void Start(){
		newTurn = true;
	}

	// Use this for initialization
	void turn () {
		if (transform.rotation == new Quaternion (0, 0, 0, 1)) {
			transform.rotation = new Quaternion (0, 180, 0, 0);
			newTurn = true;
		} else {
			transform.rotation = new Quaternion (0, 0, 0, 0);
			newTurn = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(newTurn){
		Invoke ("turn", Random.Range (5f, 10f));
		newTurn = false;
		}
	}
}
