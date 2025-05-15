using System;
using UnityEngine;

public class Symbol : MonoBehaviour
{
    // Defines the movement speed of the game object
    public float Speed = 4;
    
    // Reference to the Rigidbody component of the game object
    public Rigidbody Body;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Gets the Rigidbody component attached to the game object
        Body = GetComponent<Rigidbody>();
    
        // Sets the initial linear velocity of the game object in the forward direction
        Body.linearVelocity = transform.forward * Speed;
    }
}
