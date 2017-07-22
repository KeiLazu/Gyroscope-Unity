using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerControl : MonoBehaviour {

	void FixedUpdate()
	{
		GyroControlCamera ();

	}

	void GyroControlCamera()
	{
		transform.rotation = GyroToUnity (Input.gyro.attitude);

	}

	public static Quaternion GyroToUnity(Quaternion q)
	{
		return new Quaternion (0f, q.y, 0f, -q.w);

	}

}
