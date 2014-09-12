//
// Movement (in direction camera is facing), Space = Jump
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
	private float m_jumpTime;
	
	void FixedUpdate ()
	{
		m_moveHorizontal = Input.GetAxis ("Horizontal");
		m_moveVertical = Input.GetAxis ("Vertical");
		m_playerMovement = gameCamera.TransformDirection(new Vector3 (m_moveHorizontal, 0.0f, m_moveVertical));

		rigidbody.AddForce (m_playerMovement * speedModifier * Time.deltaTime);

		m_jumpTime += Time.deltaTime;

		if (Input.GetKeyDown(KeyCode.Space) && m_jumpTime >= jumpTimeLimit)
		{
			rigidbody.AddForce(Vector3.up * jumpModifier);
			m_jumpTime = 0;
		}
	}
}
