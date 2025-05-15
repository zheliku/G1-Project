using TMPro;
using UnityEngine;

public class UIPerformance : MonoBehaviour
{
    public TextMeshProUGUI txtPerformance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        txtPerformance.text = Global.Performance;
    }
}