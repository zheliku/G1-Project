using System;
using UnityEngine;

public enum TouchAreaType
{
    Perfect,
    Good,
    Miss
}

public class TouchArea : MonoBehaviour
{
    public TouchAreaType Type;
    
    public int Score;
}
