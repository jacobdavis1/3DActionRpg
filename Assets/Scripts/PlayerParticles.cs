using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    GameObject leftUnequipParticles, rightUnequipParticles;

    // Start is called before the first frame update
    void Start()
    {
        leftUnequipParticles = GameObject.Find("Unequip_L");
        rightUnequipParticles = GameObject.Find("Unequip_R");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayUnequipParticles()
    {
        if (!leftUnequipParticles || !rightUnequipParticles)
            return;

        leftUnequipParticles.GetComponent<ParticleSystem>().Play();
        rightUnequipParticles.GetComponent<ParticleSystem>().Play();
    }
}
