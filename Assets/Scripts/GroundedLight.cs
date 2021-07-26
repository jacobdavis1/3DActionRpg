using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedLight : MonoBehaviour
{
    StatesComponent states;
    Light groundedLight;

    // Start is called before the first frame update
    void Start()
    {
        states = GetComponentInParent<StatesComponent>();
        groundedLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedLight.enabled = states.Grounded;
    }
}
