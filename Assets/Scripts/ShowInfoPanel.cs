using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfoPanel : MonoBehaviour
{
    GameObject canvasObject;

    // Start is called before the first frame update
    void Start()
    {
        canvasObject = GetComponentInChildren<Canvas>().gameObject;
        canvasObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        canvasObject.SetActive(true);
        DisableAfterMillisecondsOnEnable d = canvasObject.GetComponent<DisableAfterMillisecondsOnEnable>();
        d.SetTimer();
    }
}
