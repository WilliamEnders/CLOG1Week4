using UnityEngine;
using System.Collections;

public class movePlayer : MonoBehaviour {
	private float speed;
	private GameObject bodymove;
	private GameObject body;
	private GameObject sword;
	private Animator swordanim;
	private Animator bodyanim;
	private Vector3 stayPos;
	// Use this for initialization
	void Start () {
		bodymove = GameObject.Find ("bodyshell");
		body = GameObject.Find ("character");
		sword = GameObject.Find ("swordshell");
		speed = 1f;
		bodyanim = body.GetComponent<Animator>();
		swordanim = sword.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		transform.rotation = new Quaternion (0,0,0,0);
		if (bodyanim.GetCurrentAnimatorStateInfo (0).IsName ("cut") == false) {
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D)) {
				
				bodyanim.Play ("walk 1");
			} else {
				bodyanim.Play ("idle");
			}
			if (Input.GetKey (KeyCode.A)) {
				transform.position -= Vector3.right * speed * Time.deltaTime;
				bodymove.transform.rotation = new Quaternion (0, 180, 0, 0);
			}
			if (Input.GetKey (KeyCode.D)) {
				transform.position += Vector3.right * speed * Time.deltaTime;
				bodymove.transform.rotation = new Quaternion (0, 0, 0, 0);
			}
			if (Input.GetKey (KeyCode.W)) {
				transform.position += Vector3.forward * speed * Time.deltaTime;
			}
			if (Input.GetKey (KeyCode.S)) {
				transform.position -= Vector3.forward * speed * Time.deltaTime;
			}
			if (Input.GetKey (KeyCode.Space)) {
				stayPos = transform.position;
				swordanim.SetTrigger ("playSwingDown");
				bodyanim.Play ("cut");
			}
		} else {
			transform.position = stayPos;
		}
	}
}
