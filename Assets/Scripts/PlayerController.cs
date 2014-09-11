//
// Movement, Space=Boost
//

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	//

	public float speedModifier;
	public float jumpModifier;
	public Transform gameCamera;
	public float jumpTimeLimit;

	private Vector3 m_playerMovement;
	private float m_moveHorizontal;
	private float m_moveVertical;
	private float SpeedRechargeTime;
	private float jumpTime;
	
	void FixedUpdate ()
	{
		// transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);

		m_moveHorizontal = Input.GetAxis ("Horizontal");
		m_moveVertical = Input.GetAxis ("Vertical");
		m_playerMovement = gameCamera.TransformDirection(new Vector3 (m_moveHorizontal, 0.0f, m_moveVertical));

		rigidbody.AddForce (m_playerMovement * speedModifier * Time.deltaTime);

		jumpTime += Time.deltaTime;

		if (Input.GetKeyDown(KeyCode.Space) && jumpTime >= jumpTimeLimit)
		{
			rigidbody.AddForce(Vector3.up * jumpModifier);
			jumpTime = 0;
		}
	}
}
