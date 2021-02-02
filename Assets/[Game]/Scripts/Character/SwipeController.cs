using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    MineCartMovement MineCart;
  
    private Vector3 startPos;
    private bool fingerDown;
    public int pixelsDistToDetect = 20;

    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(fingerDown==false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            fingerDown = true;
        }
        if (fingerDown)
        {
            //Swipe Up
            if (Input.touches[0].position.y >= startPos.y + pixelsDistToDetect)
            {
                if (MineCart.controller.isGrounded)
                {
                if (MineCart.controller.isGrounded)
                    MineCart.verticalVelocity = -MineCart.gravity * Time.deltaTime;
                    MineCart.verticalVelocity = MineCart.jumpForce;
                    CameraEffects.ShakeOnce();
                }
            }
            //Swipe Left      
            if (Input.touches[0].position.x < startPos.x - pixelsDistToDetect)
            {
                fingerDown = false;
                MineCart.MoveLane(false);
                Debug.Log("Swipe Left");
                
            }
            //Swipe Right
            else if (Input.touches[0].position.x >= startPos.x + pixelsDistToDetect)
            {
                fingerDown = false;
                MineCart.MoveLane(true);
                Debug.Log("Swipe Right");
            }
        }
        if(fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            fingerDown = false;
        }
    }
}
