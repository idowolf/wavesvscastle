using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tiles
{
    
    public class Wave : MonoBehaviour
    {
        public GameObject Splash;
        public GameObject Shell;
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
                GameObject.Instantiate(Splash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity); //new Quaternion(-179.996f, -0.302002f, -89.81598f, 0));
                Destroy(gameObject);
            }
            else if(other.gameObject.tag == "SandTile")
                if(other.gameObject.transform.FindChild("Shell")==null)
                    if(Random.Range(1,100)<10)
                        GameObject.Instantiate(Shell, other.gameObject.transform.localPosition, Quaternion.identity,other.gameObject.transform);

        }
        
    }
}