using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour, ICollectable
{
    public int points=10;

    public void Collect()
    {
        ScoreManager.Instance.scoreCount=ScoreManager.Instance.scoreCount+points;
        Destroy();
    }
    public void Destroy()
    {
        
        Destroy(gameObject);
    }
}
