using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUIComponent : MonoBehaviour
{
    public HealthBarComponent HealthBar { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponentInChildren<HealthBarComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}