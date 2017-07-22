using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour {

	int controlSwitch = 0;

	Rigidbody rb;
	Vector3 movement;

	[SerializeField]
	GameObject textIndicator;

	void Awake()
	{
		rb = gameObject.GetComponent<Rigidbody> ();
		Input.gyro.enabled = true;

		textIndicator = GameObject.Find ("Indicator");

	}

	void Start()
	{
		

	}

	protected void OnGUI()
	{
		GUI.skin.label.fontSize = Screen.width / 40;

		GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude);
		GUILayout.Label("input.accelerator.magnitude.x: " + Input.acceleration.x);
		GUILayout.Label("input.accelerator.magnitude.y: " + Input.acceleration.y);
		GUILayout.Label("Samsung S7 width/font: " + Screen.width + " : " + GUI.skin.label.fontSize);
	}

	void Update()
	{
//		transform.rotation = GyroToUnity (Input.gyro.attitude);

		switch (controlSwitch) {
		case 0:
			movement = new Vector3 (Input.acceleration.x, 0f, Input.acceleration.y);
			textIndicator.GetComponent<UnityEngine.UI.Text> ().text = "Accelerator";
			break;

		case 1:
			movement = new Vector3 (-Input.gyro.attitude.x * 0.8f, 0f, -Input.gyro.attitude.y * 0.8f);
			textIndicator.GetComponent<UnityEngine.UI.Text> ().text = "Gyroscope";
			break;

		default:
			movement = new Vector3 (Input.acceleration.x, 0f, Input.acceleration.y);
			textIndicator.GetComponent<UnityEngine.UI.Text> ().text = "Accelerator";
			break;
		}

		rb.velocity = movement * 2f;

	}

	private static Quaternion GyroToUnity(Quaternion q)
	{
		return new Quaternion(q.x, q.y, -q.z, -q.w);
	}

	public void AccerelatorSwitch()
	{
		controlSwitch = 0;

	}

	public void GyroSwitch()
	{
		controlSwitch = 1;

	}

}
