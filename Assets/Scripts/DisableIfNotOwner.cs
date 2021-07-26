using MLAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfNotOwner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NetworkObject networkObject = GetComponentInParent<NetworkObject>();
        if (NetworkManager.Singleton.LocalClientId != networkObject.OwnerClientId)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
