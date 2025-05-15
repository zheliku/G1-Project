using System.Collections.Generic;
using UnityEngine;

public class SymbolGenerator : MonoBehaviour
{
    // List of position transformations for generating symbols
    public List<Transform> GeneratePoses;
    
    // List of game objects representing different symbols
    public List<GameObject> Symbols;
        
    // The direction in which symbols move after generation
    public Vector3 MoveDirection = Vector3.forward;
    
    // List of time points for generating symbols
    public List<float> TimeTiks;
    
    // Index tracking the current time point for generating symbols
    public int TikIndex;

    public float StartTime;
        
    // Audio source for playing sound effects
    public AudioSource Audio;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Schedule the PlayAudio method to be called after a delay of 3.5 seconds
        Invoke(nameof(PlayAudio), 4 - 0.4f); // 4 - 0.4f 是音符飞过来的时间延迟
        
        TimeTiks.Clear();

        var i = StartTime;
        while (i < 240)
        {
            var time = Random.Range(0.5f, 1.5f);
            i += time;
            TimeTiks.Add(i);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        // Check if the current time exceeds the current generation time point
        if (TikIndex < TimeTiks.Count && Time.time > TimeTiks[TikIndex])
        {
            // Randomly select a symbol to generate
            var index = Random.Range(0, Symbols.Count); // [0, 1): 0;  [0, 4): 0, 1, 2, 3
            var obj   = Symbols[index];
            var inst  = Instantiate(obj); // copy one object
            
            // Set the position of the generated symbol to a random position from GeneratePoses
            inst.transform.position = GeneratePoses[Random.Range(0, GeneratePoses.Count)].position;
            inst.SetActive(true);
            
            // Set the forward direction of the symbol to the predefined movement direction
            inst.transform.forward  = MoveDirection;
    
            // Move to the next generation time point
            TikIndex++;
        }
    }
    
    // Method to play audio
    private void PlayAudio()
    {
        Audio.Play();
    }
}
