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
        void Update()
        {
            if (transform.position.y > 16.8f)
            {
                GetComponentInChildren<Animator>().SetBool("killcastle", false);
                GetComponent<Rigidbody2D>().AddForce(transform.up * (-1) * GetComponent<LinearMovement>().speed * 0.5f * Time.deltaTime, ForceMode2D.Impulse);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponentInChildren<Castle>())
                StartCoroutine(DestroyCastle(other.GetComponentInChildren<Castle>()));
        }
        IEnumerator DestroyCastle(Castle castle)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponentInChildren<Animator>().SetBool("killcastle", true);
            StartCoroutine(DowngradeTheCastle(castle));
            yield return new WaitForSeconds(3f);
        }

        IEnumerator DowngradeTheCastle(Castle castle)
        {
            if(castle.GetState() >= 0)
                castle.Downgrade();
            else
            {
                GetComponentInChildren<Animator>().SetBool("killcastle", false);
                GetComponent<Rigidbody2D>().AddForce(transform.up * (-1) * GetComponent<LinearMovement>().speed * 0.5f * Time.deltaTime, ForceMode2D.Impulse);
            }
            yield return new WaitForSeconds(2f);
            StartCoroutine(DowngradeTheCastle(castle));
        }
    }

}