using UnityEngine;
using System.Collections;
using System;
using Tiles;

public class InputManager : MonoBehaviour {

    Tool currentTool;

    private void Update() {
        // Handle native touch events
        foreach (Touch touch in Input.touches) {
            switch (touch.phase) {
                case TouchPhase.Began:
                    DetectTouch(touch.position, false);
                    break;
                case TouchPhase.Ended:
                    DetectTouch(touch.position, true);
                    break;
                case TouchPhase.Canceled:
                    currentTool = null;
                    break;
                default:
                    break;
            }
        }

        // Simulate touch events from mouse events
        if (Input.touchCount == 0) {
            var position = Input.mousePosition;
            if (Input.GetMouseButtonUp(0)) {
                DetectTouch(position, true);
            }
            if (Input.GetMouseButtonDown(0)) {
                DetectTouch(position, false);
            }

        }
    }

    void DetectTouch(Vector3 touchPosition, bool isDrop) {
        var position = Camera.main.ScreenToWorldPoint(touchPosition);
        var col = Physics2D.OverlapPoint(position);
        if (col) {
            print((isDrop ? "Dropping on " : "Dragging from ") + col.name);
            if(!isDrop && col.gameObject.tag == "Tool") {
                // change current tool
                currentTool = col.gameObject.GetComponent<Tool>();
            }
            if (isDrop && currentTool != null) {
                SandTile tile = col.gameObject.GetComponentInParent<SandTile>();
                Crabs crab = col.gameObject.GetComponentInParent<Crabs>();
                if ((currentTool.ToolName() == "Net") && crab != null)
                    currentTool.WorkOnTile(crab);
                if (tile && (currentTool.ToolName() != "Net")) {
                    // activate tool on tile
                    currentTool.WorkOnTile(tile);
                }
                currentTool = null;
            }
        }
    }

}
