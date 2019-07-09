using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2 : MonoBehaviour
{
    // Start is called before the first frame update
    
     Vector3 pointA = new Vector3(-7, 0.5f, -3);
     Vector3 pointB = new Vector3(7, 0.5f, -3);
     void Update()
     {
         transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
     }


    // Update is called once per frame

}
