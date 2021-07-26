using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class HeadLookViaCamera : MonoBehaviour
{
	private Vector3 crosshair;
	public Transform head = null;
	public float lookAtCoolTime = 0.2f;
	public float lookAtHeatTime = 0.2f;
	public bool looking = true;

	private Vector3 lookAtPosition;
	private Animator anim;
	private float lookAtWeight = 0.0f;

	StatesComponent states;
	NetworkObject networkObject;

	void Start()
	{
		if (!head)
		{
			Debug.LogError("No head transform - LookAt disabled");
			enabled = false;
			return;
		}

		states = GetComponent<StatesComponent>();
		anim = GetComponent<Animator>();
		networkObject = GetComponent<NetworkObject>();

		crosshair = new Vector3(Screen.width / 2, Screen.height / 2, 0);
	}

	void OnAnimatorIK()
	{
		float lookAtTargetWeight = looking ? 1.0f : 0.0f;

		Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(crosshair.x, crosshair.y, 10));
		
		if (networkObject.OwnerClientId != NetworkManager.Singleton.LocalClientId)
		{
			point = states.HeadLookAtPositon;
		}
		else
        {
			states.HeadLookAtPositon = point;
        }

		Vector3 curDir = point - head.position;
		Vector3 futDir = curDir;

		curDir = Vector3.RotateTowards(curDir, futDir, 6.28f * Time.deltaTime, float.PositiveInfinity);
		lookAtPosition = head.position + curDir;

		float blendTime = lookAtTargetWeight > lookAtWeight ? lookAtHeatTime : lookAtCoolTime;
		lookAtWeight = Mathf.MoveTowards(lookAtWeight, lookAtTargetWeight, Time.deltaTime / blendTime);
		anim.SetLookAtWeight(lookAtWeight, 0.2f, 0.5f, 0.7f, 0.5f);
		anim.SetLookAtPosition(lookAtPosition);
	}
}
