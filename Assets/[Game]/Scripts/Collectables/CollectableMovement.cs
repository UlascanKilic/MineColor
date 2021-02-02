using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMovement : MonoBehaviour
{

    public float colForward = 6f;
    public float colSpeed = 0.01f;

    private float maxSpeed = 15f;


    public bool collectableMove = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!collectableMove)
        {
            transform.Translate(Vector3.back * Time.deltaTime * colForward);

            if (colForward <= maxSpeed)
            {
                colForward += 0.002f;
            }
        }
    }
}