using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Collectibles;
    public GameObject[] Obstacles;
    

    private GameObject decidedObject;

    public int spawnWait;
    public bool stop;
    public int lane;
    private int randomNumber;
    private int indexNumber;
    private float xValue;
    public float offset;
    private int forValue;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    IEnumerator waitSpawner()
    {       
        while (true)
        {
            lane = Random.Range(1, 4);
            //randomNumber = Random.Range(0, 100);

            if (Random.value > 0.1 && Random.value < 0.39)
            {
                forValue = 5;
                indexNumber = Random.Range(0, Collectibles.Length);
                
                decidedObject = Collectibles[indexNumber];
            }
            else if (Random.value > 0.4 && Random.value <1)
            {
                forValue = 1;
                indexNumber = Random.Range(0, Obstacles.Length);
                
                decidedObject = Obstacles[indexNumber];
            }
            switch (lane)
            {
                case 1:
                    xValue = -2.5f;
                    break;
                case 2:
                    xValue = 0;
                    break;
                case 3:
                    xValue = 2.5f;
                    break;
            }

            Vector3 spawnPosition;
            
            if(decidedObject.name == "FlatRock-A11")
            {
                 spawnPosition = new Vector3((0 + xValue), 0.6f, (0 + offset));
            }
            if(decidedObject.name == "Crate-A01")
            {
                spawnPosition = new Vector3((0 + xValue), 1.2f, (0 + offset));
            }
            if(decidedObject.name == "RailStopper-01")
            {
                spawnPosition = new Vector3((0 + xValue), 1f, (0 + offset));
            }
            if(decidedObject.name == "MineCarts")
            {
                spawnPosition = new Vector3(-0.4f, -7.2f, (15 + offset));
            }
            else
            {
                spawnPosition = new Vector3((0 + xValue), 1f, (0 + offset));
            }

            for (int i = 0; i < forValue; i++)
            {
                Instantiate(decidedObject, spawnPosition, gameObject.transform.rotation);
                yield return new WaitForSeconds(0.3f);
            }         

            yield return new WaitForSeconds(spawnWait);
        }

    }


}