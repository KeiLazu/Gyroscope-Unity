using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour {

	public GameObject bulletPrefabs;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ShootOnClick()
	{
		GameObject obj = (GameObject)Instantiate (bulletPrefabs, transform.position, transform.parent.rotation);
		float bulletTravel = obj.GetComponent<BulletBehaviour> ().travelSpeed;
		obj.GetComponent<Rigidbody> ().velocity = (obj.transform.forward * bulletTravel);
	}
}
