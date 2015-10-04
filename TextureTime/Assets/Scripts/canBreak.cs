using UnityEngine;
using System.Collections;

public class canBreak : MonoBehaviour {
	
	private GameObject sword;
	private Animator swordanim;
	public float objSize;
	private GameObject character;
	private GameObject maincam;
	private GameObject colObj;
	public GameObject mailexplosion;
	public GameObject hydrantexplosion;
	private float swordsize;
	public bool broken;
	
	void Start(){
		broken = false;
		sword = GameObject.Find ("swordshell");
		swordanim = sword.GetComponent<Animator>();
		maincam = GameObject.Find ("Main Camera");
		character = GameObject.Find ("playershell");
	}
	
	void OnTriggerEnter(Collider collisionInfo){
		swordsize = character.GetComponent<swordTouch> ().swordSize;
		colObj = collisionInfo.gameObject;
		if (colObj.tag == "Sword" && swordanim.GetCurrentAnimatorStateInfo (0).IsName ("SwingDown") && swordsize >= objSize && !broken) {
			character.GetComponent<swordTouch> ().swordSize += 0.05f;
			transform.GetChild(0).gameObject.AddComponent<Rigidbody>();
			transform.GetChild(1).gameObject.AddComponent<Rigidbody>();
			transform.GetChild(0).GetComponent<Rigidbody>().AddForce((Random.insideUnitSphere) + Vector3.forward * 200 * swordsize);
			transform.GetChild(1).GetComponent<Rigidbody>().AddForce((Random.insideUnitSphere) - Vector3.forward * 200 * swordsize);
			GetComponent<BoxCollider>().enabled = false;
			maincam.GetComponent<screenShaker>().startShake = true;
			sword.GetComponent<AudioSource>().Play();
			broken = true;
			
			if(name == "Mailbox"){
				Instantiate( mailexplosion, transform.position, transform.rotation);
			}
			if(name == "Hydrant"){
				Instantiate( hydrantexplosion, transform.position, new Quaternion(0,-90,-90,0));
			}
		}
	}
}
