using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotator2 : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject targetObject;

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate (new Vector3 (15, 30, 45)*10 * Time.deltaTime)
        //transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
        if (targetObject.CompareTag("Player")){
            transform.position = Vector3.MoveTowards(this.transform.position, targetObject.transform.position, 4 * Time.deltaTime); 

        }
        else{
            //move up and down
            transform.position = new Vector3(transform.position.x, transform.position.y,Mathf.PingPong(7*Time.time, 20)-10);
        }

    }
}
            
