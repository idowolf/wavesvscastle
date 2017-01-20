﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Tiles {
    class SandTile : MonoBehaviour {
        SpriteRenderer sprite;

        public float DryTime = 2f;
        private Color WetColor = new Color(0.7f, 0.7f, 0.7f);
        private Color DryColor = new Color(1, 1, 1);
        private bool isWet;

        private void Start() {
            sprite = GetComponent<SpriteRenderer>();
            
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.collider.tag == "Water") {
                isWet = true;
                sprite.color = WetColor;
                Invoke("DryUp", DryTime);
            }
        }
        private void DryUp() {
            isWet = false;
            sprite.color = DryColor;

        }


    }
}