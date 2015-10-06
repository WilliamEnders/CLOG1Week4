using UnityEngine;
using System.Collections;

public class talkToMe : MonoBehaviour {

	private string quest;

	void Start(){
		quest = "false";
	}

	void OnTriggerEnter (Collider collisionInfo) {
		if(collisionInfo.gameObject.tag ==  "Player"){
		GetComponent<Renderer> ().enabled = true;
			if(Input.GetKey(KeyCode.E)){
				if(quest == "false"){
					quest = "true";
				}

			}
		}
	}
	void OnTriggerExit (Collider collisionInfo) {
		if(collisionInfo.gameObject.tag ==  "Player"){
		GetComponent<Renderer> ().enabled = false;
		}
	}
}
