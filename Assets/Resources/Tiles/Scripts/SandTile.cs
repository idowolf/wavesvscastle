using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Tiles {
    class SandTile : MonoBehaviour {
        public float DryTime = 2f;
        private bool isWet;
        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.collider.tag == "Water") {
                isWet = true;
                Invoke("DryUp", DryTime);
            }
        }
        private void DryUp() {
            isWet = false;
        }
    }
}
