//
// Camera Follows player, and Rotates by moving mouse
//

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	//

	public Transform player;
	public float cameraSpeed;

	private Vector3 offset;
	private Vector3 newTransform;
	
	void Start () {
		offset = new Vector3(player.position.x, player.position.y + 5.0f, player.position.z - 5.0f);
	}

	void LateUpdate () {
		offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * cameraSpeed, Vector3.up) * offset;
		transform.position = player.position + offset; 
		transform.LookAt(player.position);
	}
}
