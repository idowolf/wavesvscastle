using System.Collections;
using System.Collections.Generic;
using Tiles;
using UnityEngine;

interface Tool {
    void WorkOnTile(SandTile tile);
    void WorkOnTile(Crabs crab);
    string ToolName();
}
