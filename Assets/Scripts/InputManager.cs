using UnityEngine;
using System.Collections;
using System;
using Tiles;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour {

    GameObject currentTool;
    Vector3 originalPos;
    public bool NextSceneOnTouch;
    bool dragWithMouse;
    private void Update() {
        if(dragWithMouse)
            currentTool.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);

        // Handle native touch events
        foreach (Touch touch in Input.touches) {
            switch (touch.phase) {
                case TouchPhase.Began:
                    Debug.Log("aaa");

                    DetectTouch(touch.position, false);
                    break;
                case TouchPhase.Ended:
                    Debug.Log("bbb");
                    dragWithMouse = false;
                    if (currentTool)
                        currentTool.transform.position = originalPos;
                    DetectTouch(touch.position, true);
                    break;
                case TouchPhase.Canceled:
                    Debug.Log("ccc");
                    dragWithMouse = false;
                    if (currentTool)
                        currentTool.transform.position = originalPos;
                    DetectTouch(touch.position, true);
                    break;
                default:
                    break;
            }
        }

        // Simulate touch events from mouse events
        if (Input.touchCount == 0) {
            var position = Input.mousePosition;
            if (Input.GetMouseButtonUp(0)) {
                dragWithMouse = false;
                if(currentTool)
                    currentTool.transform.position = originalPos;
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
        if (isDrop && NextSceneOnTouch) {
            //UGLY hack for welcome screen, no time left :-(
            if (col.name == "OffButton") {
                Application.Quit();
            }
            else {
                SceneManager.LoadScene(1);
            }
        }

        if (col) {
            print((isDrop ? "Dropping on " : "Dragging from ") + col.name);
            if (!isDrop && col.gameObject.tag == "Mute")
                col.gameObject.GetComponent<SoundMenu>().Mute();
            if (!isDrop && col.gameObject.tag == "Off")
                col.gameObject.GetComponent<OffButton>().GoToMenu();
            if (!isDrop && col.gameObject.tag == "Tool" && currentTool == null) {
                {
                    // change current tool
                    currentTool = col.gameObject;
                    originalPos = currentTool.transform.position;
                    dragWithMouse = true;
                    currentTool.GetComponent<Tool>().Click();
                }
            }
            if (isDrop && currentTool != null) {
                currentTool.transform.position = originalPos;
                SandTile tile = col.gameObject.GetComponentInParent<SandTile>();
                Crabs crab = col.gameObject.GetComponent<Crabs>();
                Debug.Log(currentTool.GetComponent<Tool>().ToolName());
                if ((currentTool.GetComponent<Tool>().ToolName() == "Net") && crab != null)
                {
                    Debug.Log(crab.gameObject.name);
                    currentTool.GetComponent<Tool>().WorkOnTile(crab);

                }
                if (tile && (currentTool.GetComponent<Tool>().ToolName() != "Net")) {
                    {
                        // activate tool on tile
                        print(tile.gameObject.name);
                        currentTool.GetComponent<Tool>().WorkOnTile(tile);
                    }
                }
                currentTool = null;
            }
        }
    }

}
