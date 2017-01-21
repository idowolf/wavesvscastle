using System;
using System.Collections;
using System.Collections.Generic;
using Tiles;
using UnityEngine;

namespace Tiles
{
    class Bucket : MonoBehaviour, Tool
    {

        public Sprite fullbucket;
        public Sprite emptybucket;
        public GameObject Castle;
        public void WorkOnTile(SandTile tile)
        {
            if (tile.transform.childCount == 0)
            {
                var cas = GameObject.Instantiate(Castle, tile.transform.localPosition, Quaternion.identity, tile.transform);
                cas.tag = "Castle";
                cas.GetComponent<Castle>().SetBase();
                print(cas.GetComponent<Castle>().GetState());
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}