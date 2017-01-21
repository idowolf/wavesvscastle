using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSplash : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // this is a temp object, it should be destroyed after a short time
        Invoke("KillMe", 2);
	}

    void KillMe() {
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
