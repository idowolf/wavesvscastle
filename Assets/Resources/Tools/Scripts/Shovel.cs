using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Tiles {
    class Shovel : MonoBehaviour, Tool {

        public void WorkOnTile(SandTile tile) {
            if (tile.transform.childCount == 0)
                return;
            else {
                var castle = tile.transform.GetChild(0);
                var castleComponent = castle.GetComponent<Castle>();
                if (castleComponent.GetState() < 4) {
                    castleComponent.Upgrade();
                }
            }
        }


    }
}
