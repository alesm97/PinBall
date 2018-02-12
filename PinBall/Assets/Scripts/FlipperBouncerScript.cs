using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperBouncerScript : MonoBehaviour {
	
	public float power;
	
	private void OnTriggerEnter(Collider other)
	{
		Vector3 newForce = -other.GetComponent<Rigidbody>().velocity.normalized;
		other.GetComponent<Rigidbody>().AddForce( newForce * power, ForceMode.Impulse);
	}
}
