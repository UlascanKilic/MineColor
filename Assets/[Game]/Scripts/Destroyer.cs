using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    GameObject Object;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.tag == "LeftRails")
        {
            Object = other.gameObject;
            Object.transform.position = new Vector3(Object.transform.position.x, Object.transform.position.y, Object.transform.position.z + 205f);
        }
        else if (other.gameObject.tag == "CenterRails")
        {
            Object = other.gameObject;
            Object.transform.position = new Vector3(Object.transform.position.x, Object.transform.position.y, Object.transform.position.z + 205f);          
        }
        else if (other.gameObject.tag == "RightRails")
        {
            Object = other.gameObject;
            Object.transform.position = new Vector3(Object.transform.position.x, Object.transform.position.y, Object.transform.position.z + 205f);        
        }
        else if (other.gameObject.tag == "Mountain")
        {        
            Object = other.gameObject;
            Object.transform.position = new Vector3(Object.transform.position.x, Object.transform.position.y, Object.transform.position.z + 340f);           
        }
        else if (other.gameObject.tag == "Water")
        {        
            Object = other.gameObject;
            Object.transform.position = new Vector3(Object.transform.position.x, Object.transform.position.y, Object.transform.position.z + 325f);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
