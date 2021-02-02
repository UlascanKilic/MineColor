using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : Singleton<CollectableManager>
{
    public List<GameObject> Crystals;
    private GameObject activeCrystal;
    public List<Transform> Lanes;
    private Transform activeLane;
    private bool SpawnCollectable = false;

    private void Start()
    {
        StartCoroutine(CreateCollectables());
    }
    IEnumerator CreateCollectables()
    {
        while(!SpawnCollectable)
        {
            RandomCollectable();
            GetRandomLane();
            for (int i = 0; i < 5; i++)
            {
                Instantiate(activeCrystal, activeLane.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.3f);
            }           
            yield return new WaitForSeconds(5);
        }
    }
    void RandomCollectable()
    {
        activeCrystal = Crystals[Random.Range(0, Crystals.Count - 1)];
    }
    public void GetRandomLane()
    {
       activeLane  = Lanes[Random.Range(0, Lanes.Count-1)];
    }

}