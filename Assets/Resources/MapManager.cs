using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
    //public float heightMargin = 0.1f, widthMargin = 0.1f; // Magic numbers, set in editor for best optimization
    // Use this for initialization

    private const int LANES = 5;
    private const int WATER_ROWS = 1;
    private const int SAND_ROWS = 5;
    private const int CASTLE_ROWS = 2;
    private const int TOOLBAR = 1;
    private const float tilesize = 2.239f;
    public GameObject WaterTile;
    public GameObject SandTile;
    public GameObject CastleTile;

    void Start()
    {
        //Create WaterTiles
        int currentrow = 0;
        int rowcounter = 0;
        for (;rowcounter<WATER_ROWS ; rowcounter++)
        {
            for (int j = 0; j < LANES; j++)
            {
                GameObject.Instantiate(WaterTile, new Vector3( j * tilesize, tilesize * rowcounter), Quaternion.identity);
            }
        }
        currentrow = rowcounter;
        for(;rowcounter<SAND_ROWS+currentrow;rowcounter++)
        {
            for (int j = 0; j < LANES; j++)
            {
                GameObject.Instantiate(SandTile, new Vector3(j * tilesize, tilesize * rowcounter), Quaternion.identity);
            }
        }
        currentrow = rowcounter;
        for (; rowcounter < CASTLE_ROWS + currentrow; rowcounter++)
        {
            for (int j = 0; j < LANES; j++)
            {
                GameObject.Instantiate(CastleTile, new Vector3(j * tilesize,tilesize * rowcounter), Quaternion.identity);
            }
        }
    }

        // Update is called once per frame
        void Update () {
		
	}
}
