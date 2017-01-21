using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenu : MonoBehaviour {

    public Sprite[] button = new Sprite[2];
    bool mute = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Mute()
    {
        if (!mute)
        {
            AudioListener.pause = true;
            GetComponent<SpriteRenderer>().sprite = button[1];
            mute = true;
        }
        else
        {
            AudioListener.pause = false;
            GetComponent<SpriteRenderer>().sprite = button[0];
            mute = false;
        }
    }
}
