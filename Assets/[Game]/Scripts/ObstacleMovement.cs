using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    public float forwardForce = 2f;
    public float speed = 1f;

    public bool isGameOver=false;
    private float maxSpeed = 15f;

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {        
            transform.Translate(Vector3.right * Time.deltaTime * forwardForce );

            if(forwardForce <= maxSpeed)
            {
                forwardForce += 0.001f;
            }

        }
        else
        {
            Debug.Log("ScoreUI");
        }
    }
}
