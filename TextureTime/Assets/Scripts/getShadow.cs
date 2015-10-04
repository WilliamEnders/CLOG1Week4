using UnityEngine;
using System.Collections;

public class getShadow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
	}
}
