using MLAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NetworkManager.Singleton.IsServer)
        {
            gameObject.SetActive(false);
            InventoryManager.Singleton.SpawnRandomEquipmentServerRpc(transform.position);
        }
    }
}
