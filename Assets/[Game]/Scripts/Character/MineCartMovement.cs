using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineCartMovement : MonoBehaviour
{     
    [SerializeField]
    public int lane;
    [SerializeField]
    public float maxDistance;
    private bool ColorChange = true;
    [SerializeField]
    public Text renkYazi;

    [SerializeField]
    Material red, blue, green;

    [SerializeField]
    Transform player;

    
    private const float LANE_DISTANCE = 2.5f;
    public CharacterController controller;

    Renderer rend;

    public float jumpForce = 8.0f;
    public float gravity = 12.0f;
    public float verticalVelocity;
    public float speed = 7.0f;

    [SerializeField]
    public ParticleSystem leftSparkle, rightSparkle;


    // Timer to track collision time
    float _timeColliding;
    // Time before damage is taken, 1 second default
    public float timeThreshold = 1f;

    private int desiredLane = 1;//0:left 1:middle 2:right
    private string materialName;

    public string activeColor;
    GameObject Object;

    public healthBar HealthBar;
    public int currentHealth=100;
    public int maxHealth = 100;
    public int minHealth = 0;
    public int Colorindex;
    public int damage;
    void Start()
    {
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);

        rend = GetComponent<Renderer>();
        rend.enabled = true;
        controller = GetComponent<CharacterController>();
        int[] renkDizi = new int[3] { 1, 2, 3 };
        StartCoroutine(RenkDegistir());

    }  

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {           
            leftSparkle.Play();
            rightSparkle.Play();
            MoveLane(false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {         
            leftSparkle.Play();
            rightSparkle.Play();
            MoveLane(true);
        }
        
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                verticalVelocity = -gravity * Time.deltaTime;
                verticalVelocity = jumpForce;
                CameraEffects.ShakeOnce();
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime; 
        }

        Vector3 targerPosition = transform.position.z * Vector3.forward;

        if (desiredLane == 0)
        {
            
            targerPosition += Vector3.left * LANE_DISTANCE;
            
        }
        else if (desiredLane == 2)
        {          
            targerPosition += Vector3.right * LANE_DISTANCE;           
        }

        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targerPosition - transform.position).normalized.x * speed;
        moveVector.y = verticalVelocity;

        controller.Move(moveVector * Time.deltaTime);

        //minecart color change

        if (activeColor == "Kirmizi")
        {           
            rend.sharedMaterial = red;         
        }
        else if (activeColor == "Yesil")
        {
            rend.sharedMaterial = green;           
        }
        else
        {         
            rend.sharedMaterial = blue;        
        }
    }

    public void MoveLane(bool goingRight)
    {
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }
  
    private void OnTriggerEnter(Collider other)
    {          
        Object = other.gameObject;
        materialName = Object.GetComponent<Renderer>().material.name;
     
        if (currentHealth>0)
        {
            if (materialName == "RedRail (Instance)" && activeColor == "Kirmizi" && currentHealth <= maxHealth)
            {
              
                currentHealth += damage;
            }
            else if (materialName == "GreenRail (Instance)" && activeColor == "Yesil" && currentHealth <= maxHealth)
            {
               
                currentHealth += damage;
            }
            else if (materialName == "CyanRail (Instance)" && activeColor == "Mavi" && currentHealth <= maxHealth)
            {
                
                currentHealth += damage;
            }
            else if (Object.tag == "Obstacle")
            {
                
                FindObjectOfType<GameManager>().EndGame();

            }
            else if (Object.tag == "Collectable")
            {
                ICollectable collected = other.GetComponent<ICollectable>();
                collected.Collect();
            }
            else
            {
                currentHealth -= damage;
            }

            HealthBar.SetHealth(currentHealth);
        }
        else
        {           
            FindObjectOfType<GameManager>().EndGame();                     
        }
                
    }
    IEnumerator RenkDegistir()
    {
        while (ColorChange)
        {
            Colorindex = Random.Range(0, 3);

            switch (Colorindex)
            {
                case 0:
                    activeColor = "Kirmizi";
                    break;
                case 1:
                    activeColor = "Yesil";
                    break;
                case 2:
                    activeColor = "Mavi";
                    break;
            }        

            yield return new WaitForSeconds(4f);
        }
    }
    
}
