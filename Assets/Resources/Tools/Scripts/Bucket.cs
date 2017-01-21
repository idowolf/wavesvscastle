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
        private bool IsEmpty = false;
        public float spawntimer;
        private Collider2D col;
        void Start()
        {
            col = GetComponent<Collider2D>();
        }
        public void WorkOnTile(SandTile tile)
        {
            if (tile.transform.childCount == 0 && !tile.IsWet)
            {
                var cas = GameObject.Instantiate(Castle, tile.transform.localPosition, Quaternion.identity, tile.transform);
                cas.tag = "Castle";
                cas.GetComponent<Castle>().SetBase();
                col.enabled = false;
                GetComponent<SpriteRenderer>().sprite = emptybucket;
                StartCoroutine(FillBucket());
            }
        }
        private IEnumerator FillBucket()
        {

            yield return new WaitForSeconds(spawntimer);
            GetComponent<SpriteRenderer>().sprite = fullbucket;
            col.enabled = true;


        }
        public String ToolName()
        {
            return "Bucket";
             }
        public void WorkOnTile(Crabs crab)
        {

        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}