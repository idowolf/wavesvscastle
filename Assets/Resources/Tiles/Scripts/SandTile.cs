using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Tiles {
    class SandTile : MonoBehaviour {
        SpriteRenderer sprite;
        public Sprite[] sprites;
        public float DryTime;
        public float WetTime;
        private float dryValue = 1;
        private float wetValue = 0.7f;
        //private Color WetColor = new Color(0.7f, 0.7f, 0.7f);
        //private Color DryColor = new Color(1, 1, 1);
        public bool IsWet { get; private set; }

        
        private void Start() {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sprite = sprites[UnityEngine.Random.Range(0,2) == 1 ? (int)(UnityEngine.Random.Range(1f, sprites.Length)) : 0];
        }

        void OnTriggerEnter2D(Collider2D collider) {
            if (collider.gameObject.tag == "Water") {
                Invoke("WetMe", WetTime);
            }
        }
        private void WetMe() {
            IsWet = true;
            sprite.color = new Color(wetValue, wetValue,wetValue);
            t = 0;
        }
        float t = 0;
        private void Update() {
            if (IsWet) {
                float val = Mathf.Lerp(wetValue, dryValue, t);
                sprite.color = new Color(val, val, val);
                t += Time.deltaTime / DryTime;
                if(t >= dryValue) {
                    t = 0;
                    IsWet = false;
                }
            }
        }
      
    }
}
