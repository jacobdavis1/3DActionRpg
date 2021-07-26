using MLAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayUntilPlayerJoins : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ( (NetworkManager.Singleton.IsConnectedClient || NetworkManager.Singleton.IsServer) && !enabled)
        {
            enabled = true;
        }
    }
}
