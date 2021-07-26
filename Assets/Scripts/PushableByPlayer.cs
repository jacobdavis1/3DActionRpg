using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableByPlayer : MonoBehaviour
{
    InputComponent input;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 3) // Creatures layer
            return;

        Vector3 collisionDirection = (transform.position - collision.gameObject.transform.position).normalized;
        gameObject.GetComponent<Rigidbody>().AddForce(collisionDirection * 5.0f, ForceMode.Impulse);
    }
}
