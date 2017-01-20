﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Castle {
    class Castle : MonoBehaviour {

        public Sprite[] spritestates = new Sprite[5];
        private int state = 0;

        public Castle()
        {
            this.state = 1;
        }
        public void Upgrade()
        {
            this.state++;
            gameObject.GetComponent<SpriteRenderer>().sprite = spritestates[this.state];
        }
        public void Downgrade()
        {
            this.state--;
            gameObject.GetComponent<SpriteRenderer>().sprite = spritestates[this.state];
        }
    }
}