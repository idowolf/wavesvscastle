﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToMenu()
    {
        print("tada");
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);

    }
}
