using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGrassFactory : MonoBehaviour {
    public float heightMargin = 0.35f, widthMargin = 0.35f; // Magic numbers, set in editor for best optimization
                                                            // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                GameObject.Instantiate(Resources.Load("GrassPrefab"), new Vector3(-1.433f + j * widthMargin, 0.84f - heightMargin * i), Quaternion.identity);
            }
        }
    }

        // Update is called once per frame
        void Update () {
		
	}
}
