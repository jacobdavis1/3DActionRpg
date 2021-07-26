using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!GetComponentInParent<StatesComponent>().Attacking)
            return;

        // Don't hit yourself
        if (other.transform.root == transform.root)
            return;

        HealthComponent otherHealth = other.GetComponent<HealthComponent>();
        if (!otherHealth)
            return;

        EquipmentComponent equipment = GetComponent<EquipmentComponent>();

        GetComponent<MeshCollider>().enabled = false;
    }
}
