using System;
using UnityEngine;

public class Board : MonoBehaviour
{
    // The speed at which the object moves forward
    public float Speed = 3;
    
    // The Rigidbody component of the object, used for physics calculations
    public Rigidbody Body;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the Rigidbody component attached to the object
        Body = GetComponent<Rigidbody>();
    
        // Set the object's linear velocity in the forward direction based on its speed
        Body.linearVelocity = transform.forward * Speed;
    }
    
    // Called when the object collides with another object's trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // If the collided object is tagged as "Head"
        if (other.CompareTag("Head"))
        {
            // Stop the object's movement
            Body.linearVelocity = Vector3.zero;
            // Enable gravity on the object
            Body.useGravity = true;
            // Decrement the global score
            Global.Score--;
        }
    }
}