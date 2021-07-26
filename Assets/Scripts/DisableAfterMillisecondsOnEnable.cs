using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterMillisecondsOnEnable : MonoBehaviour
{
    public float AwakeMilliseconds;
    float _timer;

    // Start is called before the first frame update
    void Start()
    {
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > 0)
            _timer -= Time.deltaTime;
        else gameObject.SetActive(false);
    }

    public void SetTimer()
    {
        _timer = AwakeMilliseconds/1000;
    }
}
