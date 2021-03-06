﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tiles
{

    public class LinearMovement : MonoBehaviour
    {
        private Rigidbody2D r2d;
        public float degree;
        public bool moveToCenter;
        public float speed;
        private Vector3 oldVelocity;
        float leftConstraint = Screen.width;
        float rightConstraint = Screen.width;
        float bottomConstraint = Screen.height;
        float topConstraint = Screen.height;
        float buffer = 2.0f;
        Camera cam;
        float distanceZ;

        // Use this for initialization
        void Start()
        {
            r2d = GetComponent<Rigidbody2D>();
            Vector3 dest = new Vector3(Mathf.Cos(degree), Mathf.Sin(degree), 0f);
            Vector3 dif = dest - transform.position.normalized;
            if (moveToCenter)
            {
                degree = Mathf.Atan(transform.position.y / transform.position.x) * Mathf.Rad2Deg + 90 + (transform.position.x < 0 ? 180 : 0);
                transform.rotation = Quaternion.Euler(0f, 0f, degree);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 360 - degree);
            }
            r2d.AddForce(transform.up * speed * Time.deltaTime, ForceMode2D.Impulse);

            cam = Camera.main;
            distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);

            leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
            rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
            bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
            topConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y;

        }




        // Update is called once per frame
        void Update()
        {
            oldVelocity = r2d.velocity;
            if (transform.position.x < leftConstraint - buffer)
            {
                Destroy(gameObject);
            }
            if (transform.position.x > rightConstraint + buffer)
            {
                Destroy(gameObject);
            }
            if (transform.position.y < bottomConstraint - buffer)
            {
                Destroy(gameObject);
            }
            if (transform.position.y > topConstraint - buffer)
            {
                Destroy(gameObject);
            }
        }
    }
}