using MLAPI;
using MLAPI.NetworkVariable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedPhysicsObject : NetworkBehaviour
{
    NetworkVariable<Vector3> _position = new NetworkVariable<Vector3>(new Vector3(0, 0, 0));
    public Vector3 Position { get { return _position.Value;  } set { _position.Value = value;  } }

    NetworkVariable<Vector3> _rotation = new NetworkVariable<Vector3>(new Vector3(0, 0, 0));
    public Quaternion Rotation { get { return Quaternion.Euler(_rotation.Value); } set { _rotation.Value = value.eulerAngles; } }

    bool _owner = false;

    // Start is called before the first frame update
    void Start()
    {
        if (NetworkManager.Singleton.LocalClientId == GetComponent<NetworkObject>().OwnerClientId)
            _owner = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_owner)
        {
            Position = transform.position;
            Rotation = transform.rotation;
        }
        else
        {
            transform.position = Position;
            transform.rotation = Rotation;
        }
    }
}
