using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 3;
 
    private Vector3 newPosition;

    void Awake ()
    {
        newPosition = transform.position;
    }
    void Update ()
    {
        PositionChanging ();
    }
    void PositionChanging ()
    {
        Vector3 positionA = new Vector3(3, 1, 3);
        Vector3 positionB = new Vector3(-3, 1, 3);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
    }











}