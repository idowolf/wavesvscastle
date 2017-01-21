using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    public class MapManager : MonoBehaviour
    {
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
        public GameObject Castle;
        public GameObject Toolbar;



        void Start()
        {
            //Create WaterTiles
            int currentrow = 0;
            int rowcounter = 0;
            for (; rowcounter < WATER_ROWS; rowcounter++)
            {
                for (int j = 0; j < LANES; j++)
                {
                    var tile = GameObject.Instantiate(WaterTile, new Vector3(j * tilesize, tilesize * rowcounter), Quaternion.identity);
                    tile.name = "Water " + rowcounter + " / " + j;
                }
            }
            currentrow = rowcounter;
            for (; rowcounter < SAND_ROWS + currentrow; rowcounter++)
            {
                for (int j = 0; j < LANES; j++)
                {
                    var tile = GameObject.Instantiate(SandTile, new Vector3(j * tilesize, tilesize * rowcounter), Quaternion.identity);
                    tile.name = "Sand " + rowcounter + " / " + j;
                }
            }
            currentrow = rowcounter;
            for (; rowcounter < CASTLE_ROWS + currentrow; rowcounter++)
            {
                for (int j = 0; j < LANES; j++)
                {
                    var tile = GameObject.Instantiate(SandTile, new Vector3(j * tilesize, tilesize * rowcounter), Quaternion.identity);
                    tile.name = "Sand " + rowcounter + " / " + j;
                    var cas = GameObject.Instantiate(Castle, new Vector3(j * tilesize, tilesize * rowcounter), Quaternion.identity, tile.transform);
                    cas.name = "Castle ";
                 

                }
            }
            var toolbar = GameObject.Instantiate(Toolbar, new Vector3(5f, tilesize * rowcounter), Quaternion.identity);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}