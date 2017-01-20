using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Tiles {
    class SandTile : MonoBehaviour {
        private void OnCollisionEnter2D(Collision2D collision) {
            if(collision.collider.tag == "Water") {

            }
        }
    }
}
