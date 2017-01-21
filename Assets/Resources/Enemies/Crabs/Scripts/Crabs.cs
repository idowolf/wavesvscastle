using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tiles
{


    public class Crabs : MonoBehaviour {
        public float topBorder = 12f;
        // Use this for initialization
        void Start() {
            //degree = Mathf.Atan(transform.position.y / transform.position.x) * Mathf.Rad2Deg + 90 + (transform.position.x < 0 ? 180 : 0);
            //transform.rotation = Quaternion.Euler(0f, 0f, degree);
        }

        // Update is called once per frame
        void Update() {
            if (transform.position.y > topBorder)
            {
                StartCoroutine(ChangeAnimationMode());
            }
        }

        IEnumerator ChangeAnimationMode()
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponentInChildren<Animator>().SetBool("killcastle", true);
            yield return new WaitForSeconds(2f);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.GetComponent<Castle>())
                StartCoroutine(DestroyCastle(other.GetComponent<Castle>()));
        }
        IEnumerator DestroyCastle(Castle castle)
        {
            castle.Downgrade();
            yield return new WaitForSeconds(2f);
            if(castle)
                StartCoroutine(DestroyCastle(castle));
            else
            {
                Debug.Log("test");
                GetComponentInChildren<Animator>().SetBool("killcastle", false);
                GetComponent<Rigidbody2D>().AddForce(transform.up * (-1) * GetComponent<LinearMovement>().speed * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
    }

}