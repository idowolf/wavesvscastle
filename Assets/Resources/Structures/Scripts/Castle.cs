using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Tiles {
    class Castle : MonoBehaviour {

        public Sprite[] spritestates = new Sprite[5];
        private int state = 4;

        public void Start()
        {
        }
        public void Upgrade()
        {
            print("state: " + state);
            this.state++;
            gameObject.GetComponent<SpriteRenderer>().sprite = spritestates[this.state];
        }
        public void Downgrade()
        {
            this.state--;
            gameObject.GetComponent<SpriteRenderer>().sprite = spritestates[this.state];
        }
        public void SetBase()
        {
            this.state = 0;
            gameObject.GetComponent<SpriteRenderer>().sprite = spritestates[this.state];
        }
        public int GetState()
        {
            return this.state;
        }
    }
}
