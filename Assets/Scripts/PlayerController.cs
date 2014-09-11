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

	private Vector3 m_playerMovement;
	private float m_moveHorizontal;
	private float m_moveVertical;
	private float SpeedRechargeTime;
	
	void FixedUpdate ()
	{
		// transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);

		m_moveHorizontal = Input.GetAxis ("Horizontal");
		m_moveVertical = Input.GetAxis ("Vertical");
		m_playerMovement = gameCamera.TransformDirection(new Vector3 (m_moveHorizontal, 0.0f, m_moveVertical));

		rigidbody.AddForce (m_playerMovement * speedModifier * Time.deltaTime);


		if (Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody.AddForce(Vector3.up * jumpModifier);
		}
	}
}
