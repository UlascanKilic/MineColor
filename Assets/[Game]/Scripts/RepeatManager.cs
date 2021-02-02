using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatManager : MonoBehaviour
{
    private Vector3 respawnPos;
    private void Start()
    {
        respawnPos = new Vector3(-17.48652f, 4.518722f, 158.5f);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,-15f);
    }
    

   


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroyer")
        {
            Debug.Log("degdi");
            gameObject.transform.position = respawnPos;
        }
        
    }
}
