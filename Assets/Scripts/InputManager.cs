using UnityEngine;
using System.Collections;
using System;

public class InputManager : MonoBehaviour {

    GameObject currentTool;
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
        Debug.Log("Mouse Position: " + touchPosition.ToString());
        var position = Camera.main.ScreenToWorldPoint(touchPosition);
        var col = Physics2D.OverlapPoint(position);
        print(col.name);
    }
  
}
