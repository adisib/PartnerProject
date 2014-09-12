//
// Moves a block back and forth in directions equal to true, cannot choose distance per direction
//

using UnityEngine;
using System.Collections;

public class BlockMover : MonoBehaviour {
	
	//

	public bool x, y, z;
	public float distance; // one way, either way
	public float speed;

	private Vector3 startPos;
	
	void Awake ()
	{
		startPos = rigidbody.position;

		if(x)
		{
			rigidbody.AddForce (Vector3.left * speed);
		}
		if(y)
		{
			rigidbody.AddForce (Vector3.down * speed);
		}
		if(z)
		{
			rigidbody.AddForce (Vector3.back * speed);
		}
	}

	void Update ()
	{
		if(x)
		{
			if(rigidbody.position.x > (startPos.x + distance))
			{
				rigidbody.AddForce (Vector3.left * speed);
			}
			else if(rigidbody.position.x < (startPos.x - distance))
			{
				rigidbody.AddForce (Vector3.right * speed);
			}
		}
		if(y)
		{
			if(rigidbody.position.y > (startPos.y + distance))
			{
				rigidbody.AddForce (Vector3.down * speed);
			}
			else if(rigidbody.position.y < (startPos.y - distance))
			{
				rigidbody.AddForce (Vector3.up * speed);
			}
		}
		if(z)
		{
			if(rigidbody.position.z > (startPos.z + distance))
			{
				rigidbody.AddForce (Vector3.back * speed);
			}
			else if(rigidbody.position.z < (startPos.z - distance))
			{
				rigidbody.AddForce (Vector3.forward * speed);
			}
		}
	}
}
