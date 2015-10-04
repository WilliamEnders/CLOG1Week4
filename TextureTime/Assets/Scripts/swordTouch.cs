using UnityEngine;
using System.Collections;

public class swordTouch : MonoBehaviour {

	private GameObject sword;
	private GameObject body;
	private GameObject maincam;
	public float swordSize;
	private Animator swordanim;
	private Animator bodyanim;

	void Start(){
		swordSize = 0.3f;
		sword = GameObject.Find ("swordshell");
		body = GameObject.Find ("character");
		swordanim = sword.GetComponent<Animator>();
		bodyanim = body.GetComponent<Animator>();
		maincam = GameObject.Find ("Main Camera");

	}

	void Update(){
		maincam.GetComponent<Camera> ().orthographicSize = 0.6f + (swordSize);
		sword.transform.localScale = new Vector3 (0.4f,swordSize,0.5f);
	}
	
	void OnCollisionEnter(Collision collisionInfo){
		if(swordanim.GetCurrentAnimatorStateInfo (0).IsName ("SwingDown") && collisionInfo.gameObject.tag != "Item"){
			GetComponent<AudioSource>().Play ();
			AnimatorStateInfo currentState = swordanim.GetCurrentAnimatorStateInfo(0);
			float playbackTime = currentState.normalizedTime % 1;
			AnimatorStateInfo currentState2 = bodyanim.GetCurrentAnimatorStateInfo(0);
			float playbackTime2 = currentState2.normalizedTime % 1;
			foreach(ContactPoint contact in collisionInfo.contacts){
				if(contact.thisCollider.name == "sword"){
					swordanim.Play ("SwingUp",0,((1/playbackTime)+0.05f));
					bodyanim.Play ("cut",0,((1-playbackTime2+0.1f)));
				}
			}
		}
	}
}
