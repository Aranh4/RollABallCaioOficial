using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject loseTextObject;

    public AudioClip coin;
    public AudioClip lose;
    public AudioSource audio;
    public AudioSource audiolose;
    private int playedonce;
    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
        rb = GetComponent<Rigidbody>();
        playedonce = 0;
        count = 0;
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        
    }


    // Update is called once per frame
    void OnMove (InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
       
    }

    void SetCountText() 
   {
       countText.text =  "Count: " + count.ToString();
       if (count >= 16)
       {
           winTextObject.SetActive(true);
           Invoke("Inicial",2f);
           GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
              foreach (GameObject e in Enemies)
              {
                e.SetActive(false);
              }

       }
   }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        
    }

    void OnTriggerEnter(Collider other) 
   {
        if (other.gameObject.CompareTag("PickUp"))
        {
            
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            //play audio source
            
            audio.PlayOneShot(coin, 0.7F);
            
           

      
            
        }

    
   }

    void Inicial()
    {
         SceneManager.LoadScene(0);
    }

   private void OnCollisionEnter(Collision other)
   {
    if (other.gameObject.CompareTag("Enemy"))
        {
            //change scene
           
           Invoke("Inicial",2f);
           GameObject[] PickUps = GameObject.FindGameObjectsWithTag("PickUp");
              foreach (GameObject PickUp in PickUps)
              {
                PickUp.SetActive(false);
              }
            GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
              foreach (GameObject e in Enemies)
              {
                e.SetActive(false);
              }
            loseTextObject.SetActive(true);
            if (playedonce == 0)
            {
                audiolose.PlayOneShot(lose, 0.7F);
                playedonce = 1;
            }
        
                

        }
   }

}
