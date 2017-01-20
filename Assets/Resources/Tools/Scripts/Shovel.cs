using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Tiles {
    class Shovel : MonoBehaviour {

        public void OnUse(SandTile tile)
        {
            if (tile.GetComponentsInChildren<Transform>().Length > 1)
                return;
            else if (tile.GetComponentsInChildren<Transform>().Length == 1)
            {
                if (tile.GetComponentInChildren<Castle>().GetState() < 4)
                    tile.GetComponentInChildren<Castle>().Upgrade();
            }                     
        }


    }
}
