using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tiles
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
    }
}