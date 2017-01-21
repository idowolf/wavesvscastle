using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    public class MoveWithFinger : MonoBehaviour
    {
        Vector3 initPos;
        // Use this for initialization
        void Start()
        {
            initPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (isMouseAroundMe()) { 
                Vector3 v = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,-2);
                transform.position = v;
                }
            }
            else
                transform.position = initPos;
        }

        public bool isMouseAroundMe()
        {
            float horizontalBuffer = 1f;
            float verticalBuffer = 1f;
            Vector3 v = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,-2);
            if (Mathf.Abs(v.x - transform.position.x) < horizontalBuffer && Mathf.Abs(v.y - transform.position.y) < verticalBuffer)
                return true;
            return false;
        }
    }
}