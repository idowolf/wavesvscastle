using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Castle
{

    public class Wave : MonoBehaviour
    {

        void Start()
        {

        }
        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Castle")
            {
                other.gameObject.GetComponent<Castle>().Downgrade();
                Destroy(gameObject);
            }
        }
        void OnDestroy()
        {
            GameObject.Instantiate(Resources.Load("Prefab/WaveSplash"), new Vector3(transform.position.x, transform.position.y, 0),new Quaternion(-179.996f, -0.302002f, -89.81598f, 0));
        }
    }
}