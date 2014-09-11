//
// After Game ends, do final actions and clean up or whatever
//


using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	//

	public GameObject ball;
	public GUIText End_Text;

	public static bool gameOver {get{return m_gameOver;}}
	
	private float m_fallLimit = -5;
	private static bool m_gameOver;

	void Awake ()
	{
		// Attempt to cap framerate
		Application.targetFrameRate = 60;
		End_Text.text = "";
	}
	
	void Start ()
	{
		m_gameOver = false;
	}

	// Check if fallen under platform
	void Update ()
	{
		if(ball.transform.position.y < m_fallLimit)
		{
			m_gameOver = true;
			End_Text.text = "Game Over";
			ball.SetActive(false);
		}
	}
}
