using UnityEngine;
using System.Collections;

public class BouncePlatform : MonoBehaviour {

	public float bounceModifier;

	void OnTriggerEnter(Collider other)
	{
		other.rigidbody.AddForce(Vector3.up * bounceModifier);
	}
}