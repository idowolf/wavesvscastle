using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Tiles {
    class SandTile : MonoBehaviour {
        SpriteRenderer sprite;

        public float DryTime = 8f;
        public float WetTime = 1f;
        private Color WetColor = new Color(0.7f, 0.7f, 0.7f);
        private Color DryColor = new Color(1, 1, 1);
        public bool IsWet { get; private set; }

        
        private void Start() {
            sprite = GetComponent<SpriteRenderer>();
            
        }

        void OnTriggerEnter2D(Collider2D collider) {
            if (collider.gameObject.tag == "Water") {
                Invoke("WetMe", WetTime);
                Invoke("DryUp", DryTime);
            }
        }
        private void WetMe() {
            IsWet = true;
            sprite.color = WetColor;
        }
        private void DryUp() {
            IsWet = false;
            sprite.color = DryColor;

        }


    }
}
