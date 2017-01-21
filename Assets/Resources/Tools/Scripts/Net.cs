using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Tiles
{
    class Net : MonoBehaviour, Tool
    {
        public void WorkOnTile(SandTile sand)
        {

        }
        public void WorkOnTile(Crabs crab)
        {
            Destroy(crab);
        }
    public String ToolName()
    {
        return "Net";
    }


    }
}