using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroForCamera : MonoBehaviour {

	float verticalCalculation;

	Vector3 movement;

	GameObject xInd, yInd;

	void Awake()
	{
		Input.gyro.enabled = true;

		xInd = GameObject.Find ("xIndicator");
		yInd = GameObject.Find ("yIndicator");

	}

	// Update is called once per frame
	void Update () {
//		GyroModifyCamera ();

		float horizontal = Input.acceleration.x;
		float vertical = Input.acceleration.y;

		xInd.gameObject.GetComponent<UnityEngine.UI.Text> ().text = "X: " + horizontal.ToString ();
		yInd.gameObject.GetComponent<UnityEngine.UI.Text> ().text = "Y: " + vertical.ToString ();

		if (vertical > -0.5f && vertical < 0.0f) {
			verticalCalculation = (vertical + 0.5f) * -2f; // hasilnya maju, semakin ke 0 semakin cepat

		} else if (vertical < -0.5f && vertical > -1f) {
			verticalCalculation = vertical * 0.5f; // hasilnya mundur

		} else if (vertical < 0.5f && vertical > 0.0f) {
			verticalCalculation = 0;

		} else if (vertical > 0.5f && vertical < 1f) {
			verticalCalculation = 0;

		}

		movement = new Vector3 (horizontal, 0f, verticalCalculation);

		transform.position += movement;

	}

	void GyroModifyCamera()
	{
		transform.rotation = GyroToUnity (Input.gyro.attitude);

	}

	private static Quaternion GyroToUnity (Quaternion q)
	{
		return new Quaternion (q.x, q.y, -q.z, -q.w);
//		return new Quaternion (0f,q.y,0f,-q.w);

	}

}
