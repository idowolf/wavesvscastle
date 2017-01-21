using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Castle
{

    public class WaveFactoryLogic : MonoBehaviour
    {
        public GameObject wave;
        public float spawnTime;
        // Use this for initialization
        void Start()
        {
            InvokeRepeating("addWave", 0, spawnTime);

        }

        // Update is called once per frame
        void Update()
        {

        }
        void addWave()
        {
            Debug.Log("Fucknimrod2000");
            //set spawn point to be random in the range or at the middle of it 
            Vector2 spawnPoint = new Vector2(2.24f * Random.Range(0, 5), -0.5f);
            //= new Vector2(transform.position.x , Random.Range(y1, y2));
            GameObject wave1 = Instantiate(wave, spawnPoint, Quaternion.identity);
        }

    }
}