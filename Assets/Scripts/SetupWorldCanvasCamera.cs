using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupWorldCanvasCamera : MonoBehaviour
{
    public Vector3 CanvasOffset;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        transform.position = transform.parent.position + CanvasOffset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.parent.position + CanvasOffset; 
    }
}
